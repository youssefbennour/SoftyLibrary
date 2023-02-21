using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Models
{
    public class BookAppDbContext : DbContext
    {
        public BookAppDbContext(DbContextOptions<BookAppDbContext> options) : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //}
        public DbSet<Book> Books { get; set;}
        public DbSet<Author> Authors { get; set;}
    }
}
