using App.AutoMapper;
using Data.Context;
using Data.Repository;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Service.Services;
using Service.Validators;
using Swashbuckle.AspNetCore.Swagger;

namespace App
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {            
            services.AddScoped<IBaseRepository<Route>, BaseRepository<Route>>();
            services.AddScoped<IBaseService<Route>, BaseService<Route>>();
            services.AddScoped<ICustomRoutesValidators, CustomRoutesValidators>();                       
            services.AddScoped<IRouteRepository, RouteRepository>();
            services.AddScoped<IRouteService, RouteService>();           

            
            services.AddDbContext<SqlContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ConnectionDefault")));
            services.AddAutoMapper(typeof(AutoMapperSetup));
            services.AddSwaggerGen(x =>
           {
               x.SwaggerDoc("v1", new OpenApiInfo { Title = "Banco Master Teste Calcular melhor rota", Version = "V1" });
           });
            services.AddMvcCore().AddApiExplorer();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "Calcular melhor rota V1");
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                     name: "default",
                  pattern: "{controller=Swagger}/{action=Index}/{id?}");
                //endpoints.MapControllers();
                
            });
        }
    }
}
