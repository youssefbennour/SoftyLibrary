namespace BookLibrary.Models
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAll();
        Task<Book?> GetBook(int? bookId);
        void AddBook(Book book);
        void UpdateBook(Book book);
        Task RemoveBook(int bookId);

        Task<bool> SaveChangesAsync();
    }
}
