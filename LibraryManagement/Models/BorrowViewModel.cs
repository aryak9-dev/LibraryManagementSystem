using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class BorrowViewModel
    {
        public int BookId { get; set; }

        public string? BookTitle { get; set; }

        [Required]
        public string? BorrowerName { get; set; }

        [Required]
        [EmailAddress]
        public string? BorrowerEmail { get; set; }

        [Required]
        public string? Phone { get; set; }
    }
}