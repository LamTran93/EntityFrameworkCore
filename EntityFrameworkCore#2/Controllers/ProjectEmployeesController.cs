using Microsoft.AspNetCore.Mvc;
using EntityFrameworkCore_2.Dtos;
using EntityFrameworkCore_2.Exeptions;
using EntityFrameworkCore_2.Application.Interfaces;

namespace EntityFrameworkCore_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectEmployeesController : ControllerBase
    {
        private readonly IProjectEmployeeService _service;

        public ProjectEmployeesController(IProjectEmployeeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectEmployeeDto>>> GetProjectEmployees()
        {
            try
            {
                var projectEmployees = await _service.GetAllProjectEmployeesAsync();

                return Ok(projectEmployees.Select(pe => new ProjectEmployeeDto(pe)).ToList());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectEmployeeDto>> GetProjectEmployee(int id)
        {
            try
            {
                var projectEmployee = await _service.GetProjectEmployeeByIdAsync(id);
                return Ok(new ProjectEmployeeDto(projectEmployee));
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

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectEmployee(int id, ProjectEmployeeDto projectEmployee)
        {
            if (id != projectEmployee.Id)
            {
                return BadRequest();
            }

            try
            {
                await _service.UpdateProjectEmployeeAsync(projectEmployee.ToProjectEmployee());
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
        public async Task<ActionResult<ProjectEmployeeDto>> PostProjectEmployee(ProjectEmployeeDto projectEmployee)
        {
            try
            {
                var createdProjectEmployee =
                    await _service.AddProjectEmployeeAsync(projectEmployee.ToProjectEmployeeWithoutId());
                return CreatedAtAction("GetProjectEmployee", new { id = createdProjectEmployee.Id }, new ProjectEmployeeDto(createdProjectEmployee));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectEmployee(int id)
        {
            try
            {
                await _service.DeleteProjectEmployeeAsync(id);
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
