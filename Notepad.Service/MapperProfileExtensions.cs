using Microsoft.Extensions.DependencyInjection;

namespace Notepad.Service
{
    public static class MapperProfileExtensions
    {
        public static IServiceCollection LoadMapperProfiles(this IServiceCollection services)
        {
            // services.AddAutoMapper(typeof(CityListMapper));
            return services;
        }
    }
}