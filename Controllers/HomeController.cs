using CorePronia.Entities;
using DataAccessPronia.Contexts;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers;

public class HomeController : Controller
{
    private AppDbContext _context;
    public HomeController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        HomeVM home = new()
        {
            SlideItems = _context.SlideItems,
            ShippingItems = _context.ShippingItems,

        };
        return View(home);
    }
}
