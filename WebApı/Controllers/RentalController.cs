using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Entities.Models;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentalController : ControllerBase
    {
        private readonly IRentalService _rentalService;

        public RentalController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpPost]
        [Authorize(Roles = "User ")]
        public IActionResult RentBook([FromBody] Rental rental)
        {
            if (rental == null)
            {
                return BadRequest("Rental is null.");
            }

            rental.IsApproved = false;
            var createdRental = _rentalService.CreateRental(rental);
            return CreatedAtAction(nameof(GetRentalById), new { id = createdRental.RentId }, createdRental);
        }

        [HttpGet("{id}")]
        public IActionResult GetRentalById(int id)
        {
            var rental = _rentalService.GetRentalById(id);
            return rental != null ? Ok(rental) : NotFound();
        }

        [HttpGet("user/{userId}")]
        [Authorize(Roles = "User ")]
        public IActionResult GetRentalsByUser(string userId)
        {
            var rentals = _rentalService.GetRentalByUser(userId);
            return Ok(rentals);
        }

        [HttpPut("return/{id}")]
        [Authorize(Roles = "User ")]
        public IActionResult ReturnBook(int id)
        {
            var rental = _rentalService.GetRentalById(id);
            if (rental == null)
            {
                return NotFound();
            }

            rental.ReturnDate = DateTime.UtcNow;
            rental.IsApproved = true;
            _rentalService.UpdateRental(rental);
            return NoContent();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllRentals()
        {
            var rentals = _rentalService.GeAlltRentedBooks(trackChanges: false);
            return Ok(rentals);
        }
    }
}