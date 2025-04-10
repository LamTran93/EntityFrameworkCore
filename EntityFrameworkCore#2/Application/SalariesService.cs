using EntityFrameworkCore_2.Application.Interfaces;
using EntityFrameworkCore_2.Domain.Models;
using EntityFrameworkCore_2.Exeptions;
using Microsoft.EntityFrameworkCore;
using Repositories.Contexts;

namespace EntityFrameworkCore_2.Application
{
    public class SalariesService : ISalariesService
    {
        private readonly CompanyContext _context;

        public SalariesService(CompanyContext context)
        {
            _context = context;
        }

        public async Task<List<Salaries>> GetAllSalariesAsync()
        {
            return await _context.Salaries.ToListAsync();
        }

        public async Task<Salaries> GetSalariesByIdAsync(int id)
        {
            var result = await _context.Salaries.FindAsync(id) ?? throw new NotFoundException($"Salaries id {id} not found");
            return result;
        }

        public async Task<Salaries> AddSalariesAsync(Salaries salary)
        {
            var result = _context.Salaries.Add(salary);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteSalariesAsync(int id)
        {
            var salary = await _context.Salaries.FindAsync(id) ?? throw new NotFoundException($"Salaries {id} not found");
            _context.Salaries.Remove(salary);
            await _context.SaveChangesAsync();
        }

        
        public async Task<Salaries> UpdateSalariesAsync(Salaries salary)
        {
            var existingSalary = await _context.Salaries.FindAsync(salary.Id) ?? throw new NotFoundException($"Salaries {salary.Id} not found");
            existingSalary.Salary = salary.Salary;
            _context.Salaries.Update(existingSalary);
            await _context.SaveChangesAsync();
            return existingSalary;
        }
    }
}
