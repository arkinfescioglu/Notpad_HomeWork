using Microsoft.Extensions.DependencyInjection;
using Notepad.Service.Cities.Mapper;
using Notepad.Service.NoteCategories.Mapper;
using Notepad.Service.Notes.Mapper;
using Notepad.Service.Users.Mapper;

namespace Notepad.Service
{
    public static class MapperProfileExtensions
    {
        public static IServiceCollection LoadMapperProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(UserCreateMapper));
            services.AddAutoMapper(typeof(CityListMapper));
            services.AddAutoMapper(typeof(NoteCreateMapper));
            services.AddAutoMapper(typeof(NoteCategoryListMapper));
            services.AddAutoMapper(typeof(NoteUpdateMapper));
            services.AddAutoMapper(typeof(NoteOutMapper));
            return services;
        }
    }
}