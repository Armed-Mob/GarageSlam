using GS.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("GS.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("GS.ServerAPI"));
builder.Services.AddSyncfusionBlazor();

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTM0ODkxNUAzMjMwMmUzNDJlMzBURExsWHFQbkdSUW5iS0JYNjhlbE1UemxGNFUrVjNIWkpHb3ZVUGhkTWVBPQ==");

await builder.Build().RunAsync();
