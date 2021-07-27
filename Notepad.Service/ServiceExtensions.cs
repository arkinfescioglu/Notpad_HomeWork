using Microsoft.Extensions.DependencyInjection;
using Notepad.Service.Users;

namespace Notepad.Service
{
    public static class ServiceExtensions
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserManager>();
            // services.AddScoped<ICityService, CityManager>();
            return services;
        }
    }
}