using EntityFrameworkCore_2.Application.Interfaces;
using EntityFrameworkCore_2.Dtos;
using EntityFrameworkCore_2.Exeptions;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkCore_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _service;

        public ProjectsController(IProjectService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectDto>>> GetProjects()
        {
            try
            {
                var projects = await _service.GetAllProjectsAsync();

                return Ok(projects.Select(p => new ProjectDto(p)).ToList());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDto>> GetProject(int id)
        {
            try
            {
                var project = await _service.GetProjectByIdAsync(id);
                return Ok(new ProjectDto(project));
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
        public async Task<IActionResult> PutProject(int id, ProjectDto project)
        {
            if (id != project.Id)
            {
                return BadRequest();
            }

            try
            {
                await _service.UpdateProjectAsync(project.ToProject());
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
        public async Task<ActionResult<ProjectDto>> PostProject(ProjectDto project)
        {
            try
            {
                var createdProject =
                    await _service.AddProjectAsync(project.ToProjectWithoutId());
                return CreatedAtAction("GetProject", new { id = createdProject.Id }, new ProjectDto(createdProject));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            try
            {
                await _service.DeleteProjectAsync(id);
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
