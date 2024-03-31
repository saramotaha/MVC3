using Microsoft.Extensions.DependencyInjection;
using MVC3.BLL.Interfaces;
using MVC3.BLL.Repos;
using AutoMapper;
using MVC3.PL.Profiles;
using MVC3.BLL;

namespace MVC3.PL.Extentions
{
    public static class commonServicesOfApplication
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IDeptInterface, DeptRepo>();

            //services.AddTransient<IDeptInterface, DeptRepo>();
            //services.AddSingleton<IDeptInterface, DeptRepo>();

            //services.AddScoped<IEmployeeInterface, EmployeeRepo>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //services.AddAutoMapper(M=>M.AddProfile(new MappingProfiles()));


        }
    }
}
