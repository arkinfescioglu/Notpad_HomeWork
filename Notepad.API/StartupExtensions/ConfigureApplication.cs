using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Notepad.Utilities.Exceptions;

namespace Notepad.API.StartupExtensions
{
    public static class ConfigureApplication
    {
        public static IApplicationBuilder ConfigureApplications(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if ( env.IsDevelopment() )
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                        {
                            c.SwaggerEndpoint("/swagger/v1/swagger.json", "NotHut.Api v1");
                            c.DisplayRequestDuration(); // Controls the display of the request duration (in milliseconds) for "Try it out" requests.
                            c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
                            c.ShowCommonExtensions();
                            c.ShowExtensions();
                        }
                );
            }

            app.CustomUseExceptionHandle();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            return app;
        }
    }
}