﻿using EntityFrameworkCore_2.Application.Interfaces;
using EntityFrameworkCore_2.Domain.Models;
using EntityFrameworkCore_2.Exeptions;
using Microsoft.EntityFrameworkCore;
using Repositories.Contexts;

namespace EntityFrameworkCore_2.Application
{
    public class EmployeeService : IEmployeeService
    {
        private readonly CompanyContext _context;

        public EmployeeService(CompanyContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            var result = await _context.Employees.FindAsync(id) ?? throw new NotFoundException($"Employee id {id} not found");
            return result;
        }

        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            var result = _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Employee> UpdateEmployeeAsync(Employee employee)
        {
            var existingEmployee = await _context.Employees.FindAsync(employee.Id) ?? throw new NotFoundException($"Employee {employee.Id} not found");
            existingEmployee.Name = employee.Name;
            existingEmployee.DepartmentId = employee.DepartmentId;
            existingEmployee.JoinedDate = employee.JoinedDate;
            _context.Employees.Update(existingEmployee);
            await _context.SaveChangesAsync();
            return existingEmployee;
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id) ?? throw new NotFoundException($"Employee {id} not found");
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Employee>> GetAllEmployeesWithDepartmentAsync()
        {
            return await _context.Employees
                .Include(e => e.Department)
                .ToListAsync();
        }

        public async Task<List<Employee>> GetAllEmployeesWithProjectsAsync()
        {
            return await _context.Employees
                .Include(e => e.ProjectEmployees)
                .ThenInclude(pe => pe.Project)
                .ToListAsync();
        }

        public async Task<List<Employee>> GetEmployeesUseSalaryAndJoinedDateAsync()
        {
            return await _context.Employees
                .FromSql($"SELECT e.* FROM dbo.Employees as e LEFT JOIN dbo.Salaries as s ON e.Id = s.EmployeeId WHERE e.JoinedDate >= '01/01/2024' AND s.Salary > 100")
                .Include(e => e.Salary)
                .ToListAsync();
        }
    }
}
