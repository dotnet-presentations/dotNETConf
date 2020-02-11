using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;

// Auth Code (Begin)
// ********************************
// Must Add the NuGet Packages:
// Microsoft.AspNetCore.Authentication.AzureAD.UI

using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using System.Threading.Tasks;
// ********************************
// Auth Code (End)

namespace BlazorClientAD.Server
{
    public class Startup
    {
        // Auth Code (Begin)
        // ********************************
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // ********************************
        // Auth Code (End)

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddResponseCompression(opts =>
            {
                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                    new[] { "application/octet-stream" });
            });

            // Auth Code (Begin)
            // ********************************
            services.AddAuthentication(AzureADDefaults.AuthenticationScheme)
                 .AddAzureAD(options => Configuration.Bind("AzureAd", options));

            services.Configure<OpenIdConnectOptions>(AzureADDefaults.OpenIdScheme,
                options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        // Instead of using the default validation (validating against a 
                        // single issuer value, as we do in
                        // line of business apps), we inject our own multitenant 
                        // validation logic
                        ValidateIssuer = false,

                        // If the app is meant to be accessed by entire organizations, 
                        // add your issuer validation logic here.
                        // IssuerValidator = 
                        // (issuer, securityToken, validationParameters) => {
                        //    if (myIssuerValidationLogic(issuer)) return issuer;
                        //}
                    };

                    options.Events = new OpenIdConnectEvents
                    {
                        OnTicketReceived = context =>
                        {
                            // This is called on successful authentication
                            // This is an opportunity to write to the database 
                            // or alter internal roles ect.
                            return Task.CompletedTask;
                        },
                        OnAuthenticationFailed = context =>
                        {
                            context.Response.Redirect("/Error");
                            context.HandleResponse(); // Suppress the exception
                            return Task.CompletedTask;
                        }
                    };
                });
            // ********************************
            // Auth Code (End)
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseResponseCompression();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBlazorDebugging();
            }

            app.UseStaticFiles();
            app.UseClientSideBlazorFiles<Client.Startup>();

            app.UseRouting();

            // Auth Code (Begin)
            // ********************************
            app.UseAuthentication();
            app.UseAuthorization();
            // ********************************
            // Auth Code (End)

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapFallbackToClientSideBlazor<Client.Startup>("index.html");
            });
        }
    }
}
