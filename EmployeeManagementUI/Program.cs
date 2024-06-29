using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using EmployeeManagementUI;
using Microsoft.JSInterop;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);

        builder.RootComponents.Add<App>("#app");
        //builder.Services.AddScoped<IJSRuntime, JSRuntime>();

        //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5186") });
        builder.Services.AddScoped<AuthService>();
        builder.Services.AddScoped<EmployeeService>();

        // Add authentication services
        builder.Services.AddAuthorizationCore();
        builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

        await builder.Build().RunAsync();
    }
}
