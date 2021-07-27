using Microsoft.Extensions.DependencyInjection;
using Notepad.EntityFramework.EntityFrameworkCore.Contexts;

namespace Notepad.EntityFramework.EntityFrameworkCore.Extensions
{
    public static class EntityFrameworkDbContextExtension
    {
        public static IServiceCollection UseEntityFrameworkDbContext(this IServiceCollection services)
        {
            services.AddDbContext<EfContext>();
            return services;
        }
    }
}