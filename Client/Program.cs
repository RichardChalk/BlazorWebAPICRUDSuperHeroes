global using SuperHeroes.Client.Services.SuperHeroService;
global using SuperHeroes.Shared;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SuperHeroes.Client;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Inject my services
builder.Services.AddScoped<ISuperHeroService, SuperHeroService>();

await builder.Build().RunAsync();
