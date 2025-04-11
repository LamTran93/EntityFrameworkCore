using EntityFrameworkCore_2.Application.Interfaces;
using EntityFrameworkCore_2.Dtos;
using EntityFrameworkCore_2.Exeptions;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkCore_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _service;

        public DepartmentsController(IDepartmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentDto>>> GetDepartments()
        {
            try
            {
                var departments = await _service.GetAllDepartmentsAsync();

                return Ok(departments.Select(d => new DepartmentDto(d)).ToList());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentDto>> GetDepartment(int id)
        {
            try
            {
                var department = await _service.GetDepartmentByIdAsync(id);
                return Ok(new DepartmentDto(department));
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
        public async Task<IActionResult> PutDepartment(int id, DepartmentDto department)
        {
            if (id != department.Id)
            {
                return BadRequest();
            }

            try
            {
                await _service.UpdateDepartmentAsync(department.ToDepartment());
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
        public async Task<ActionResult<DepartmentDto>> PostDepartment(DepartmentDto department)
        {
            try
            {
                var createdDepartment = 
                    await _service.AddDepartmentAsync(department.ToDepartmentWithoutId());
                return CreatedAtAction("GetDepartment", new { id = createdDepartment.Id }, new DepartmentDto(createdDepartment));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            try
            {
                await _service.DeleteDepartmentAsync(id);
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
