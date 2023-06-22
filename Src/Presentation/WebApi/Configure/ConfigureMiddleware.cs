using WebApi.Extensions;
using WebApi.Middlewares;
using WebApi.SignalR;
namespace WebApi.Configure;
 
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
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseEndpoints(endpoint =>
        {
            endpoint.MapFallbackToController("Index","FallBack");
            endpoint.MapHub<PresenceHub>("hubs/presence");
            endpoint.MapHub<ChatHub>("hubs/chat");
            endpoint.MapAreaControllerRoute(
                name: "MyAdmin",
                areaName: "Admin",
                pattern: "Api/{area}/{controller=Home}/{action=Index}/{id?}");
            endpoint.MapAreaControllerRoute(
                name: "MyUser",
                areaName: "User",
                pattern: "Api/{area}/{controller=Home}/{action=Index}/{id?}");
            endpoint.MapControllers();
        });
        app.UseDefaultFiles();
        app.UseStaticFiles();
        await app.RunAsync();
        return app;
    }
}

