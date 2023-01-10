using BlazorStrap;
using BlogBlazorUI;
using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Options;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7176/api/") });
builder.Services.AddBlazorStrap();
builder.Services.AddBootstrapBlazor();


await builder.Build().RunAsync();
