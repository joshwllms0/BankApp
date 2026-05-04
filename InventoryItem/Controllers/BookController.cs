using Microsoft.AspNetCore.Mvc;
using BankApp.Models;
using BankApp.Data;

namespace BankApp.Controllers
{
    // Book Management Controller
    public class BookController : Controller
    {
        private readonly AppDbContext _context;
        public BookController(AppDbContext context)
        {
            _context = context; 
        }
        
        public IActionResult Index()
        {
            return View(_context.Books.ToList());
        }

        public IActionResult Details(int id)
        {
            var bookid = _context.Books.Find(id);
            if (bookid == null)
            {
                Console.WriteLine("BookID does not exist.");
                return RedirectToAction("Index");
            }
            return View(bookid);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Add(book);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var result = _context.Books.Find(id);
            if (result == null)
            {
                Console.WriteLine("Book ID not found");
                return RedirectToAction("Index");
            }
            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Update(book);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var result = _context.Books.Find(id);
            if (result == null)
            {
                Console.WriteLine("Book ID not found");
                return RedirectToAction("Index");
            }
            return View(result);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmation(int id)
        {
            var result = _context.Books.Find(id);
            if (result == null)
            {
                Console.WriteLine("Book ID not found");
                return RedirectToAction("Index");
            }
            _context.Books.Remove(result);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
