using EntityFrameworkCore_2.Application.Interfaces;
using EntityFrameworkCore_2.Domain.Models;
using EntityFrameworkCore_2.Exeptions;
using Microsoft.EntityFrameworkCore;
using Repositories.Contexts;

namespace EntityFrameworkCore_2.Application
{
    public class ProjectEmployeeService : IProjectEmployeeService
    {
        private readonly CompanyContext _context;

        public ProjectEmployeeService(CompanyContext context)
        {
            _context = context;
        }

        public async Task<List<ProjectEmployee>> GetAllProjectEmployeesAsync()
        {
            return await _context.ProjectEmployees.ToListAsync();
        }

        public async Task<ProjectEmployee> GetProjectEmployeeByIdAsync(int id)
        {
            var result = await _context.ProjectEmployees.FindAsync(id) ?? throw new NotFoundException($"ProjectEmployee id {id} not found");
            return result;
        }

        public async Task<ProjectEmployee> AddProjectEmployeeAsync(ProjectEmployee projectEmployee)
        {
            var result = _context.ProjectEmployees.Add(projectEmployee);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<ProjectEmployee> UpdateProjectEmployeeAsync(ProjectEmployee projectEmployee)
        {
            var existingProjectEmployee = await _context.ProjectEmployees.FindAsync(projectEmployee.Id) ?? throw new NotFoundException($"ProjectEmployee {projectEmployee.Id} not found");
            existingProjectEmployee.ProjectId = projectEmployee.ProjectId;
            existingProjectEmployee.EmployeeId = projectEmployee.EmployeeId;
            existingProjectEmployee.IsEnabled = projectEmployee.IsEnabled;
            _context.ProjectEmployees.Update(existingProjectEmployee);
            await _context.SaveChangesAsync();
            return existingProjectEmployee;
        }

        public async Task DeleteProjectEmployeeAsync(int id)
        {
            var projectEmployee = await _context.ProjectEmployees.FindAsync(id) ?? throw new NotFoundException($"ProjectEmployee {id} not found");
            _context.ProjectEmployees.Remove(projectEmployee);
            await _context.SaveChangesAsync();
        }
    }
}
