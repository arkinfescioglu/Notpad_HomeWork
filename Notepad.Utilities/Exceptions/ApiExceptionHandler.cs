using System.Text.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Notepad.Utilities.Exceptions.Api;

namespace Notepad.Utilities.Exceptions
{
    public static class ApiExceptionHandler
    {
        public static void CustomUseExceptionHandle(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.StatusCode  = 200;
                    context.Response.ContentType = "application/json";
                    var errorFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if ( errorFeature != null )
                    {
                        var ex = errorFeature.Error;

                        #region Api Exception

                        if ( ex is ApiResponseException apiEx )
                        {
                            var result = JsonSerializer.Serialize(new
                            {
                                    ResultStatus = 1,
                                    Message      = apiEx.Message,
                                    IsException  = true,
                                    IsSuccess    = false,
                                    IsValidation = false,
                            });
                            await context.Response.WriteAsync(result);
                        }

                        #endregion

                        #region Api Validation 

                        if ( ex is ApiValidationException exValid )
                        {
                            var result = JsonSerializer.Serialize(new
                            {
                                    ResultStatus       = 1,
                                    Message            = exValid.Message,
                                    IsException        = true,
                                    IsValidation       = true,
                                    IsSuccess          = false,
                                    ValidationMessages = exValid.ValidationMessages
                            });
                            
                            await context.Response.WriteAsync(result);
                        }

                        #endregion

                        #region Api Auth Exception

                        if ( ex is ApiAuthException authException )
                        {
                            var result = JsonSerializer.Serialize(new
                            {
                                    ResultStatus = 1,
                                    Message      = authException.Message,
                                    IsException  = true,
                                    IsValidation = true,
                                    IsSuccess    = false,
                            });
                            await context.Response.WriteAsync(result);
                        }

                        #endregion

                        #region Api System Error

                        if ( ex is ApiSystemErrorException sysEx )
                        {
                            var result = JsonSerializer.Serialize(new
                            {
                                    ResultStatus = 1,
                                    Message      = sysEx.Message,
                                    IsException  = true,
                                    IsValidation = false,
                                    IsSuccess    = false,
                            });
                            await context.Response.WriteAsync(result);
                        }

                        #endregion

                        #region Api Not Fount Exception

                        if ( ex is ApiNotFoundException notFoundEx )
                        {
                            var result = JsonSerializer.Serialize(new
                            {
                                    ResultStatus = 1,
                                    Message      = notFoundEx.Message,
                                    IsException  = true,
                                    IsValidation = false,
                                    IsSuccess    = false,
                            });
                            await context.Response.WriteAsync(result);
                        }


                        #endregion

                        #region Role Permissions Error

                        if ( ex is ApiRoleException roleEx )
                        {
                            var result = JsonSerializer.Serialize(new
                            {
                                    ResultStatus = 1,
                                    Message      = roleEx.Message,
                                    IsException  = true,
                                    IsValidation = false,
                                    IsSuccess    = false,
                                    RoleError    = true,
                            });
                            await context.Response.WriteAsync(result);
                        }

                        #endregion
                    }
                });
            });
        }
    }
}