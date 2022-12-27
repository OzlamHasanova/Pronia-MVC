using CorePronia.Entities;
using DataAccessPronia.Contexts;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Areas.Adminn.ViewModels.Slider;

namespace WebApplication1.Areas.Adminn.Controllers;
[Area("Adminn")]
public class SlideItemController : Controller
{
    private readonly AppDbContext _context;
    private  readonly IWebHostEnvironment _env;
    public SlideItemController(AppDbContext context,IWebHostEnvironment env)
    {
        _context = context;
        _env = env;
    }

    public IActionResult Index()
    {
        return View(_context.SlideItems);
    }
    public async Task<IActionResult> Detail(int id)
    {
        var slide=await _context.SlideItems.FindAsync(id);
        if(slide == null) return NotFound();
        return View(slide);
    }

    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(SlideCreateVM slide)
    {
        if (slide.Photo == null)
        {
            ModelState.AddModelError("Photo", "select photo pls");
            return View(slide);
        }
        if (!ModelState.IsValid)return View(slide);
        //if (slide.Photo.Length / 1024 > 8)
        //{
        //    ModelState.AddModelError("Photo", "image size is bige than 8kb");
        //    return View(slide);
        //}
        if (!slide.Photo.ContentType.Contains("image/"))
        {
            ModelState.AddModelError("Photo", "choose image type");
            return View(slide);
        }
       
        var wwwroot = _env.WebRootPath;
        var filename = Guid.NewGuid().ToString() + slide.Photo.FileName;
        var resultPath = Path.Combine(_env.WebRootPath, "assets", "images","website-images");
       
        //var path = @"C:\\Users\\User\\Desktop\\template\\images\\faces" + slide.Photo.FileName;
        using (FileStream stream=new FileStream(resultPath, FileMode.Create))
        {
            await slide.Photo.CopyToAsync(stream);
        }
        SlideItem slideItem = new()
        {
            Photo = filename,
            Title = slide.Title,
            Offer = slide.Offer,
            Description = slide.Description
        };
        await _context.SlideItems.AddAsync(slideItem);
        await _context.SaveChangesAsync();
        return Content(resultPath);
        //return RedirectToAction(nameof(Index));
        //return Content(filename);
    }
}
