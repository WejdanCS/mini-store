using Microsoft.AspNetCore.Mvc;
using mini_store.Models;
using mini_store.Data;

namespace mini_store.Controllers
{
    public class CategoryController(AppDbContext cn) : Controller
    {
        private readonly AppDbContext _context = cn;

        public IActionResult Index()
        {

            var categories = _context.Categories.ToList();
            return View(categories);
        }


        [HttpPost]
        public IActionResult Create(Category category)
        {
            _context.Categories.Add(category);

            _context.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}