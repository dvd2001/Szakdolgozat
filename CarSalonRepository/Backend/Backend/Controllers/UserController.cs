using Backend.DTOs;
using Backend.Services;
using Backend.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Microsoft.AspNetCore.Cors;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("allowedOrigins")]
    public class UserController(IUserService userService) : ControllerBase
    {
        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="user"></param>
        /// <response code="201">User created successfully.</response>
        /// <response code="400">Bad request. Invalid user data.</response>
        [HttpPut(Name =nameof(CreateUser))]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUser(CreateUserDTO user)
        {
            try
            {
                var result = await userService.CreateUser(user);
                return Created($"api/User/{result.UserId}", result);
            }
            catch(RepositoryException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Get all users.
        /// </summary>
        /// <response code="200">Users retrieved successfully.</response>
        [HttpGet(Name = nameof(GetAllUsers))]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await userService.GetAllUsers();
            return Ok(result);
        }
        /// <summary>
        /// Get a user by its ID.
        /// </summary>
        /// <param name="userId"></param>
        /// <response code="200">User retrieved successfully.</response>
        /// <response code="404">User not found.</response>
        [HttpGet("{userId}", Name = nameof(GetUserById))]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserById(Guid userId)
        {
            try
            {
                var result = await userService.GetUserById(userId);
                return Ok(result);
            }
            catch (RepositoryException ex)
            {
                return NotFound(ex.Message);
            }
        }
        /// <summary>
        /// Edits a user.
        /// </summary>
        /// <param name="user"></param>
        /// <response code="200">User edited successfully.</response>
        /// <response code="404">User not found.</response>
        [HttpPut("{userId}", Name = nameof(EditUser))]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EditUser(EditUserDTO user)
        {
            try
            {
                var result = await userService.EditUser(user);
                return Ok(result);
            }
            catch(RepositoryException ex)
            {
                return NotFound(ex.Message);
            }
        }
        /// <summary>
        /// Deletes User by its ID.
        /// </summary>
        /// <param name="userId">The unique identifier of the user to delete.</param>
        /// <response code="200">User deleted successfully.</response>
        /// <response code="404">User not found.</response>
        [HttpDelete("{userId}", Name = nameof(DeleteUser))]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUser(Guid userId)
        {
            try
            {
                var result = await userService.DeleteUserById(userId);
                return Ok(result);
            }
            catch (RepositoryException ex)
            {
                return NotFound(ex.Message);
            }
        }
        /// <summary>
        /// Deletes all users
        /// </summary>
        /// <response code="200">All users deleted successfully.</response>
        [HttpDelete(Name = nameof(DeleteAllUsers))]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteAllUsers()
        {
            var result = await userService.DeleteAllUsers();
            return Ok(result);
        }
        /// <summary>
        /// Login a user.
        /// </summary>
        /// <param name="login"></param>
        /// <response code="200">User logged in successfully.</response>
        /// <response code="401">Unauthorized. Invalid username or password.</response>
        [HttpPost("login", Name = nameof(Login))]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login(LoginDTO login)
        {
            try
            {
                var result = await userService.Login(login.Username, login.Password);
                return Ok(result);
            }
            catch (RepositoryException ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}
