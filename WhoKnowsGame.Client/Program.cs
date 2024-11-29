using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WhoKnowsGame.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddFluentUIComponents();

await builder.Build().RunAsync();
