using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookLibrary.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; } = null!;
        public string Image{get;set;} = string.Empty;
        public Category? category { get; set; }
    }
}
