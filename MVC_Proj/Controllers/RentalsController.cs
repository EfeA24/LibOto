using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace YourProject.Mvc.Controllers
{
    public class RentalsController : Controller
    {
        private readonly HttpClient _httpClient;

        public RentalsController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ApiClient");
        }

        // GET: Rentals
        public async Task<IActionResult> Index()
        {
            var rentals = await _httpClient.GetFromJsonAsync<List<Rental>>("/api/rentals");
            return View(rentals);
        }

        // GET: Rentals/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var rental = await _httpClient.GetFromJsonAsync<Rental>($"/api/rentals/{id}");
            if (rental == null)
            {
                return NotFound();
            }
            return View(rental);
        }

        // GET: Rentals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rentals/Create
        [HttpPost]
        public async Task<IActionResult> Create(Rental rental)
        {
            if (ModelState.IsValid)
            {
                var response = await _httpClient.PostAsJsonAsync("/api/rentals", rental);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError(string.Empty, "Unable to create rental.");
            }
            return View(rental);
        }

        // GET: Rentals/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var rental = await _httpClient.GetFromJsonAsync<Rental>($"/api/rentals/{id}");
            if (rental == null)
            {
                return NotFound();
            }
            return View(rental);
        }

        // POST: Rentals/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Rental rental)
        {
            if (id != rental.RentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var response = await _httpClient.PutAsJsonAsync($"/api/rentals/{id}", rental);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError(string.Empty, "Unable to update rental.");
            }
            return View(rental);
        }

        // GET: Rentals/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var rental = await _httpClient.GetFromJsonAsync<Rental>($"/api/rentals/{id}");
            if (rental == null)
            {
                return NotFound();
            }
            return View(rental);
        }

        // POST: Rentals/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/rentals/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
    }
}