using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class Publication
    {
        [Key]
        public int PublicationId { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Publisher { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime PublishedDate { get; set; }

        [Required]
        public PublicationType Type { get; set; }

        [Range(1,1000)]
        public int TotalCopies { get; set; }

        public int AvailableCopies { get; set; }
    }
}