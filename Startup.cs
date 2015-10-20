using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Dnx.Runtime;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Logging;
using Neadm.Models;
using Neadm.ViewModels;
using AM = AutoMapper;

namespace Neadm
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        
        public Startup(IHostingEnvironment env, IApplicationEnvironment appEnv)
        {
            // Setup configuration sources.
            var builder = new ConfigurationBuilder()
                .SetBasePath(appEnv.ApplicationBasePath)
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();
            Configuration = builder.Build();
            
                        
            if (System.IO.File.Exists("neadm.sqlite"))
            {
                System.Console.WriteLine("Deleted neadm.sqlite");
                System.IO.File.Delete("neadm.sqlite");
            }

             using(var context = new NeadmDbContext())
            {
                context.Database.EnsureCreated();
                context.Populate();
            }
        }


        // This method gets called by the runtime.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.Configure<ApplicationConfiguration>(Configuration.GetSection("ApplicationConfiguration"));
 
            // Register Entity Framework
            services.AddEntityFramework()
                .AddSqlite()
                .AddDbContext<NeadmDbContext>();
                
            // Add MVC services to the services container.
            services.AddMvc();

            // Uncomment the following line to add Web API services which makes it easier to port Web API 2 controllers.
            // You will also need to add the Microsoft.AspNet.Mvc.WebApiCompatShim package to the 'dependencies' section of project.json.
            // services.AddWebApiConventions();
        }

        // Configure is called after ConfigureServices is called.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            
            ConfigureMappers();
            
            loggerFactory.MinimumLevel = LogLevel.Information;
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();
            

            // Configure the HTTP request pipeline.

            // Add the following to the request pipeline only in development environment.
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // Add Error handling middleware which catches all application specific errors and
                // send the request to the following path or controller action.
                app.UseExceptionHandler("/Home/Error");
            }

            // Add static files to the request pipeline.
            app.UseStaticFiles();

            // Add MVC to the request pipeline.
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                // Uncomment the following line to add a route for porting Web API 2 controllers.
                // routes.MapWebApiRoute("DefaultApi", "api/{controller}/{id?}");
            });
        }

        private void ConfigureMappers()
        {
            AM.Mapper.CreateMap<Disciplina, DisciplinaEditViewModel>();
            AM.Mapper.CreateMap<DisciplinaEditViewModel,Disciplina>();
            AM.Mapper.CreateMap<Disciplina, DisciplinaCreateViewModel>();
            AM.Mapper.CreateMap<DisciplinaCreateViewModel,Disciplina>();
        }
    }
}
