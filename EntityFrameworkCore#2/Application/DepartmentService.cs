using EntityFrameworkCore_2.Application.Interfaces;
using EntityFrameworkCore_2.Domain.Models;
using EntityFrameworkCore_2.Exeptions;
using Microsoft.EntityFrameworkCore;
using Repositories.Contexts;

namespace EntityFrameworkCore_2.Application
{
    public class DepartmentService : IDepartmentService
    {
        private readonly CompanyContext _context;
        public DepartmentService(CompanyContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> GetAllDepartmentsAsync()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<Department> GetDepartmentByIdAsync(int id)
        {
            var result = await _context.Departments.FindAsync(id) ?? throw new NotFoundException($"Department id {id} not found");
            return result;
        }

        public async Task<Department> AddDepartmentAsync(Department department)
        {
            var result = _context.Departments.Add(department);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteDepartmentAsync(int id)
        {
            var department = await _context.Departments.FindAsync(id) ?? throw new NotFoundException($"Department {id} not found");
            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
        }

        public async Task<Department> UpdateDepartmentAsync(Department department)
        {
            var existingDepartment = await _context.Departments.FindAsync(department.Id) ?? throw new NotFoundException($"Department {department.Id} not found");
            existingDepartment.Name = department.Name;
            _context.Departments.Update(existingDepartment);
            await _context.SaveChangesAsync();
            return existingDepartment;
        }
    }
}
