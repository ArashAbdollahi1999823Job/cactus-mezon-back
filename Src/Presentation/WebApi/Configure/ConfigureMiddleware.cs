#region MyRegion

using WebApi.Extensions;
using WebApi.Middlewares;

namespace WebApi.Configure;
#endregion    
public static class ConfigureMiddleware
{
    public static async Task<WebApplication> AddWebMiddleware(this WebApplication app)
    {
        app.UseMiddleware<MiddlewareExceptionHandler>();
        if (app.Environment.IsDevelopment())
        {
           
            app.UseSwaggerDocumentation();
        }
        app.UseRouting();
        //CorsPolicy
        app.UseCors("CorsPolicy");
        app.UseAuthorization();
        app.UseAuthorization();
        app.MapAreaControllerRoute(
            name: "MyAdmin",
            areaName: "Admin",
            pattern: "Api/{area}/{controller=Home}/{action=Index}/{id?}");
        app.MapAreaControllerRoute(
            name: "MyUser",
            areaName: "User",
            pattern: "Api/{area}/{controller=Home}/{action=Index}/{id?}");
        app.MapControllers();
        app.UseStaticFiles();
        await app.RunAsync();
        return app;
    }
}

