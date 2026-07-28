using LibraryManagement.Data;
using LibraryManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Controllers
{
    public class PublicationController : Controller
    {
        private readonly LibraryContext _context;
        private const int PageSize = 5;

        public PublicationController(LibraryContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(
            string? searchQuery,
            PublicationType? type,
            int page = 1)
        {
            var query = _context.Publications.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                query = query.Where(p =>
                    p.Title.Contains(searchQuery) ||
                    p.Publisher.Contains(searchQuery));
            }

            if (type.HasValue)
            {
                query = query.Where(p => p.Type == type.Value);
            }

            int totalItems = await query.CountAsync();

            var publications = await query
                .OrderBy(p => p.Title)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();

            var vm = new PublicationListViewModel
            {
                Publications = publications,
                SearchQuery = searchQuery,
                SelectedType = type,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(totalItems / (double)PageSize)
            };

            return View(vm);
        }


        // GET: Publication/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var publication = await _context.Publications
                .FirstOrDefaultAsync(m => m.PublicationId == id);

            if (publication == null)
                return NotFound();

            return View(publication);
        }


        // GET: Publication/Create
        public IActionResult Create()
        {
            return View();
        }
        
        
        // POST: Publication/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Publication publication)
        {
            if (ModelState.IsValid)
            {
                publication.AvailableCopies = publication.TotalCopies;
        
                _context.Add(publication);
                await _context.SaveChangesAsync();
        
                return RedirectToAction(nameof(Index));
            }
        
            return View(publication);
        }
        
        
        // GET: Publication/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();
        
            var publication = await _context.Publications.FindAsync(id);
        
            if (publication == null)
                return NotFound();
        
            return View(publication);
        }
        
        
        // POST: Publication/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Publication publication)
        {
            if (id != publication.PublicationId)
                return NotFound();
        
            if (ModelState.IsValid)
            {
                var existingPublication = await _context.Publications.FindAsync(id);
        
                if (existingPublication == null)
                    return NotFound();
        
                int borrowedCopies =
                    existingPublication.TotalCopies -
                    existingPublication.AvailableCopies;
        
                if (publication.TotalCopies < borrowedCopies)
                {
                    ModelState.AddModelError(
                        "TotalCopies",
                        $"Total Copies cannot be less than borrowed copies ({borrowedCopies}).");
        
                    return View(publication);
                }
        
                existingPublication.Title = publication.Title;
                existingPublication.Publisher = publication.Publisher;
                existingPublication.PublishedDate = publication.PublishedDate;
                existingPublication.Type = publication.Type;
        
                existingPublication.AvailableCopies =
                    publication.TotalCopies - borrowedCopies;
        
                existingPublication.TotalCopies =
                    publication.TotalCopies;
        
                await _context.SaveChangesAsync();
        
                return RedirectToAction(nameof(Index));
            }
        
            return View(publication);
        }
        
        
        // GET: Publication/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
        
            var publication = await _context.Publications
                .FirstOrDefaultAsync(m => m.PublicationId == id);
        
            if (publication == null)
                return NotFound();
        
            return View(publication);
        }
        
        
        // POST: Publication/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var publication = await _context.Publications.FindAsync(id);
        
            if (publication != null)
            {
                _context.Publications.Remove(publication);
                await _context.SaveChangesAsync();
            }
        
            return RedirectToAction(nameof(Index));
        }
        
        private bool PublicationExists(int id)
        {
            return _context.Publications.Any(e => e.PublicationId == id);
        }










    }
}