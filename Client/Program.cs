using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WhoKnowsApp.Client;
using WhoKnowsApp.APIClient;
using WhoKnowsApp.APIClient.Endpoints.Interfaces;
using WhoKnowsApp.APIClient.Endpoints;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("WhoKnowsApp.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress + "api/"));

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddTransient(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("WhoKnowsApp.ServerAPI"));

builder.Services.AddScoped<IQuestionEndpoints, QuestionEndpoints>();

builder.Services.AddApiClientServiceExtensions();

await builder.Build().RunAsync();
