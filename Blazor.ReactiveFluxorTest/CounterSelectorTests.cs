using Blazor.ReactiveFluxor.Reactive;
using Blazor.ReactiveFluxor.Store.Counter;
using Fluxor;
using Microsoft.Extensions.DependencyInjection;

namespace Blazor.ReactiveFluxorTest;

public class CounterSelectorTests
{
    private readonly ServiceProvider _serviceProvider;

    public CounterSelectorTests()
    {
        IServiceCollection serviceCollection = new ServiceCollection();
        serviceCollection.AddFluxor(options => options.ScanAssemblies(typeof(Program).Assembly));
        _serviceProvider = serviceCollection.BuildServiceProvider();

        IStore store = _serviceProvider.GetRequiredService<IStore>();
        store.InitializeAsync().Wait();
        
    }
    
    private void GivenAStoreWithOneCounter()
    {
        var dispatcher = _serviceProvider.GetRequiredService<IDispatcher>();
        dispatcher.Dispatch(new IncrementCounterAction());
    }

    [Fact]
    public void IncrementByOne()
    {
        // Arrange
        var appSelector = new AppSelector<IState<CounterState>, CounterViewModel, CounterSelector>(_serviceProvider.GetRequiredService<IState<CounterState>>());
        // Act
        var dispatcher = _serviceProvider.GetRequiredService<IDispatcher>();
        dispatcher.Dispatch(new IncrementCounterAction());

        Assert.Equal(1, appSelector.Select().CurrentCount);
    }
    
    [Fact]
    public void DecreaseByOne()
    {
        // Arrange
        GivenAStoreWithOneCounter();
        var appSelector = new AppSelector<IState<CounterState>, CounterViewModel, CounterSelector>(_serviceProvider.GetRequiredService<IState<CounterState>>());
        
        // Act
        var dispatcher = _serviceProvider.GetRequiredService<IDispatcher>();
        dispatcher.Dispatch(new DecrementCounterAction());

        Assert.Equal(0, appSelector.Select().CurrentCount);
    }
}