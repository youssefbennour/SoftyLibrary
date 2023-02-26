namespace BookLibrary.Data.FileManager
{
    public interface IFileManager
    {
        Task<string> SaveImage(IFormFile image);
    }
}
