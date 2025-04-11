using EntityFrameworkCore_2.Domain.Models;

namespace EntityFrameworkCore_2.Application.Interfaces
{
    public interface IProjectEmployeeService
    {
        Task<List<ProjectEmployee>> GetAllProjectEmployeesAsync();
        Task<ProjectEmployee> GetProjectEmployeeByIdAsync(int id);
        Task<ProjectEmployee> AddProjectEmployeeAsync(ProjectEmployee projectEmployee);
        Task<ProjectEmployee> UpdateProjectEmployeeAsync(ProjectEmployee projectEmployee);
        Task DeleteProjectEmployeeAsync(int id);
    }
}
