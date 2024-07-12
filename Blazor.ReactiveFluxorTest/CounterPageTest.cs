using Blazor.ReactiveFluxor.Pages;
using Blazor.ReactiveFluxor.Reactive;
using Bunit;
using Fluxor;
using Microsoft.Extensions.DependencyInjection;

namespace Blazor.ReactiveFluxorTest;

public class CounterPageTest : TestContext
{
    public CounterPageTest()
    {
        Services.AddFluxor(options => options.ScanAssemblies(typeof(Program).Assembly));
        Services.AddScoped(typeof(AppSelector<,,>));

        IStore store = Services.GetRequiredService<IStore>();
        store.InitializeAsync().Wait();
    }

    [Fact]
    public void BaseCounterPage()
    {
        // Act
        var cut = RenderComponent<Counter>();

        // Assert
        Assert.Contains("Current count: 0", cut.Markup);
    }
    
    [Fact]
    public void IncrementCounter()
    {
        // Act
        var cut = RenderComponent<Counter>();

        // Assert
        cut.Find("#increment").Click();
        Assert.Contains("Current count: 1", cut.Markup);
    }
    
    [Fact]
    public void DecrementCounter()
    {
        // Act
        var cut = RenderComponent<Counter>();

        // Assert
        cut.Find("#decrement").Click();
        Assert.Contains("Current count: -1", cut.Markup);
    }
    
}