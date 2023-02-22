using BookLibrary.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookLibrary.ViewModels
{
    public class BookViewModel
    {
        [Required, StringLength(250)]
        public string BookName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [Required]
        public string AuthorName { get; set; } = string.Empty;
        [Required]
        [DisplayName("Category")]
        public Category? CategoryName { get; set; }
    }
}
