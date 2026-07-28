using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryManagement.Data;
using LibraryManagement.Models;

namespace LibraryManagement.Controllers;

public class BooksController : Controller
{
    private readonly LibraryContext _context;

    public BooksController(LibraryContext context)
    {
        _context = context;
    }

    // GET: Books
    public async Task<IActionResult> Index(string? searchQuery, int page = 1)
    {
        if (string.IsNullOrEmpty(HttpContext.Session.GetString("Username")))
        {
            return RedirectToAction("Index", "Login");
        }
    
        const int pageSize = 5;
    
        IQueryable<Book> booksQuery = _context.Books;
    
        // Search
        if (!string.IsNullOrWhiteSpace(searchQuery))
        {
            searchQuery = searchQuery.Trim();
    
            booksQuery = booksQuery.Where(b =>
                b.Title.Contains(searchQuery) ||
                b.Author.Contains(searchQuery) ||
                b.ISBN.Contains(searchQuery));
        }
    
        int totalBooks = await booksQuery.CountAsync();
    
        var books = await booksQuery
            .OrderBy(b => b.BookId)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    
        var viewModel = new BookListViewModel
        {
            Books = books,
            SearchQuery = searchQuery,
            CurrentPage = page,
            TotalPages = (int)Math.Ceiling(totalBooks / (double)pageSize),
            PageSize = pageSize
        };
    
        return View(viewModel);
    }




    // GET: Books/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
            return NotFound();

        var book = await _context.Books.FirstOrDefaultAsync(m => m.BookId == id);

        

        if (book == null)
            return NotFound();


        return View(book);

    }

    // GET: Books/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Books/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Book book)
    {

        
              
        if (ModelState.IsValid)
        {
            book.AvailableCopies = book.TotalCopies;
            _context.Add(book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(book);
    }

    // GET: Books/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
            return NotFound();

        var book = await _context.Books.FindAsync(id);

        if (book == null)
            return NotFound();

        return View(book);
    }

    // POST: Books/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
public async Task<IActionResult> Edit(int id, Book book)
{
    if (id != book.BookId)
        return NotFound();


    var existingBook = await _context.Books.AsNoTracking().FirstOrDefaultAsync(b => b.BookId == id);

    if (existingBook == null)
    {   
        return NotFound();
    }

    int borrowedCopies = existingBook.TotalCopies - existingBook.AvailableCopies;
    

    if (book.TotalCopies < borrowedCopies)
    {
        ModelState.AddModelError(
            nameof(book.TotalCopies),
            $"Total copies cannot be less than borrowed copies ({borrowedCopies})."
        );

        return View(book);
    }
    else
    {
        book.AvailableCopies = book.TotalCopies - borrowedCopies;
    }
    

    if (!ModelState.IsValid)
        return View(book);

    try
    {
        _context.Update(book);
        await _context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
        if (!_context.Books.Any(e => e.BookId == id))
            return NotFound();

        throw;
    }

    return RedirectToAction(nameof(Index));
}

// GET: Books/Borrow/5
public async Task<IActionResult> Borrow(int? id)
{
    if (id == null)
        return NotFound();

    var book = await _context.Books.FindAsync(id);

    if (book == null || book.AvailableCopies <= 0)
        return NotFound();

    var vm = new BorrowViewModel
    {
        BookId = book.BookId,
        BookTitle = book.Title
    };

    return View(vm);
}

// POST: Books/Borrow
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Borrow(BorrowViewModel vm)
{
    if (!ModelState.IsValid)
        return View(vm);

    var book = await _context.Books.FindAsync(vm.BookId);

    if (book == null)
        return NotFound();

    var record = new BorrowRecord
    {
        BookId = vm.BookId,
        BorrowerName = vm.BorrowerName,
        BorrowerEmail = vm.BorrowerEmail,
        Phone = vm.Phone,
        BorrowDate = DateTime.Now
    };

    book.AvailableCopies--;

    _context.BorrowRecords.Add(record);

    await _context.SaveChangesAsync();

    return RedirectToAction(nameof(Index));
}

    // GET: Books/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
            return NotFound();

        var book = await _context.Books.FirstOrDefaultAsync(m => m.BookId == id);

        if (book == null)
            return NotFound();

        return View(book);
    }

    // POST: Books/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var book = await _context.Books.FindAsync(id);

        if (book != null)
            _context.Books.Remove(book);

        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}