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

        public LibraryController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Books()
        {
            var books = await _httpClient.GetFromJsonAsync<IEnumerable<Book>>("https://localhost:7194/api/books");
            return View(books);
        }

        public async Task<IActionResult> Categories()
        {
            var categories = await _httpClient.GetFromJsonAsync<IEnumerable<Category>>("https://localhost:7194/api/categories");
            return View(categories);
        }

        public async Task<IActionResult> Rentals()
        {
            var rentals = await _httpClient.GetFromJsonAsync<IEnumerable<Rental>>("https://localhost:7194/api/rentals");
            return View(rentals);
        }

        public async Task<IActionResult> Users()
        {
            var users = await _httpClient.GetFromJsonAsync<IEnumerable<User>>("https://localhost:7194/api/users");
            return View(users);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(Book book)
        {
            if (ModelState.IsValid)
            {
                var response = await _httpClient.PostAsJsonAsync("https://localhost:7194/api/books", book);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Books));
                }
            }
            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                var response = await _httpClient.PostAsJsonAsync("https://localhost:7194/api/categories", category);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Categories));
                }
            }
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBook(Book book)
        {
            if (ModelState.IsValid)
            {
                var response = await _httpClient.PutAsJsonAsync($"https://localhost:7194/api/books/{book.BookId}", book);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Books));
                }
            }
            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                var response = await _httpClient.PutAsJsonAsync($"https://localhost:7194/api/categories/{category.CategoryId}", category);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Categories));
                }
            }
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBook(int bookId)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7194/api/books/{bookId}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Books));
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7194/api/categories/{categoryId}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Categories));
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRental(Rental rental)
        {
            if (ModelState.IsValid)
            {
                var response = await _httpClient.PutAsJsonAsync($"https://localhost:7194/api/rentals/{rental.RentId}", rental);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Rentals));
                }
            }
            return View(rental);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteRental(int rentalId)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7194/api/rentals/{rentalId}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Rentals));
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(User user)
        {
            if (ModelState.IsValid)
            {
                var response = await _httpClient.PutAsJsonAsync($"https://localhost:7194/api/users/{user.FullName}", user);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Users));
                }
            }
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7194/api/users/{userId}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Users));
            }
            return BadRequest();
        }
    }
}

/*       <div class="card">
            <h3>Available Books</h3>
            <ul>
                @foreach (var book in Model.Books)
                {
                    <li>@book.Title by @book.Author</li>
                }
            </ul>
        </div>

        <div class="card">
            <h3>Categories</h3>
            <ul>
                @foreach (var category in Model.Categories)
                {
                    <li>@category.CategoryName</li>
                }
            </ul>
        </div>
*/