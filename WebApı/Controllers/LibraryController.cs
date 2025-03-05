using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Entities.Models;

namespace WebApı.Controllers
{
    public class LibraryController : Controller
    {
        private readonly HttpClient _httpClient;

        public LibraryController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public IActionResult Index() => View();

        public async Task<IActionResult> Books()
        {
            try
            {
                var books = await _httpClient.GetFromJsonAsync<IEnumerable<Book>>("https://localhost:7194/Library/books");
                return View(books);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error fetching books.";
                return View(Enumerable.Empty<Book>());
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(Book book)
        {
            if (!ModelState.IsValid) return View(book);
            try
            {
                var response = await _httpClient.PostAsJsonAsync("https://localhost:7194/Library/books", book);
                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Book added successfully!";
                    return RedirectToAction(nameof(Books));
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error creating book.";
            }
            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBook(Book book)
        {
            if (!ModelState.IsValid) return View(book);
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"https://localhost:7194/Library/books/{book.BookId}", book);
                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Book updated successfully!";
                    return RedirectToAction(nameof(Books));
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error updating book.";
            }
            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBook(int bookId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"https://localhost:7194/Library/books/{bookId}");
                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Book deleted successfully!";
                    return RedirectToAction(nameof(Books));
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error deleting book.";
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(User user)
        {
            if (!ModelState.IsValid) return View(user);
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"https://localhost:7194/Library/users/{user.Id}", user);
                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "User updated successfully!";
                    return RedirectToAction(nameof(User));
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error updating user.";
            }
            return View(user);
        }
    }
}
