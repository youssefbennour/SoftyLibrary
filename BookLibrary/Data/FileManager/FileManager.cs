using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Data.FileManager
{
    public class FileManager:IFileManager
    {
        private string _imagePath { get; set; }

        public FileManager(IConfiguration config)
        {
            _imagePath = config["Path:Images"]!;
        }   

        public async Task<string> SaveImage(IFormFile image)
        {

            try
            {
                var savingDirectory = Path.Combine(_imagePath);
                if (Directory.Exists(savingDirectory))
                {
                    Directory.CreateDirectory(savingDirectory);
                }

                var mime = image.FileName.Substring(image.FileName.LastIndexOf('.'));
                var fileName = $"img_{DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss")}{mime}";

                using (var fileStream = new FileStream(Path.Combine(savingDirectory, fileName), FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }
                return fileName;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "Error";
            }
        }
    }
}
