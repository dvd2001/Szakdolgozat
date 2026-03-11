using Backend.Services;
using Backend.DTOs;
using Backend.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Microsoft.AspNetCore.Cors;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("allowedOrigins")]
    public class CarController(ICarService carService) : ControllerBase
    {
        /// <summary>
        /// Creates a Car.
        /// </summary>
        /// <param name="car"></param>
        /// <param name="salonId"></param>
        /// <response code="201">Car created successfully</response>
        /// <response code="400">Bad request</response>
        [HttpPut("{salonId}", Name = nameof(CreateCar))]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCar(CreateCarDTO car, Guid salonId)
        {
            try
            {
                var result = await carService.CreateCar(car, salonId);
                return Created($"api/Car/{result.ChassisNumber}", result);
            }
            catch (RepositoryException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Get all Cars.
        /// </summary>
        /// <response code="200">Cars retrieved successfully</response>
        [HttpGet(Name = nameof(GetAllCars))]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllCars()
        {
            var result = await carService.GetAllCars();
            return Ok(result);
        }
        /// <summary>
        /// Get a Car by its ID (ChassisNumber).
        /// </summary>
        /// <param name="carId"></param>
        /// <response code="200">Car retrieved successfully</response>
        /// <response code="404">Car not found</response>
        [HttpGet("{carId}", Name = nameof(GetCarById))]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCarById(string carId)
        {
            try
            {
                var result = await carService.GetCarById(carId);
                return Ok(result);
            }
            catch (RepositoryException ex)
            {
                return NotFound(ex.Message);
            }
        }
        /// <summary>
        /// Updates an existing Car by its ID (ChassisNumber).
        /// </summary>
        /// <param name="car"></param>
        /// <response code="200">Car updated successfully</response>
        /// <response code="404">Car not found</response>
        [HttpPut(Name = nameof(EditCar))]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EditCar(EditCarDTO car)
        {
            try
            {
                await carService.EditCar(car);
                return Ok(car);
            }
            catch (RepositoryException ex)
            {
                return NotFound(ex.Message);
            }
        }
        /// <summary>
        /// Deletes a Car by its ID (ChassisNumber).
        /// </summary>
        /// <param name="carId"></param>
        /// <response code="200">Car deleted successfully</response>
        /// <response code="404">Car not found</response>
        [HttpDelete("{carId}", Name = nameof(DeleteCar))]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCar(string carId)
        {
            try
            {
                var result = await carService.DeleteCar(carId);
                return Ok(result);
            }
            catch (RepositoryException ex)
            {
                return NotFound(ex.Message);
            }
        }
        /// <summary>
        /// Deletes all Cars.
        /// </summary>
        /// <response code="200">All Cars deleted successfully</response>
        [HttpDelete(Name = nameof(DeleteAllCars))]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteAllCars()
        {
            var result = await carService.DeleteAllCars();
            return Ok(result);
        }
    }
}
