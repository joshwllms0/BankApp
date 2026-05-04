using Microsoft.AspNetCore.Mvc;
using BankApp.Models;
using BankApp.Data;

// Product Management Controller
namespace BankApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context; 
        }

        public IActionResult Index()
        {
            return View(_context.Products.ToList());
        }

        public IActionResult Details(int id)
        {
            var productSelection = _context.Products.Find(id);
            if (productSelection == null)
            {
                Console.WriteLine("Product ID not found.");
                return RedirectToAction("Index");
            }
            return View(productSelection);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var result = _context.Products.Find(id);
            if (result == null)
            {
                Console.WriteLine("ID not found.");
                return RedirectToAction("Index");
            }
            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Update(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var result = _context.Products.Find(id);
            if (result == null)
            {
                Console.WriteLine($"Product {id} not found");
                return RedirectToAction("Index");
            }
            return View(result);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmation(int id)
        {
            var result = _context.Products.Find(id);
            if (result == null) 
            {
                Console.WriteLine("ID not found");
                return RedirectToAction("Index");
            }
            _context.Products.Remove(result);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
