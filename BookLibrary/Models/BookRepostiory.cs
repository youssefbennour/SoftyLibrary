using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Models
{
    public class BookRepostiory: IBookRepository
    {

        private readonly BookAppDbContext _context;

        public BookRepostiory(BookAppDbContext context) {
            _context = context;
        }
        public async Task<IEnumerable<Book>> GetAll()
        {
            var list = await _context.Books.Include(book => book.Author).ToListAsync();
            return list;
        }

        public async Task<Book?> GetBook(int bookId)
        {
            return await _context.Books.FirstOrDefaultAsync(book => book.Id == bookId);
        }

        public void AddBook(Book book)
        {
            _context.Books.Add(book);
        }

        public void UpdateBook(Book book)
        {
            _context.Update(book);
        }

        public void RemoveBook(int bookId)
        {
            _context.Remove(GetBook(bookId));
        }
        public async Task<bool> SaveChangesAsync()
        {
            if(await _context.SaveChangesAsync()>0) 
                return true;

            return false;
        }
       
    }
}
