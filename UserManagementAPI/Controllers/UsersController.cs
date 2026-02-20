using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.Services;
using UserManagementAPI.Entities;
using UserManagementAPI.DTOs;
using UserManagementAPI.Validations;

namespace UserManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        // GET: api/users
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateUserDto dto)
        {
            var nameValidation = Validation.ValidateName(dto.Name);
            if (!nameValidation.isValid)
            {
                return BadRequest(new { error = nameValidation.errorMessage });
            }

            var ageValidation = Validation.ValidateAge(dto.Age);
            if (!ageValidation.isValid)
            {
                return BadRequest(new { error = ageValidation.errorMessage });
            }

            var emailValidation = Validation.ValidateEmail(dto.Email);
            if (!emailValidation.isValid)
            {
                return BadRequest(new { error = emailValidation.errorMessage });
            }

            var user = new User(dto.Name, dto.Age, dto.Email);
            _userService.AddUser(user);

            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var user = _userService.GetUserById(id);

            if (user == null)
            {
                return NotFound(new { error = "User not found" });
            }

            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] UpdateUserDto dto)
        {
            var existingUser = _userService.GetUserById(id);
            if (existingUser == null)
            {
                return NotFound(new { error = "User not found" });
            }

            var nameValidation = Validation.ValidateName(dto.Name);
            if (!nameValidation.isValid)
            {
                return BadRequest(new { error = nameValidation.errorMessage });
            }

            var ageValidation = Validation.ValidateAge(dto.Age);
            if (!ageValidation.isValid)
            {
                return BadRequest(new { error = ageValidation.errorMessage });
            }

            var emailValidation = Validation.ValidateEmail(dto.Email);
            if (!emailValidation.isValid)
            {
                return BadRequest(new { error = emailValidation.errorMessage });
            }

            var updatedUser = new User(existingUser.Id, dto.Name, dto.Age, dto.Email);

            _userService.Update(updatedUser);

            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound(new { error = "User not found" });
            }

            _userService.DeleteUser(user);

            return NoContent();
        }
    }
}