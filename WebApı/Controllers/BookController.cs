using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Entities.Models;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost]
        [Authorize(Roles = "Librarian")]
        public IActionResult AddBook([FromBody] Book book)
        {
            if (book == null)
            {
                return BadRequest("Book is null.");
            }

            var createdBook = _bookService.CreateBook(book);
            return CreatedAtAction(nameof(GetBookById), new { id = createdBook.BookId }, createdBook);
        }

        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _bookService.GetBookById(id, trackChanges: false);
            return book != null ? Ok(book) : NotFound();
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = _bookService.GetAllBooks(trackChances: true);
            return Ok(books);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Librarian")]
        public IActionResult UpdateBook(int id, [FromBody] Book book)
        {
            if (book == null)
            {
                return BadRequest("Book is null.");
            }

            book.BookId = id;
            _bookService.UpdateBook(book);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Librarian")]
        public IActionResult DeleteBook(int id)
        {
            var book = _bookService.GetBookById(id, trackChanges: false);
            if (book == null)
            {
                return NotFound();
            }

            _bookService.DeleteBook(book);
            return NoContent();
        }
    }
}