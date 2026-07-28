using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class Book
    {
        
        public int BookId { get; set; }

        [Required(ErrorMessage = "The Title field is required.")]
        [StringLength(100)]
        public string? Title { get; set; }

        [Required(ErrorMessage = "The Author field is required.")]
        [StringLength(100)]
        public string? Author { get; set; }

        
        [Required(ErrorMessage = "The ISBN field is required.")]
        [RegularExpression(@"^\d{3}-\d{10}$",
            ErrorMessage = "ISBN must be in the format XXX-XXXXXXXXXX.")]
        public string? ISBN { get; set; }

        
        [Required]
        [DataType(DataType.Date)]
        public DateTime PublishedDate { get; set; }

        
        [Required]
        [Range(1, 1000, ErrorMessage = "Total copies must be at least 1.")]
        public int TotalCopies { get; set; }
        
        
        [Required]
        [Range(0, 1000, ErrorMessage = "Available Copies cannot be changed.")]
        public int AvailableCopies { get; set; }

        [BindNever]
        public ICollection<BorrowRecord>? BorrowRecords { get; set; }
    }
}