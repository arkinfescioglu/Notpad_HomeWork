using Microsoft.Extensions.DependencyInjection;
using Notepad.Auth.Api;
using Notepad.Auth.Role;

namespace Notepad.Auth
{
    public static class ApiAuthExtensions
    {
        public static IServiceCollection UseApiAuth(this IServiceCollection services)
        {
            services.AddScoped<IApiAuth, ApiAuth>();
            services.AddScoped<IRole, Role.Role>();
            return services;
        }
    }
}