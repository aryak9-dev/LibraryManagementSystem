using LibraryManagement.Data;
using LibraryManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Controllers
{
    public class LoginController : Controller
    {
        private readonly LibraryContext _context;

        public LoginController(LibraryContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Verify(LoginModel model)
        {
            if (!ModelState.IsValid)
                return View("Index", model);

            var user = await _context.Logins.FirstOrDefaultAsync(x =>
                x.Username == model.Username &&
                x.Password == model.Password);

            if (user == null)
            {
                ViewBag.Message = "Invalid Username or Password";
                return View("Index", model);
            }

            HttpContext.Session.SetString("Username", user.Username!);
            return RedirectToAction("Index", "Dashboard");
            // return RedirectToAction("Index", "Books");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            
            return RedirectToAction("Index");
        }
    }
}