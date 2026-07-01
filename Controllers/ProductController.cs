using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mini_store.Data;
using mini_store.Models;

namespace mini_store.Controllers;

public class ProductController : Controller
{
    // private const string V = "searchTerm";
    private readonly AppDbContext _context;

    public ProductController(AppDbContext context)
    {
        _context = context;
    }
    [Authorize]
    public IActionResult Index(string searchTerm)
    {
        List<Product>? products;
        // List<Product>? products = _context.Products.ToList();
        var productQuery = _context.Products.AsQueryable();
        if (!string.IsNullOrEmpty(searchTerm))
        {
            productQuery = productQuery.Where(p => p.Name.Contains(searchTerm));
        }

        products = productQuery.ToList();
        //   searchTerm ->remove query string







        return View(products);
    }


    public IActionResult Details(int id)
    {
        Console.WriteLine($"id:{id}");
        Product? product = _context.Products.Find(id);
        if (product == null)
        {
            return NotFound();
        }
        return View(product);
    }
    [HttpGet]
    public IActionResult Create()
    {
        var categories = _context.Categories.ToList();
        ViewBag.categories = categories;
        return View();
    }

    [HttpPost]
    public IActionResult Create(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
        //         return Content("Product created successfully");
        return RedirectToAction("Index");
    }
    // UPDATE
    [HttpGet]
    public IActionResult Update(int id)
    {
        Product? product = _context.Products.Find(id);
        if (product == null)
        {
            return NotFound();
        }
        var categories = _context.Categories.ToList();
        ViewBag.categories = categories;

        return View(product);

    }
    [HttpPost]
    public IActionResult Update(Product product)
    {
        // check if product exists
        Product? existingProduct = _context.Products.Find(product.Id);
        Console.WriteLine($"Console: existingProduct:{existingProduct.CategoryId}");

        if (existingProduct == null)
        {
            return NotFound();
        }
        // Console.WriteLine($"Console: product:{product}");

        // _context.Products.Update(product);

        // existingProduct.CategoryId=product.CategoryId;
        existingProduct.Name = product.Name;
        existingProduct.Price = product.Price;
        existingProduct.CategoryId = product.CategoryId;
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    //     DELETE
    // [HttpDelete]
    public IActionResult Delete(int id)
    {

        var products = _context.Products.Find(id);

        if (products != null)
        {
            _context.Products.Remove(products);
            _context.SaveChanges();
        }

        return RedirectToAction("Index");


    }
}