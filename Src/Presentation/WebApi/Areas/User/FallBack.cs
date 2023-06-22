using Microsoft.AspNetCore.Mvc;

namespace WebApi.Areas.User;

public class FallBack : Controller
{
    // GET
    public IActionResult Index()
    {
        var route = Request.Path.Value;
        var check = route.Contains("admin");
        if(route.Contains("admin")) return PhysicalFile(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/admin","index.html"), "text/HTML");
        return PhysicalFile(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/cactus","index.html"), "text/HTML");
    }
}