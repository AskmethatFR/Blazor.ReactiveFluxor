using Blazor.ReactiveFluxor.Reactive;
using Blazor.ReactiveFluxor.Store.Counter;
using Fluxor;
using Microsoft.Extensions.DependencyInjection;

namespace Blazor.ReactiveFluxorTest;

public class CounterSelectorTests
{

    [Fact]
    public void IncrementByOne()
    {
        // Arrange
        var appSelector = new CounterSelector(new CounterState()
        {
            Count = 1
        });
        // Act
        Assert.Equal(1, appSelector.Get().CurrentCount);
    }
    
    [Fact]
    public void DecreaseByOne()
    {
        // Arrange
        var appSelector = new CounterSelector(new CounterState()
        {
            Count = 0
        });
        // Act
        Assert.Equal(0, appSelector.Get().CurrentCount);
    }
}