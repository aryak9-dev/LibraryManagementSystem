using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class StudentModel
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        [StringLength(100)]
        public string? StudentName { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [Phone]
        public string? Phone { get; set; }
    }
}