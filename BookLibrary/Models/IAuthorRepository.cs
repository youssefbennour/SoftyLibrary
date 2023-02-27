namespace BookLibrary.Models
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAllAsync();
        Task<int> GetAuthorByBookAsync(string AuthorName, string bookName);
        Task<Author?> GetAuthorByIdAsync(int? id);
        Task<bool> SaveChangesAsync();

    }
}
