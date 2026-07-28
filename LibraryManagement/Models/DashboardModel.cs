using System.Collections.Generic;

namespace LibraryManagement.Models
{
    public class DashboardModel
    {
        // Statistics
        public int TotalBooks { get; set; }
        public int TotalStudents { get; set; }
        public int TotalLibrarians { get; set; }
        public int TotalPublications { get; set; }

        // Inventory
        public int AvailableBooks { get; set; }
        public int BorrowedBooks { get; set; }

        public int OutOfStockBooks { get; set; }
        public int LowStockBooks { get; set; }

        // Publication Statistics
        public int TotalMagazines { get; set; }
        public int TotalNewspapers { get; set; }

        // Recent Activity
        public List<BorrowRecord> RecentBorrows { get; set; } = new();
        public List<Publication> RecentPublications { get; set; } = new();

        public List<Book> LowStockBookList { get; set; } = new();
    }
}