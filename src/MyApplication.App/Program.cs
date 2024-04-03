using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Moryx.Model;
using Moryx.Runtime.Kernel;
using Moryx.Runtime.Modules;
using Moryx.Tools;
using MyApplication.App;
using System.Globalization;
using System.Text.Json.Serialization;

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
        new CultureInfo("de-DE"),
        new CultureInfo("en-US"),
        new CultureInfo("it-it"),
        new CultureInfo("zh-Hans"),
    };
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
    options.SetDefaultCulture("de-De");
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

app.MapControllers().WithMetadata(new AllowAnonymousAttribute());
app.MapRazorPages();

#endregion

app.Services.UseMoryxConfigurations("Config");

var moduleManager = app.Services.GetRequiredService<IModuleManager>();
moduleManager.StartModules();

app.Run();

moduleManager.StopModules();
