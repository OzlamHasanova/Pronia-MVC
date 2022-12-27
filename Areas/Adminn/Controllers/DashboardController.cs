using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Areas.Adminn.Controllers;

[Area("Adminn")]
public class DashboardController : Controller
{
    public IActionResult Index()
    {
        return View();
    }       
    
    public IActionResult Test()
    {
        return View();
    }
}
