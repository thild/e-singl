using System;
using System.Buffers;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Singl.Models;
using Singl.Settings;
using Singl.ViewModels;
using AM = AutoMapper;

namespace Singl
{

    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            // Setup configuration sources.
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json")
                .AddJsonFile($"config.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

            // Add configuration from an optional config.development.json, config.staging.json or 
            // config.production.json file, depending on the environment. These settings override the ones in the 
            // config.json file.
        }


        // This method gets called by the runtime.
        public void ConfigureServices(IServiceCollection services)
        {


            ConfigureOptionsServices(services, this.Configuration);

            // Register Entity Framework
            services.AddEntityFramework()
                .AddEntityFrameworkSqlite()
                .AddDbContext<DatabaseContext>();

            services.AddDataProtection().SetDefaultKeyLifetime(TimeSpan.FromDays(14));

            // Add Identity services to the services container
            //http://wildermuth.com/2015/09/10/ASP_NET_5_Identity_and_REST_APIs
            services.AddIdentity<Usuario, IdentityRole>(options =>
                    {
                        options.Cookies.ApplicationCookie.AccessDeniedPath = "/Home/AccessDenied";
                        options.User.RequireUniqueEmail = true;
                        options.Password.RequiredLength = 5;
                        options.Password.RequireNonAlphanumeric = false;
                        options.Password.RequireDigit = false;
                        options.Password.RequireUppercase = false;
                        options.Cookies.ApplicationCookie.LoginPath = "/Admin/Login";
                        options.SignIn.RequireConfirmedEmail = false;
                        options.SignIn.RequireConfirmedPhoneNumber = false;
                    })
                    .AddEntityFrameworkStores<DatabaseContext>()
                    .AddDefaultTokenProviders();

            // services.AddCors(options =>
            // {
            //     options.AddPolicy("CorsPolicy", builder =>
            //     {
            //         builder.WithOrigins("http://example.com");
            //     });
            // });
            // Add MVC services to the services container.
            services.AddMvc().AddMvcOptions(option =>
            {
                //Clear all existing output formatters
                option.OutputFormatters.Clear();
                var jsonOutputFormatter = new JsonOutputFormatter(
                    new Newtonsoft.Json.JsonSerializerSettings
                    {
                        ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                    }, ArrayPool<char>.Shared
                );
                //Set ReferenceLoopHandling
                //jsonOutputFormatter.SerializerSettings.MaxDepth = 3;
                //jsonOutputFormatter.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.None;

                //Insert above jsonOutputFormatter as the first formatter, you can insert other formatters.
                option.OutputFormatters.Insert(0, jsonOutputFormatter);
            });


            services.AddTransient<Singl.Services.IDisciplinaService, Singl.Services.DisciplinaService>();
            services.AddTransient<Singl.Services.ISetorAdministrativoService, Singl.Services.SetorAdministrativoService>();
            services.AddTransient<Singl.Services.ISetorConhecimentoService, Singl.Services.SetorConhecimentoService>();
            services.AddTransient<Singl.Services.ICampusService, Singl.Services.CampusService>();
            services.AddTransient<Singl.Services.IUnidadeUniversitariaService, Singl.Services.UnidadeUniversitariaService>();

            // Uncomment the following line to add Web API services which makes it easier to port Web API 2 controllers.
            // You will also need to add the Microsoft.AspNetCore.Mvc.WebApiCompatShim package to the 'dependencies' section of project.json.
            // services.AddWebApiConventions();



            // Configure Auth
            // services.AddAuthorization(options =>
            // {
            //     options.AddPolicy(
            //         "ManageStore",
            //         authBuilder =>
            //         {
            //             authBuilder.RequireClaim("ManageStore", "Allowed");
            //         });
            // });

        }

        // Configure is called after ConfigureServices is called.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {

            ConfigureMappers();

            loggerFactory.AddConsole(LogLevel.Debug);
            loggerFactory.AddDebug(LogLevel.Debug);


            // Configure the HTTP request pipeline.

