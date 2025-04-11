using EntityFrameworkCore_2.Application.Interfaces;
using EntityFrameworkCore_2.Domain.Models;
using EntityFrameworkCore_2.Dtos;
using EntityFrameworkCore_2.Exeptions;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkCore_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeesController(IEmployeeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployees()
        {
            try
            {
                var employees = await _service.GetAllEmployeesAsync();

                return Ok(employees.Select(e => new EmployeeDto(e)).ToList());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> GetEmployee(int id)
        {
            try
            {
                var employee = await _service.GetEmployeeByIdAsync(id);
                return Ok(new EmployeeDto(employee));
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
        public async Task<IActionResult> PutEmployee(int id, EmployeeDto employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            try
            {
                await _service.UpdateEmployeeAsync(employee.ToEmployee());
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
        public async Task<ActionResult<EmployeeDto>> PostEmployee(EmployeeDto employee)
        {
            try
            {
                var createdEmployee = 
                    await _service.AddEmployeeAsync(employee.ToEmployeeWithoutId());
                return CreatedAtAction("GetEmployee", new { id = createdEmployee.Id }, new EmployeeDto(createdEmployee));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            } 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                await _service.DeleteEmployeeAsync(id);
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

        [HttpGet("withDepartment")]
        public async Task<ActionResult<IEnumerable<FullEmployeeDto>>> GetEmployeesWithDepartment()
        {
            try
            {
                var employees = await _service.GetAllEmployeesWithDepartmentAsync();
                return Ok(employees.Select(e => new FullEmployeeDto(e)).ToList());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("withProjects")]
        public async Task<ActionResult<IEnumerable<FullEmployeeDto>>> GetEmployeesWithProjects()
        {
            try
            {
                var employees = await _service.GetAllEmployeesWithProjectsAsync();
                return Ok(employees.Select(e => new FullEmployeeDto(e)).ToList());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("withConditions")]
        public async Task<ActionResult<IEnumerable<FullEmployeeDto>>> GetEmployeesWithConditions()
        {
            try
            {
                var employees = await _service.GetEmployeesUseSalaryAndJoinedDateAsync();
                
                return Ok(employees.Select(e => new FullEmployeeDto(e)).ToList());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
