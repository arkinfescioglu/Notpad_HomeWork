using Microsoft.Extensions.DependencyInjection;
using Notepad.Service.Cities;
using Notepad.Service.NoteCategories;
using Notepad.Service.Notes;
using Notepad.Service.Users;

namespace Notepad.Service
{
    public static class ServiceExtensions
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<ICityService, CityManager>();
            services.AddScoped<INoteService, NoteManger>();
            services.AddScoped<INoteCategoryService, NoteCategoryManager>();
            return services;
        }
    }
}