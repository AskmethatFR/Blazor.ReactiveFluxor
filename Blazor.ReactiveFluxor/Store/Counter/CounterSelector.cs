using System.Reactive.Subjects;
using Blazor.ReactiveFluxor.Reactive;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace Blazor.ReactiveFluxor.Store.Counter;

public record CounterSelector : ReactiveSelector<IState<CounterState>, CounterViewModel>
{
    private readonly BehaviorSubject<CounterViewModel> _currentCount;
    public override void Dispose()
    {
        _currentCount.Dispose();
    }
    protected override void Next()
    {
        _currentCount.OnNext(new CounterViewModel(_state.Value.Count));
    }

    public override CounterViewModel Get()
    {
        return _currentCount.Value;
    }

    public CounterSelector(IState<CounterState> state) : base(state)
    {
        _currentCount = new BehaviorSubject<CounterViewModel>(new CounterViewModel(_state.Value.Count));
    }
}