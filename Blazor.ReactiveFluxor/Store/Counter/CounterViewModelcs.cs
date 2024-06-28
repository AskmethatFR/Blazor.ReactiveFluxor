using System.Reactive.Subjects;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace Blazor.ReactiveFluxor.Store.Counter;

public record CounterViewModel(int CurrentCount)
{
}