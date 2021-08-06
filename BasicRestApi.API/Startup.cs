using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BasicRestAPI.Database;
using BasicRestAPI.Repositories;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BasicRestApi.API
{
    public class Startup
    {
        string FlowerstoreDBMySQL;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            FlowerstoreDBMySQL = configuration.GetConnectionString("FlowerstoreConnection");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddControllers();
            services.AddDbContextPool<ProjectDatabaseContext>(    
                dbContextOptions => dbContextOptions 
                    .UseMySql(
                        FlowerstoreDBMySQL,
                        
                        new MySqlServerVersion(new Version(10, 4, 11))
                        
            ));
            services.AddTransient<IStoreRepository, StoreRepository>();
            services.AddTransient<IFlowerRepository, FlowerRepository>();
            services.AddTransient<ISaleRepository, SaleRepository>();
            services.AddMvc();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Flowerstore API",
                    Version = "v1"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => 
            {
                c.SwaggerEndpoint("v1/swagger.json", "My API V1");
            });

            app.UseCors(builder =>
            builder.WithOrigins("http://localhost:5000")
                .AllowAnyHeader()
                .AllowAnyMethod());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
