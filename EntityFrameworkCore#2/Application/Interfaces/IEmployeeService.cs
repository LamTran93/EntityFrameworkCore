using EntityFrameworkCore_2.Domain.Models;

namespace EntityFrameworkCore_2.Application.Interfaces
{
    public interface IEmployeeService
    {
        public Task<List<Employee>> GetAllEmployeesAsync();
        public Task<Employee> GetEmployeeByIdAsync(int id);
        public Task<Employee> AddEmployeeAsync(Employee employee);
        public Task<Employee> UpdateEmployeeAsync(Employee employee);
        public Task DeleteEmployeeAsync(int id);
        public Task<List<Employee>> GetAllEmployeesWithDepartmentAsync();
        public Task<List<Employee>> GetAllEmployeesWithProjectsAsync();
        public Task<List<Employee>> GetEmployeesUseSalaryAndJoinedDateAsync();
    }
}
