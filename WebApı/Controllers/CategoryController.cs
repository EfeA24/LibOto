using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Entities.Models;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        [Authorize(Roles = "Librarian")]
        public IActionResult CreateCategory([FromBody] Category category)
        {
            if (category == null)
            {
                return BadRequest("Category is null.");
            }

            var createdCategory = _categoryService.CreateCategory(category);
            return CreatedAtAction(nameof(GetCategoryById), new { id = createdCategory.CategoryId }, createdCategory);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            var category = _categoryService.GetCategoryById(id, trackChanges: false);
            return category != null ? Ok(category) : NotFound();
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var categories = _categoryService.GetAllCategories(trackChanges: false);
            return Ok(categories);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Librarian")]
        public IActionResult UpdateCategory(int id, [FromBody] Category category)
        {
            if (category == null)
            {
                return BadRequest("Category is null.");
            }

            category.CategoryId = id;
            _categoryService.UpdateCategory(category);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Librarian")]
        public IActionResult DeleteCategory(int id)
        {
            var category = _categoryService.GetCategoryById(id, trackChanges: false);
            if (category == null)
            {
                return NotFound();
            }

            _categoryService.DeleteCategory(id);
            return NoContent();
        }
    }
}