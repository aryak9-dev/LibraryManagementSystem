using LibraryManagement.Data;
using LibraryManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Controllers
{
    public class LibrarianController : Controller
    {
        private readonly LibraryContext _context;

        public LibrarianController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Librarian
        public async Task<IActionResult> Index(string? searchQuery, int page = 1)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Username")))
            {
                return RedirectToAction("Index", "Login");
            }
        
            const int pageSize = 5;
        
            IQueryable<LibrarianModel> librariansQuery = _context.Librarians;
        
            // Search
            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                searchQuery = searchQuery.Trim();
        
                librariansQuery = librariansQuery.Where(l =>
                    l.Name.Contains(searchQuery) ||
                    l.Phone.Contains(searchQuery));
            }
        
            int totalLibrarians = await librariansQuery.CountAsync();
        
            var librarians = await librariansQuery
                .OrderBy(l => l.LibrarianId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        
            var viewModel = new LibrarianListViewModel
            {
                Librarians = librarians,
                SearchQuery = searchQuery,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(totalLibrarians / (double)pageSize),
                PageSize = pageSize
            };
        
            return View(viewModel);
        }

        // GET: Librarian/Create
        public IActionResult Create()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Username")))
            {
                return RedirectToAction("Index", "Login");
            }

            return View();
        }

        // POST: Librarian/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LibrarianModel librarian)
        {
            if (!ModelState.IsValid)
                return View(librarian);

            _context.Librarians.Add(librarian);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Librarian/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var librarian = await _context.Librarians.FindAsync(id);

            if (librarian == null)
                return NotFound();

            return View(librarian);
        }

        // POST: Librarian/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LibrarianModel librarian)
        {
            if (id != librarian.LibrarianId)
                return NotFound();

            if (!ModelState.IsValid)
                return View(librarian);

            _context.Update(librarian);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Librarian/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var librarian = await _context.Librarians
                .FirstOrDefaultAsync(l => l.LibrarianId == id);

            if (librarian == null)
                return NotFound();

            return View(librarian);
        }

        // POST: Librarian/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var librarian = await _context.Librarians.FindAsync(id);

            if (librarian != null)
            {
                _context.Librarians.Remove(librarian);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}