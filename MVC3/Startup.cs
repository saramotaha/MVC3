using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVC3.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC3
{
    public class Startup
    {
        public IConfiguration Configuration { get; }=null;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Configuration = configuration;
        }

       

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            //services.AddScoped<AppDbContext>();
            //services.AddSingleton<AppDbContext>();
            //services.AddTransient<AppDbContext>();



            //services.AddScoped<DbContextOptions<AppDbContext>>();




            //services.AddDbContext<AppDbContext>(option=>option.UseSqlServer("Server=.;Database=AppMVC3;Trusted_Connection=True;MultipleActiveResultSets=True;Encrypt=False"));


            services.AddDbContext<AppDbContext>(option => option.UseSqlServer(Configuration.GetConnectionString("TheDefault")));

           

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
