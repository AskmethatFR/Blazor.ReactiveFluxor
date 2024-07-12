namespace Blazor.ReactiveFluxor.Reactive;

public abstract record ReactiveSelector<TState, TViewModel>: IDisposable
{
    public abstract void Dispose();
    public abstract void Next(TState state);
    public abstract TViewModel Get();
}