using Microsoft.Extensions.DependencyInjection;
using MVC3.BLL.Interfaces;
using MVC3.BLL.Repos;

namespace MVC3.PL.Extentions
{
    public static class commonServicesOfApplication
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IDeptInterface, DeptRepo>();

            //services.AddTransient<IDeptInterface, DeptRepo>();
            //services.AddSingleton<IDeptInterface, DeptRepo>();

            services.AddScoped<IEmployeeInterface, EmployeeRepo>();
        }
    }
}
