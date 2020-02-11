using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

// Auth Code (Begin)
// ********************************
using Microsoft.AspNetCore.Components.Authorization;
// ********************************
// Auth Code (End)

namespace BlazorClientAD.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Auth Code (Begin)
            // ********************************
            // Must call AddAuthorizationCore for Blazor Client auth 
            services.AddAuthorizationCore();
            // First register our CustomAuthenticationProvider
            services.AddScoped<CustomAuthenticationProvider>();
            // Use our CustomAuthenticationProvider as the 
            // AuthenticationStateProvider
            services.AddScoped<AuthenticationStateProvider>(
                provider => provider
                .GetRequiredService<CustomAuthenticationProvider>());
            // ********************************
            // Auth Code (End)
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
