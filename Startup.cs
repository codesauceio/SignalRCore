using CoreWebTest.Data;
using CoreWebTest.Utilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CoreWebTest
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var settings = new JsonSerializerSettings();
            settings.ContractResolver = new SignalRContractResolver();

            var serializer = JsonSerializer.Create(settings);

            services.Add(new ServiceDescriptor(typeof(JsonSerializer), 
                        provider => serializer, 
                        ServiceLifetime.Transient));

            services.AddSingleton<IPostRepository, PostRepository>();

            services.AddSignalR(options => 
            {
                options.Hubs.EnableDetailedErrors = true;
            });
            
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            app.UseStaticFiles();
            app.UseMvc(routes => 
                {
                    routes.MapRoute(
                            name: "default",
                            template: "api/{controller}/{action}/{id?}"
                    );
                }
            );
            app.UseWebSockets();
            app.UseSignalR();

        }
    }
}
