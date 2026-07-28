using LibraryManagement.Models;
using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Data;
using Microsoft.EntityFrameworkCore;


namespace LibraryManagement.Controllers
{
    public class DashboardController : Controller
    {
        private readonly LibraryContext _context;

        public DashboardController(LibraryContext context)
        {
            _context = context;
        }
        
        public async Task<IActionResult> Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Username")))
            {
                return RedirectToAction("Index", "Login");
            }

            var model = new DashboardModel
            {
                // Main Statistics
                TotalStudents = await _context.Students.CountAsync(),
                TotalBooks = await _context.Books.CountAsync(),
                TotalLibrarians = await _context.Librarians.CountAsync(),
                TotalPublications = await _context.Publications.CountAsync(),

                // Inventory
                AvailableBooks = await _context.Books.SumAsync(b => b.AvailableCopies),
                BorrowedBooks = await _context.Books.SumAsync(b => b.TotalCopies - b.AvailableCopies),

                // Publications
                TotalMagazines = await _context.Publications
                    .CountAsync(p => p.Type == PublicationType.Magazine),

                TotalNewspapers = await _context.Publications
                    .CountAsync(p => p.Type == PublicationType.Newspaper),

                // Recent Borrow Records
                RecentBorrows = await _context.BorrowRecords
                    .Include(b => b.Book)
                    .OrderByDescending(b => b.BorrowDate)
                    .Take(5)
                    .ToListAsync(),

                // Recent Publications
                RecentPublications = await _context.Publications
                    .OrderByDescending(p => p.PublishedDate)
                    .Take(5)
                    .ToListAsync(),

                OutOfStockBooks = _context.Books.Count(b => b.AvailableCopies == 0),
                
                LowStockBooks = _context.Books.Count(b =>
                    b.AvailableCopies > 0 &&
                    b.AvailableCopies <= 2),
                
                LowStockBookList = _context.Books
                    .Where(b => b.AvailableCopies > 0 && b.AvailableCopies <= 2)
                    .OrderBy(b => b.AvailableCopies)
                    .Take(5)
                    .ToList(),                





            };

            return View(model);
        }












    }
}