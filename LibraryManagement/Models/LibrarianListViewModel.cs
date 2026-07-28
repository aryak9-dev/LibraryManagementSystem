namespace LibraryManagement.Models
{
    public class LibrarianListViewModel
    {
        public IEnumerable<LibrarianModel> Librarians { get; set; } = new List<LibrarianModel>();

        public string? SearchQuery { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public int PageSize { get; set; } = 5;
    }
}