using EntityFrameworkCore_2.Domain.Models;

namespace EntityFrameworkCore_2.Application.Interfaces
{
    public interface ISalariesService
    {
        public Task<List<Salaries>> GetAllSalariesAsync();
        public Task<Salaries> GetSalariesByIdAsync(int id);
        public Task<Salaries> AddSalariesAsync(Salaries salary);
        public Task<Salaries> UpdateSalariesAsync(Salaries salary);
        public Task DeleteSalariesAsync(int id);
    }
}
