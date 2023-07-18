using Microsoft.AspNetCore.Mvc;
using MVC_BookRegistration_Project.Models;
using System.Diagnostics;

namespace MVC_BookRegistration_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        //public HomeController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        public IActionResult AddBook()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Index()
        {
            var books = _context.Books.ToList();
            return View(books);
        }

        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public IActionResult UpdateBook(int ID)
        {
            var UpdatedBook = _context.Books.Find(ID);
            return View(UpdatedBook);
        }

        [HttpPost]
        public IActionResult UpdateBook(Book book)
        {
            _context.Update(book);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteBook(int ID)
        {
            var Deleted_Book = await _context.Books.FindAsync(ID);
            _context.Remove(Deleted_Book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
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
}