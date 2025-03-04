using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Entities.Models;
using Services.Implementations;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("User  is null.");
            }

            var createdUser = _userService.CreateUser(user);
            return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(string id)
        {
            var user = _userService.GetUserByName(id, trackChanges: false);
            return user != null ? Ok(user) : NotFound();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers(trackChanges: false);
            return Ok(users);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateUser(string id, [FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("User  is null.");
            }

            _userService.UpdateUser(id, user, trackChanges: true);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteUser(string id)
        {
            _userService.DeleteUser(id, trackChanges: false);
            return NoContent();
        }


        [HttpPost("reject/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult RejectUser(string id)
        {
            var user = _userService.GetUserByName(id, trackChanges: false);
            if (user == null)
            {
                return NotFound();
            }

            _userService.DeleteUser(id, trackChanges: false);
            return NoContent();
        }
    }
}