using EntityFrameworkCore_2.Application.Interfaces;
using EntityFrameworkCore_2.Dtos;
using EntityFrameworkCore_2.Exeptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories.Contexts;
using Repositories.Models;

namespace EntityFrameworkCore_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalariesController : ControllerBase
    {
        private readonly ISalariesService _service;

        public SalariesController(ISalariesService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalariesDto>>> GetSalaries()
        {
            try
            {
                var salaries = await _service.GetAllSalariesAsync();

                return salaries.Select(s => new SalariesDto(s)).ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SalariesDto>> GetSalary(int id)
        {
            try
            {
                var salary = await _service.GetSalariesByIdAsync(id);
                return new SalariesDto(salary);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalary(int id, SalariesDto salary)
        {
            if (id != salary.Id)
            {
                return BadRequest();
            }

            try
            {
                await _service.UpdateSalariesAsync(salary.ToSalaries());
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<ActionResult<SalariesDto>> PostSalary(SalariesDto salary)
        {
            try
            {
                var createdSalaries =
                    await _service.AddSalariesAsync(salary.ToSalariesWithoutId());
                return CreatedAtAction("GetSalaries", new { id = createdSalaries.Id }, createdSalaries);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalary(int id)
        {
            try
            {
                await _service.DeleteSalariesAsync(id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
