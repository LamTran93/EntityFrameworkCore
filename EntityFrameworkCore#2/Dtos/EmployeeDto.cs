using EntityFrameworkCore_2.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCore_2.Dtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public DateTime JoinedDate { get; set; }

        public EmployeeDto(Employee employee)
        {
            Id = employee.Id;
            Name = employee.Name;
            DepartmentId = employee.DepartmentId;
            JoinedDate = employee.JoinedDate;
        }

        public Employee ToEmployee()
        {
            return new Employee
            {
                Id = Id,
                Name = Name,
                DepartmentId = DepartmentId,
                JoinedDate = JoinedDate
            };
        }

        public Employee ToEmployeeWithoutId()
        {
            return new Employee
            {
                Name = Name,
                DepartmentId = DepartmentId,
                JoinedDate = JoinedDate
            };
        }
    }
}
