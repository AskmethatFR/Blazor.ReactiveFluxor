using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazor.ReactiveFluxor;
using Blazor.ReactiveFluxor.Reactive;
using Blazor.ReactiveFluxor.Store.Counter;
using Fluxor;
using Fluxor.Blazor.Web.ReduxDevTools;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
var currentAssembly = typeof(Program).Assembly;
builder.Services.AddFluxor(options =>
{
    options.ScanAssemblies(currentAssembly);
#if DEBUG
    options.UseReduxDevTools();
#endif
});


builder.Services.AddTransient<CounterSelector>();
builder.Services.AddTransient(typeof(AppSelector<,,>));

await builder.Build().RunAsync();

public partial class Program{}