            // Add the following to the request pipeline only in development environment.
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                // Add Error handling middleware which catches all application specific errors and
                // send the request to the following path or controller action.
                app.UseExceptionHandler("/Home/Error");
            }

            //app.UseCors("CorsPolicy");

            // Add static files to the request pipeline.
            app.UseStaticFiles();



            //https://damienbod.com/2016/03/14/secure-file-download-using-identityserver4-angular2-and-asp-net-core/

            //app.UseOAuthBearerAuthentication();

            ConfigureAuthentication(app);

            // Add MVC to the request pipeline.
            app.UseMvc(routes =>
            {
                //routes.MapRoute("areaRoute", "{area:exists}/{controller}/{action}");
                routes.MapRoute(
                    name: "areaRoute",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "controllerActionRoute",
                    template: "{controller=Home}/{action=Index}/{id?}");

                // routes.MapRoute(
                //     name: "departamentos",
                //     template: "{area:exists}/{controller}/{action}/{sigla?}");

                routes.MapRoute(
                    "controllerRoute",
                    "{controller}",
                    new { controller = "Home" });

                // After all your routes
                routes.MapRoute(
                    "DeepLinkAreas",
                    "{area:exists}/{*pathInfo}",
                    defaults: new { controller = "Home", action = "Index" });

                routes.MapRoute(
                    "DeepLink",
                    "{*pathInfo}",
                    defaults: new { controller = "Home", action = "Index" });

                // Uncomment the following line to add a route for porting Web API 2 controllers.
                // routes.MapWebApiRoute("DefaultApi", "api/{controller}/{id?}");
            });

            // var dbfile = $"{Directory.GetCurrentDirectory()}/singl.sqlite";
            // if (System.IO.File.Exists(dbfile))
            // {
            //     System.Console.WriteLine("Deleted singl.sqlite");
            //     System.IO.File.Delete(dbfile);
            // }

            // using (var context = new DatabaseContext())
            // {
            //     context.InitializeStoreDatabaseAsync(app.ApplicationServices).Wait();
            // }
        }

        private void ConfigureAuthentication(IApplicationBuilder app)
        {

            // app.UseCors(policy =>
            // {
            //     policy.WithOrigins("http://localhost:28895", "http://localhost:7017");
            //     policy.AllowAnyHeader();
            //     policy.AllowAnyMethod();
            // });

            // JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            // app.UseIdentityServerAuthentication(options =>
            // {
            //     options.Authority = "http://localhost:22530/";
            //     options.ScopeName = "api1";
            //     options.ScopeSecret = "secret";

            //     options.AutomaticAuthenticate = true;
            //     options.AutomaticChallenge = true;
            // });

            app.UseIdentity();

            // app.UseOpenIdConnectServer(options =>
            // {
            //     options.TokenEndpointPath = "/api/v1/token";
            //     options.AllowInsecureHttp = true;
            //     options.AuthorizationEndpointPath = PathString.Empty;
            //     options.Provider = new OpenIdConnectServerProvider
            //     {
            //         OnValidateClientAuthentication = context =>
            //         {
            //             context.Skipped();
            //             return Task.FromResult<Object>(null);
            //         },
            //         OnGrantResourceOwnerCredentials = async context =>
            //         {
            //             var usersService = app.ApplicationServices.GetService<IUsersService>();

            //             User user = usersService.getUser(context.Username, context.Password);

            //             var identity = new ClaimsIdentity(new List<Claim>(), OpenIdConnectServerDefaults.AuthenticationScheme);
            //             identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            //             identity.AddClaim(new Claim(ClaimTypes.Name, user.Id.ToString()));
            //             identity.AddClaim(new Claim("myclaim", "4815162342"));

            //             var ticket = new AuthenticationTicket(
            //                 new ClaimsPrincipal(identity),
            //                 new AuthenticationProperties(),
            //                 context.Options.AuthenticationScheme);

            //             ticket.SetResources(new[] { "http://localhost:53844" });
            //             ticket.SetAudiences(new[] { "http://localhost:53844" });
            //             ticket.SetScopes(new[] { "email", "offline_access" });
            //             context.Validated(ticket);
            //         }
            //     };
            // });
        }
        private void ConfigureMappers()
        {
            var config = new AM.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Disciplina, DisciplinaEditViewModel>();
                cfg.CreateMap<DisciplinaEditViewModel, Disciplina>();
                cfg.CreateMap<Disciplina, DisciplinaCreateViewModel>();
                cfg.CreateMap<DisciplinaCreateViewModel, Disciplina>();
            });
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
            // Setup options with DI
            services.AddOptions();

            // Configure MyOptions using code
            services.Configure<AppSettings>(myOptions =>
            {
            });
        }

    }
}
