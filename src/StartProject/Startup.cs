using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Moryx;
using Moryx.Asp.Integration;

namespace StartProject
{
    public class Startup
    {
        private readonly IApplicationRuntime _moryxRuntime;

        public Startup(IApplicationRuntime moryxRuntime)
        {
            _moryxRuntime = moryxRuntime;
        }

        // ConfigureServices() is called by the host before the Configure() method and will configure the app's
        // services. By convention, this where configuration options are set, and where services are added the container.
        // This method is optional for the Startup class.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMoryxFacades(_moryxRuntime);
            services.AddSignalR();
            services.AddControllers();
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
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
