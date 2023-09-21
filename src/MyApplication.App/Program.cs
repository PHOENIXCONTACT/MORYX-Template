using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Moryx.Asp.Integration;
using Moryx.Model;
using Moryx.Runtime.Kernel;
using Moryx.Tools;
using System.Globalization;
using System.IO;
using System.Text.Json.Serialization;

namespace MyApplication.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AppDomainBuilder.LoadAssemblies();

            var builder = WebApplication.CreateBuilder();
            var services = builder.Services;

            // Setup MORYX
            services.AddMoryxKernel();
            services.AddMoryxModels();
            services.AddMoryxModules();

            #region Startup ConfigureServices
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
            #endregion

            var app = builder.Build();
            var env = app.Environment;

            #region Startup Configure App
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

            app.UseEndpoints(endpoints =>
            {
                var conventionBuilder = endpoints.MapControllers();
                conventionBuilder.WithMetadata(new AllowAnonymousAttribute());

                endpoints.MapRazorPages();
            });
            #endregion

            app.Services.UseMoryxConfigurations("Config");
            app.Services.StartMoryxModules();

            app.Run();

            app.Services.StopMoryxModules();
        }
    }
}
