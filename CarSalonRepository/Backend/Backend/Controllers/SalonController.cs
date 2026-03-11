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
    public class SalonController(ISalonService salonService) : ControllerBase
    {
        /// <summary>
        /// Creates a Salon.
        /// </summary>
        /// <param name="salon"></param>"
        /// <response code="201">Salon created successfully.</response>
        /// <response code="400">Bad request.</response>
        [HttpPut(Name = nameof(CreateSalon))]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateSalon(CreateSalonDTO salon)
        {
            try
            {
                var result = await salonService.CreateSalon(salon);
                return Created($"api/Salon/{result.SalonId}", result);
            }
            catch (RepositoryException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Get all Salons.
        /// </summary>
        /// <response code="200">Salons retrieved successfully.</response>
        [HttpGet(Name = nameof(GetAllSalons))]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllSalons()
        {
            var result = await salonService.GetAllSalons();
            return Ok(result);
        }

        /// <summary>
        /// Get a Salon by its ID.
        /// </summary>
        /// <param name="salonId"></param>
        /// <response code="200">Salon retrieved successfully.</response>
        /// response code="404">Salon not found.</response>
        [HttpGet("{salonId}", Name = nameof(GetSalonById))]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSalonById(Guid salonId)
        {
            try
            {
                var result = await salonService.GetSalonById(salonId);
                return Ok(result);
            }
            catch (RepositoryException ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Deletes a Salon by its ID.
        /// </summary>
        /// <param name="salonId"></param>
        /// <response code="200">The Salon deleted successfully</response>
        /// response code="404">Salon not found.</response>
        [HttpDelete("{salonId}", Name = nameof(DeleteSalon))]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteSalon(Guid salonId)
        {
            try
            {
                var result = await salonService.DeleteSalon(salonId);
                return Ok(result);
            }
            catch (RepositoryException ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Edits an existing Salon by its ID.
        /// </summary>
        /// <param name="salonId"></param>
        /// <param name="salon"></param>
        /// <response code="200">Salon edited successfully.</response>
        /// response code="404">Salon not found.</response>
        [HttpPut("{salonId}", Name = nameof(EditSalon))]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EditSalon(EditSalonDTO salon)
        {
            try
            {
                await salonService.EditSalon(salon);
                return Ok(salon);
            }
            catch (RepositoryException ex)
            {
                return NotFound(ex.Message);
            }
        }
        ///<summary>
        ///Deletes all Salons.
        ///</summary>
        ///<response code="200">All Salons deleted successfully.</response>
        [HttpDelete(Name = nameof(DeleteAllSalons))]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteAllSalons()
        {
            var result = await salonService.DeleteAllSalons();
            return Ok(result);
        }
    }
}
