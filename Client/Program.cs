using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Blazored.LocalStorage;
using Client;
using Client.Core;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddAuthorizationCore(); 
builder.Services.AddScoped<AuthStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(provider =>
    provider.GetRequiredService<AuthStateProvider>());


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7139/") });

builder.Services.AddScoped<UserApiClient>();

builder.Services.AddSingleton<SignalRService>();

await builder.Build().RunAsync();
