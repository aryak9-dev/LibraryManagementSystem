namespace LibraryManagement.Models
{
    public class StudentListViewModel
    {
        public IEnumerable<StudentModel> Students { get; set; } = new List<StudentModel>();

        public string? SearchQuery { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public int PageSize { get; set; } = 5;
    }
}