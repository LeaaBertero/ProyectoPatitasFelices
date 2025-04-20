using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PatitasFelices.Client;
using PatitasFelices.Client.Servicios;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

#region Servicio de interfáz de HTTPServicio
builder.Services.AddScoped<IHTTPServicio, HTTPServicio>();
#endregion

await builder.Build().RunAsync();
