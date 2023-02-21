using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;    
        public virtual List<Book> Books { get; set;} = new List<Book>();
    }
}   
