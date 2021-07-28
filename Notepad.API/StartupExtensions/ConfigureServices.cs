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
                            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Notepad.Api", Version = "v1" });
                            
                            c.DocInclusionPredicate((docName, description) => true);
                            
                            c.EnableAnnotations();
                            
                            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                            {
                                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
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