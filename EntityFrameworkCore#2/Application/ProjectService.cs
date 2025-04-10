using EntityFrameworkCore_2.Application.Interfaces;
using EntityFrameworkCore_2.Domain.Models;
using EntityFrameworkCore_2.Exeptions;
using Microsoft.EntityFrameworkCore;
using Repositories.Contexts;

namespace EntityFrameworkCore_2.Application
{
    public class ProjectService : IProjectService
    {
        private readonly CompanyContext _context;

        public ProjectService(CompanyContext context)
        {
            _context = context;
        }

        public async Task<List<Project>> GetAllProjectsAsync()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task<Project> GetProjectByIdAsync(int id)
        {
            var result = await _context.Projects.FindAsync(id) ?? throw new NotFoundException($"Project id {id} not found");
            return result;
        }

        public async Task<Project> AddProjectAsync(Project project)
        {
            var result = _context.Projects.Add(project);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteProjectAsync(int id)
        {
            var project = await _context.Projects.FindAsync(id) ?? throw new NotFoundException($"Project {id} not found");
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
        }

        public async Task<Project> UpdateProjectAsync(Project project)
        {
            var existingProject = await _context.Projects.FindAsync(project.Id) ?? throw new NotFoundException($"Project {project.Id} not found");
            existingProject.Name = project.Name;
            _context.Projects.Update(existingProject);
            await _context.SaveChangesAsync();
            return existingProject;
        }
    }
}
