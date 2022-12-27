using DataAccessPronia.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Areas.Adminn.Controllers;
[Area("Adminn")]
public class ShippingItenController : Controller
{
    private AppDbContext _context;
    public ShippingItenController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.ShippingItems);
    }
    public async Task<IActionResult> Detail(int id)
    {
        var model=await _context.ShippingItems.FindAsync(id);
        return View(model);
    }
    public IActionResult Update(int id)
    {
        return View();
    }
    public IActionResult Delete(int id)
    {
        return View();
    }
}
