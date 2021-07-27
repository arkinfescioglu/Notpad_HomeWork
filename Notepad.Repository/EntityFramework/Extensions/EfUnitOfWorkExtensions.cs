using Microsoft.Extensions.DependencyInjection;
using Notepad.Repository.EntityFramework.UnitOfWork;

namespace Notepad.Repository.EntityFramework.Extensions
{
    public static class EfUnitOfWorkExtensions
    {
        public static IServiceCollection UseEfUnitOfWorks(this IServiceCollection services)
        {
            services.AddScoped<IEfUnitOfWork, EfUnitOfWork>();
            return services;
        }
    }
}