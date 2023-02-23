using BookLibrary.Models;
using BookLibrary.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookLibrary.Controllers {
    public class BookController : Controller {

        private readonly IBookRepository _bookRepository;
        public BookController(ILogger<HomeController> logger, IBookRepository bookRepository) {
            _bookRepository = bookRepository;
        }
        public IActionResult Index() {
            return View();
        }


        public IActionResult Create() {
            return View();    
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookViewModel bookViewModel) {
            if (!ModelState.IsValid) {
                return View(bookViewModel);
            }

            Book newBook = new Book() {
                Name = bookViewModel.BookName,
                Description = bookViewModel.Description,
                Author = new Author() {
                    Name = bookViewModel.AuthorName,
                },
                category = bookViewModel.CategoryName,
            };
            _bookRepository.AddBook(newBook);
            await _bookRepository.SaveChangesAsync();
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error() {
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
