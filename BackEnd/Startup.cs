using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System.Data.Common;
using ROP.ApiExtensions.Translations;
using BackEnd.Empresa.Services;
using BackEnd.Empresa.Services.Distributed;
using BackEnd.Empresa.Services.Memory;
using BackEnd.Services.WithCache;

using BackEnd.Repositories;
using BackEnd.ServiceDependencies;
using BackEnd.ServiceDependencies.WithCache;
using BackEnd.ServiceDependencies.WithDistributedCache;

namespace BackEnd
{
    public class Startup
	{
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.AddTranslation<TraduccionErrores>(services);
            });
            services.AddDataProtection();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // services.AddHttpContextAccessor();  // Puedes eliminar esta línea, ya que ya has agregado el IHttpContextAccessor arriba.

            // Otros servicios que necesites registrar...


         



            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ListUsersWithCompanyName>();
            services.AddScoped<ListUsersWithMemoryCache>();
            services.AddScoped<ListUsersWithDistributedCache>();
            services.AddScoped<IListUsersWithCompanyNameDependencies, ListUsersWithCompanyNameDependencies>();
            services.AddScoped<IListUsersWithMemoryCache, ListUsersMemoryCacheServiceDependencies>();
            services.AddScoped<IListUsersWithDistributedCache, ListUsersDistributedCacheServiceDependencies>();
            services.AddScoped<IDistributedEmpresaServicio, Empresa.Services.Distributed.EmpresaServicio>();
            services.AddSingleton<IEmpresaServicio, Empresa.Services.Memory.EmpresaServicio>();





            services.AddDistributedRedisCache(options =>
            {
                options.Configuration = "localhost:6379,password=password123";
                options.InstanceName = "localhost";
            });

            services.AddHttpClient("EmpresaMS", client =>
            {
                client.BaseAddress = new Uri("https://localhost:7207/");
            });



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseRouting();
            app.UseMiddleware<CustomHeaderValidatorMiddleware>(AcceptedLanguageHeader.HeaderName);

            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context => { await context.Response.WriteAsync("Hello World!"); });
                endpoints.MapControllers();
            });
        }
    }
    
}

