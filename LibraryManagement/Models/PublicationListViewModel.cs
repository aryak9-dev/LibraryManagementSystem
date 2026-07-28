using System.Collections.Generic;

namespace LibraryManagement.Models
{
    public class PublicationListViewModel
    {
        public IEnumerable<Publication> Publications { get; set; } = new List<Publication>();

        public string? SearchQuery { get; set; }

        public PublicationType? SelectedType { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }
    }
}