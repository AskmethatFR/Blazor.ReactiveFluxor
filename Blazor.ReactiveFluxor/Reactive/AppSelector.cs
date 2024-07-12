using Fluxor;

namespace Blazor.ReactiveFluxor.Reactive;

public delegate TReturnType Selector<in TState, out TReturnType>(TState state);

public class AppSelector<TState, TReturnType, TSelector> where TSelector : ReactiveSelector<TState, TReturnType>, IDisposable
{
    private readonly IState<TState> _state;
    private readonly Selector<TState, TReturnType> _selector;
    private readonly TSelector? _reactiveSelector;

    public AppSelector(IState<TState> state)
    {
        _state = state;
        _reactiveSelector = ((TSelector)Activator.CreateInstance(typeof(TSelector), new object[] { state.Value }));
        _selector = currentState =>
        {
            _reactiveSelector.Next(currentState);
            return _reactiveSelector.Get();
        };
    }

    public TReturnType Select() => _selector(_state.Value);
    
    public void Dispose() => _reactiveSelector!.Dispose();
}