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
        public IActionResult Cancel() 
        {
            return RedirectToAction("Index", "Home");    
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
                Author = new Author() 
                {
                    Name = bookViewModel.AuthorName,
                },
                category = bookViewModel.CategoryName,
            };
            _bookRepository.AddBook(newBook);
            await _bookRepository.SaveChangesAsync();
            return RedirectToAction("Index", "Home", new { area = "" });
        }


        public async Task<IActionResult> Edit(int? id) {
            Book? book = await _bookRepository.GetBook(id);

            if (book == null) return View("Index", "Home");

            var bookViewModel = new BookViewModel() { 
                BookName = book.Name,
                Description = book.Description,
                AuthorName = book.Author.Name,
                CategoryName = book.category
            };
            return View(bookViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, BookViewModel bookViewModel) {
            
            if (!ModelState.IsValid) {
                return View(bookViewModel);
            }

            var book = new Book() {
                Id = id,
                Name = bookViewModel.BookName,
                Description = bookViewModel.Description,
                Author = new Author() { Name = bookViewModel.AuthorName },
                category = bookViewModel.CategoryName
            };

            _bookRepository.UpdateBook(book);
            await _bookRepository.SaveChangesAsync();
            return RedirectToAction("Index", "Home", new { area = ""});
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _bookRepository.RemoveBook(id);
            await _bookRepository.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
