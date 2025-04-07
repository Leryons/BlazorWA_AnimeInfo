using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using AnimeInfo;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<AnimeServices>();

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://api.jikan.moe/v4/")
});

await builder.Build().RunAsync();