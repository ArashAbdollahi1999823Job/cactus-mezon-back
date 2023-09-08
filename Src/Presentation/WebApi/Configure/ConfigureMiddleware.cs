using Microsoft.Extensions.FileProviders;
using WebApi.Extensions;
using WebApi.Middlewares;
using WebApi.SignalR;

namespace WebApi.Configure;

public static class ConfigureMiddleware
{
    public static async Task AddWebMiddleware(this WebApplication app)
    {
        app.UseMiddleware<MiddlewareExceptionHandler>();
        if (app.Environment.IsDevelopment())
        {
            app.UseSwaggerDocumentation();
        }

        app.UseRouting();
        app.UseCors("CorsPolicy");
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseDefaultFiles();
        app.UseStaticFiles();
        app.UseEndpoints(endpoint =>
        {
            endpoint.MapFallbackToController("Index", "FallBack");  
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
        app.Map(new PathString("/admin"), client =>
        {
            client.UseSpaStaticFiles(new StaticFileOptions
            {
                FileProvider =
                    new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/admin"))
            });
            client.UseSpa(spa =>
            {
                spa.Options.SourcePath = "wwwroot/admin";
                spa.Options.DefaultPageStaticFileOptions = new StaticFileOptions
                {
                    FileProvider =
                        new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/admin"))
                };
            });
        }).Map(new PathString("/index"),( client) =>
        {
            client.UseSpaStaticFiles(new StaticFileOptions
            {
                FileProvider =
                    new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/index"))
            });
            client.UseSpa(spa =>
            {
                spa.Options.SourcePath = "wwwroot/index";
                spa.Options.DefaultPageStaticFileOptions = new StaticFileOptions
                {
                    FileProvider =
                        new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/index"))
                };
            });
        });
        await app.RunAsync();
    }
}