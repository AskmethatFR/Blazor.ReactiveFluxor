using System.Reactive.Subjects;
using Blazor.ReactiveFluxor.Reactive;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace Blazor.ReactiveFluxor.Store.Counter;

public record CounterSelector : ReactiveSelector<CounterState, CounterViewModel>
{
    private readonly BehaviorSubject<CounterViewModel> _currentCount;
    public override void Dispose()
    {
        _currentCount.Dispose();
    }
    public override void Next(CounterState state)
    {
        _currentCount.OnNext(new CounterViewModel(state.Count));
    }

    public override CounterViewModel Get()
    {
        return _currentCount.Value;
    }

    public CounterSelector(CounterState state) : base()
    {
        _currentCount = new BehaviorSubject<CounterViewModel>(new CounterViewModel(state.Count));
    }
}