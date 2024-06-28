using System.Reactive.Linq;
using Fluxor;

namespace Blazor.ReactiveFluxor.Store.Counter;

[FeatureState]
public record CounterState
{
    public int Count { get; init; } = 0;
}

public record IncrementCounterAction();

public record DecrementCounterAction();

public static class CounterReducers
{
   
    [ReducerMethod]
    public static CounterState ReduceIncrementCounterAction(CounterState state, IncrementCounterAction action)
    {
        return state with
        {
            Count = state.Count + 1,
        };
    }

    [ReducerMethod]
    public static CounterState ReduceDecrementCounterAction(CounterState state, DecrementCounterAction action)
    {
        return state with
        {
            Count = state.Count - 1,
        };
    }
}