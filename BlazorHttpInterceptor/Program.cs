using BlazorHttpInterceptor.Http;

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorHttpInterceptor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped<StatusCodeHttpMessageHandler>();
            builder.Services.AddScoped(sp =>
            {
                var handler = sp.GetRequiredService<StatusCodeHttpMessageHandler>();

                return new HttpClient(handler)
                {
                    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
                };
            });

            await builder.Build().RunAsync();
        }
    }
}
