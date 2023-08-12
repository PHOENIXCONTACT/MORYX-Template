using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using System.Globalization;
using Moryx.Launcher;

namespace MyApplication.App
{
    // ASP.NET Core apps use a Startup class, which is named Startup by convention. The Startup class includes
    // a Configure() method to create the app's request processing pipeline.  It can also include an optional
    // ConfigureServices() method to configure the app's services. A "service" is a reusable component that provides
    // app functionality. Services are registered in ConfigureServices and consumed across the app via dependency
    // injection (DI) or ApplicationServices. ConfigureServices() and Configure() are called by the ASP.NET Core
    // runtime when the application starts. See this link for more information: commment
    // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/startup?view=aspnetcore-3.1
    public class Startup
    {
        // ConfigureServices() is called by the host before the Configure() method and will configure the app's
        // services. By convention, this where configuration options are set, and where services are added the container.
        // This method is optional for the Startup class.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IShellNavigator, ShellNavigator>();
            services.AddSingleton<IAuthorizationPolicyProvider, ExamplePolicyProvider>();

            services.AddLocalization();
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {
                    new CultureInfo("de-De"),
                    new CultureInfo("en-De"),
                    new CultureInfo("it-De"),
                    new CultureInfo("zh-Hans"),
                };

                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });


            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder
                .WithOrigins("http://localhost:4200") // Angular app url for testing purposes
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
            });

            services.AddRazorPages();

            services.AddControllers()
                .AddJsonOptions(jo => jo.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

            services.AddSwaggerGen(c =>
            {
                c.CustomOperationIds(api => ((ControllerActionDescriptor)api.ActionDescriptor).MethodInfo.Name);
                c.CustomSchemaIds(type => type.ToString());
            });
        }

        // Configure() is used to specify how the app responds to HTTP requests. The request pipeline is configured
        // by adding middleware components to an IApplicationBuilder instance. IApplicationBuilder is available to the
        // Configure method(), but it isn't registered in the service container. Hosting creates an IApplicationBuilder
        // and passes it directly to Configure().
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRequestLocalization();

            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseRouting();

            if (env.IsDevelopment())
                app.UseCors("CorsPolicy");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMoryxLocalization();

            app.UseEndpoints(endpoints =>
            {
                var conventionBuilder = endpoints.MapControllers();
                conventionBuilder.WithMetadata(new AllowAnonymousAttribute());

                endpoints.MapRazorPages();
            });
        }
    }

    public class ExamplePolicyProvider : DefaultAuthorizationPolicyProvider
    {
        public ExamplePolicyProvider(IOptions<AuthorizationOptions> options) : base(options)
        {
        }

        public override async Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
        {
            var policy = await base.GetPolicyAsync(policyName);

            if (policy == null)
            {
                policy = new AuthorizationPolicyBuilder()
                    .RequireClaim("Permission", policyName)
                    .Build();
            }
            return policy;
        }
    }

}