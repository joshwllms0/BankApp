using Microsoft.AspNetCore.Mvc;
using BankApp.Models;
using BankApp.Data;
using Microsoft.EntityFrameworkCore;

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
        
        public async Task<IActionResult> Index()
        {
            return View(await _context.Books.ToListAsync());
        }

        public async Task<IActionResult> Details(int id)
        {
            var bookid = await _context.Books.FindAsync(id);
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
        public async Task<IActionResult> Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _context.Books.FindAsync(id);
            if (result == null)
            {
                Console.WriteLine("Book ID not found");
                return RedirectToAction("Index");
            }
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Update(book);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _context.Books.FindAsync(id);
            if (result == null)
            {
                Console.WriteLine("Book ID not found");
                return RedirectToAction("Index");
            }
            return View(result);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmation(int id)
        {
            var result = await _context.Books.FindAsync(id);
            if (result == null)
            {
                Console.WriteLine("Book ID not found");
                return RedirectToAction("Index");
            }
            _context.Books.Remove(result);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
