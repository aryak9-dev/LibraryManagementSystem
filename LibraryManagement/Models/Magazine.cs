using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class Magazine
    {
        [Key]
        public int MagazineId { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Publisher { get; set; } = string.Empty;

        [Required]
        public int IssueNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublicationDate { get; set; }

        [Range(1, 1000)]
        public int TotalCopies { get; set; }

        public int AvailableCopies { get; set; }
    }
}