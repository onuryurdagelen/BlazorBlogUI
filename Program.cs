using Blazored.LocalStorage;
using Blazored.Toast;
using BlazorSpinner;
using BlazorStrap;
using BlogBlazorUI;
using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Options;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7176/api/") });
builder.Services.AddBlazorStrap();
builder.Services.AddBlazoredToast();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBootstrapBlazor();
builder.Services.AddMudServices();
builder.Services.AddScoped<SpinnerService>();

await builder.Build().RunAsync();
