using Microsoft.AspNetCore.Mvc;
using BankApp.Models;
using BankApp.Data;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.ToListAsync());
        }
        
        public async Task<IActionResult> Details(int id)
        {
            var productSelection = await _context.Products.FindAsync(id);
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
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _context.Products.FindAsync(id);
            if (result == null)
            {
                Console.WriteLine("ID not found.");
                return RedirectToAction("Index");
            }
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Update(product);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _context.Products.FindAsync(id);
            if (result == null)
            {
                Console.WriteLine($"Product {id} not found");
                return RedirectToAction("Index");
            }
            return View(result);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmation(int id)
        {
            var result = await _context.Products.FindAsync(id);
            if (result == null) 
            {
                Console.WriteLine("ID not found");
                return RedirectToAction("Index");
            }
            _context.Products.Remove(result);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
