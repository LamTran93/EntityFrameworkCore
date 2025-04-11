using EntityFrameworkCore_2.Domain.Models;

namespace EntityFrameworkCore_2.Dtos
{
    public class SalariesDto
    {
        public int Id { get; set; }
        public decimal Salary { get; set; }
        public int EmployeeId { get; set; }

        public SalariesDto() { }

        public SalariesDto(Salaries salary)
        {
            Id = salary.Id;
            Salary = salary.Salary;
            EmployeeId = salary.EmployeeId;
        }

        public Salaries ToSalaries()
        {
            return new Salaries
            {
                Id = Id,
                Salary = Salary,
                EmployeeId = EmployeeId
            };
        }

        public Salaries ToSalariesWithoutId()
        {
            return new Salaries { Salary = Salary, EmployeeId = EmployeeId };
        }
    }
}
