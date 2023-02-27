using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Models
{
    public class AuthorRepository: IAuthorRepository
    {
        private readonly BookAppDbContext _context;
        public AuthorRepository(BookAppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await _context.Authors.Include(author => author.Books).ToListAsync();
        }

        public async Task<int> GetAuthorByBookAsync(string authorName, string bookName)
        {
            var book =  await _context.Books.Include(book => book.Author).Where(book => book.Author.Name == authorName).FirstOrDefaultAsync();
            if (book == null) return -1;
            return book.Author.Id;
        }

        public Task<Author?> GetAuthorByIdAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
