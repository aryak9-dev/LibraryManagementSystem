using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryManagement.Data;
using LibraryManagement.Models;

namespace LibraryManagement.Controllers;

public class BorrowRecordsController : Controller
{
    private readonly LibraryContext _context;

    public BorrowRecordsController(LibraryContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var records = await _context.BorrowRecords
            .Include(b => b.Book)
            .ToListAsync();

        return View(records);
    }

    // GET: BorrowRecords/Return/5
    public async Task<IActionResult> Return(int id)
    {
        var borrowRecord = await _context.BorrowRecords
            .Include(br => br.Book)
            .FirstOrDefaultAsync(br => br.BorrowRecordId == id);

        if (borrowRecord == null)
        {
            return NotFound();
        }

        if (borrowRecord.ReturnDate != null)
        {
            return View("AlreadyReturned");
        }

        return View(borrowRecord);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Return(BorrowRecord model)
    {
        var borrowRecord = await _context.BorrowRecords
            .Include(br => br.Book)
            .FirstOrDefaultAsync(br => br.BorrowRecordId == model.BorrowRecordId);
    
        if (borrowRecord == null)
        {
            return NotFound();
        }
    
        if (borrowRecord.ReturnDate != null)
        {
            return View("AlreadyReturned");
        }
    
        borrowRecord.ReturnDate = DateTime.Now;
    
        if (borrowRecord.Book.AvailableCopies < borrowRecord.Book.TotalCopies)
        {
            borrowRecord.Book.AvailableCopies++;
        }
    
        await _context.SaveChangesAsync();
    
        TempData["Success"] = "Book returned successfully.";
    
        return RedirectToAction(nameof(Index));
    }
}