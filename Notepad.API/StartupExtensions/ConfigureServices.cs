using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Notepad.Auth;
using Notepad.Dapper;
using Notepad.EntityFramework.EntityFrameworkCore.Extensions;
using Notepad.Repository.EntityFramework.Extensions;
using Notepad.Service;

namespace Notepad.API.StartupExtensions
{
    public static class ConfigureServices
    {
        public static IServiceCollection LoadConfigureServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
                        services.AddCors(options =>
                        {
                            options.AddPolicy("AllowOrigin",
                                    builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
                        });
            
            
                        services.UseEfRepository();
                        services.UseEfUnitOfWorks();
                        services.UseApiAuth();
                        services.LoadMyServices();
                        services.UseEntityFrameworkDbContext();
                        services.UseDapperRepository();
                        services.LoadMapperProfiles();
                        services.AddControllers();
                        
                        services.AddSwaggerGen(c =>
                        {
                            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Notepad.Api", Version = "v1", 
                                    Description = @"Bu Projede EntityFramework 6 kullandım. Tek gereken EntityFramework
                                                    Katmanında dotnet ef database update yazmanız yeterli. Ancak
                                                    Connection Stringi alışılmışın dışında yaptım. Utilities katmanında
                                                    Config DatabaseConfig Sınıfından Çekiyorum. 
                                                    Auth ve Jwt Sisteminde Identity ya da her hangi bir 
                                                    eklenti kullanmadım. Yapıyı kendim yazdım." });
                            
                            c.DocInclusionPredicate((docName, description) => true);
                            
                            c.EnableAnnotations();
                            
                            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                            {
                                    Description = "Auth Olduktan Sonra  Value Kısımına Bearer JwtToken Yazıp Auth işlemi gerçekleşir.",
                                    Name = "Authorization",
                                    BearerFormat = "JWT",
                                    Scheme = "Bearer",
                                    In = ParameterLocation.Header,
                                    Type = SecuritySchemeType.ApiKey
                            });
                            
                            c.AddSecurityRequirement(new OpenApiSecurityRequirement
                            {
                                    {
                                            new OpenApiSecurityScheme
                                            {
                                                    Reference = new OpenApiReference
                                                    {
                                                            Type = ReferenceType.SecurityScheme,
                                                            Id   = "Bearer"
                                                    }
                                            },
                                            new string[] {}
                                    }
                            });
                        });
                        return services;
        }
    }
}