using Microsoft.AspNetCore.Mvc;
using BankApp.Models;
using BankApp.Data;

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

        public IActionResult Index()
        {
            return View(_context.Customers.ToList());
        }

        public IActionResult Details(int id)
        {
            var result = _context.Customers.Find(id);
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
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var result = _context.Customers.Find(id);
            if (result == null)
            {
                Console.WriteLine($"{nameof(Customer)}: {result}");
                return RedirectToAction("Index");
            }
            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Update(customer);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var result = _context.Customers.Find(id);
            if ( result == null)
            {
                Console.WriteLine($"{nameof(Customer)} not found");
                return RedirectToAction("Index");
            }
            return View(result);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmation(int id)
        {
            var result = _context.Customers.Find(id);
            if (result == null)
            {
                Console.WriteLine("Customer ID does not exist");
                return RedirectToAction("Index");
            }
            _context.Customers.Remove(result);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
