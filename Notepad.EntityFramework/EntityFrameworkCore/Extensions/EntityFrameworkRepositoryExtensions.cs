using Microsoft.Extensions.DependencyInjection;
using Notepad.EntityFramework.Repository;

namespace Notepad.EntityFramework.EntityFrameworkCore.Extensions
{
    public static class EntityFrameworkRepositoryExtensions
    {
        public static IServiceCollection UseEfRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IEfRepository<>), typeof(EfRepositoryBase<>));
            return services;
        }
    }
}