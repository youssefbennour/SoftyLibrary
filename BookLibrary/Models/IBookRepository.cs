namespace BookLibrary.Models
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAll();
        Task<Book?> GetBook(int bookId);
        void AddBook(Book book);
        void UpdateBook(Book book);
        void RemoveBook(int bookId);

        Task<bool> SaveChangesAsync();
    }
}
