using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVC3.BLL.Interfaces;
using MVC3.BLL.Repos;
using MVC3.DAL.Data;
using MVC3.PL.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MVC3.DAL.Models;

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


            services.AddDbContext<AppDbContext>(option => { option.UseSqlServer(Configuration.GetConnectionString("TheDefault")); 
            }/*,ServiceLifetime.Scoped*/);


            services.AddServices();

            //services.AddScoped<UserManager<ApplicationUser>>();
            //services.AddScoped<SignInManager<ApplicationUser>>();
            //services.AddScoped<RoleManager<IdentityRole>>();





            //services.AddIdentity<ApplicationUser, IdentityRole>(); 

            services.AddIdentity<ApplicationUser, IdentityRole>(option =>
            {
                option.Password.RequiredLength = 5;
                //option.User.AllowedUserNameCharacters = "asjskjdfed5565";
                option.User.RequireUniqueEmail = true;

            }).AddEntityFrameworkStores<AppDbContext>();


          




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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
