using Microsoft.Extensions.DependencyInjection;
using Notepad.Dapper.Repository;

namespace Notepad.Dapper
{
    public static class DapperRepositoryExtensions
    {
        public static IServiceCollection UseDapperRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IDapperRepository<>), typeof(DapperRepository<>));
            return services;
        }
    }
}