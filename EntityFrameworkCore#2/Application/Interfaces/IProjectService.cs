using EntityFrameworkCore_2.Domain.Models;

namespace EntityFrameworkCore_2.Application.Interfaces
{
    public interface IProjectService
    {
        Task<List<Project>> GetAllProjectsAsync();
        Task<Project> GetProjectByIdAsync(int id);
        Task<Project> AddProjectAsync(Project project);
        Task DeleteProjectAsync(int id);
        Task<Project> UpdateProjectAsync(Project project);
    }
}
