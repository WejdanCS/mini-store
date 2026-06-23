using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mini_store.Models;

namespace mini_store.Controllers;

public class HomeController : Controller
{
        private static  dynamic[]  _categories =
   {
        new { Id = 0, Name = "إلكترونيات", Icon = "fa-solid fa-bolt-lightning" },
        new { Id = 1, Name = "ملابس", Icon = "fa-solid fa-shirt" },
        new { Id = 2, Name = "كتب", Icon = "fas fa-book-open" }
   }; 

 private static  dynamic[] _products  =
{
    new { CategoryId = 0, Name = "هاتف ذكي", Price = 2500, Description = "هاتف ذكي بكاميرا عالية الدقة", Image = "phone.avif" },

    new { CategoryId = 0, Name = "حاسوب محمول", Price = 4500, Description = "حاسوب مخصص للمطورين ram 16gm hard 1TB screen 16hs", Image = "laptop.webp" },

    new { CategoryId = 1, Name = "قميص قطني", Price = 150, Description = "قميص مريح وصيفي", Image = "shirt.webp" },

    new { CategoryId = 2, Name = "كتاب برمجة", Price = 90, Description = "دليل شامل لتعلم البرمجة", Image = "book.webp" }
};
    public IActionResult Index()
    {
        ViewBag.CategoriesList = _categories;
        return View();
    }

    public IActionResult Products(int id)
    {
        var filtered=_products.Where(p=> p.CategoryId==id).ToList();
         ViewBag.Filtered=filtered;
         ViewBag.Category=_categories[id];
        return View();
    }

    public IActionResult Details(string name)
    {
         var product=_products.FirstOrDefault(p=> p.Name== name);
        if (product == null)
        {
            return NotFound();
        }
         ViewBag.Product=product;

        return View();
       
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
