using Microsoft.AspNetCore.Mvc;
using BankApp.Models;
using BankApp.Data;
using Microsoft.EntityFrameworkCore;

// Customer Management Controller
namespace BankApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly AppDbContext _context;
        public CustomerController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Customers.ToListAsync());
        }

        public async Task<IActionResult> Details(int id)
        {
            var result = await _context.Customers.FindAsync(id);
            if (result == null)
            {
                Console.WriteLine("CustomerID not found.");
                return RedirectToAction("Index");
            }
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _context.Customers.FindAsync(id);
            if (result == null)
            {
                Console.WriteLine($"{nameof(Customer)}: {result}");
                return RedirectToAction("Index");
            }
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Update(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _context.Customers.FindAsync(id);
            if (result == null)
            {
                Console.WriteLine($"{nameof(Customer)} not found");
                return RedirectToAction("Index");
            }
            return View(result);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmation(int id)
        {
            var result = await _context.Customers.FindAsync(id);
            if (result == null)
            {
                Console.WriteLine("Customer ID does not exist");
                return RedirectToAction("Index");
            }
            _context.Customers.Remove(result);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
