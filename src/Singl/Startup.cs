using System;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.Extensions.Configuration;
using Singl.Models;
using Singl.Settings;
using Singl.ViewModels;
using AM = AutoMapper;

namespace Singl
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
                .AddJsonFile($"config.{env.EnvironmentName}.json", optional: true)                
                .AddEnvironmentVariables();
            Configuration = builder.Build();
            
            // Add configuration from an optional config.development.json, config.staging.json or 
            // config.production.json file, depending on the environment. These settings override the ones in the 
            // config.json file.
                        
            if (System.IO.File.Exists("singl.sqlite"))
            {
                System.Console.WriteLine("Deleted singl.sqlite");
                System.IO.File.Delete("singl.sqlite");
            }

             using(var context = new DatabaseContext())
            {
                context.Database.EnsureCreated();
                context.Populate();
            }
        }


        // This method gets called by the runtime.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            
            ConfigureOptionsServices(services, this.Configuration);
            
            // Register Entity Framework
            services.AddEntityFramework()
                .AddSqlite()
                .AddDbContext<DatabaseContext>();
                
            // Add MVC services to the services container.
            services.AddMvc(); 
            
            services.AddTransient<Singl.Services.IDisciplinaService, Singl.Services.DisciplinaService>();

            // Uncomment the following line to add Web API services which makes it easier to port Web API 2 controllers.
            // You will also need to add the Microsoft.AspNet.Mvc.WebApiCompatShim package to the 'dependencies' section of project.json.
            // services.AddWebApiConventions();
            
            return services.BuildServiceProvider();
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
                //routes.MapRoute("areaRoute", "{area:exists}/{controller}/{action}");
                routes.MapRoute(
                    name: "areaRoute",
                    template: "{area:exists}/{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" },
                    constraints: null,
                    dataTokens: new { NameSpace = "default" });
              
                routes.MapRoute(
                    name: "controllerActionRoute",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" },
                    constraints: null,
                    dataTokens: new { NameSpace = "default" });
                    
                routes.MapRoute(
                    "controllerRoute",
                    "{controller}",
                    new { controller = "Home" });                    

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
        
        /// <summary>
        /// Configures the settings by binding the contents of the config.json file to the specified Plain Old CLR 
        /// Objects (POCO) and adding <see cref="IOptions{}"/> objects to the services collection.
        /// </summary>
        /// <param name="services">The services collection or IoC container.</param>
        /// <param name="configuration">Gets or sets the application configuration, where key value pair settings are 
        /// stored.</param>
        private void ConfigureOptionsServices(IServiceCollection services, IConfiguration configuration)
        {
            // Adds IOptions<AppSettings> to the services container.
            services.Configure<AppSettings>(configuration.GetSection(nameof(AppSettings)));

            // Adds IOptions<CacheProfileSettings> to the services container.
            //  services.Configure<CacheProfileSettings>(configuration.GetSection(nameof(CacheProfileSettings)));
        }
        
    }
}
