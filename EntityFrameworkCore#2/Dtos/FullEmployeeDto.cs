using EntityFrameworkCore_2.Domain.Models;

namespace EntityFrameworkCore_2.Dtos
{
    public class FullEmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public DateTime JoinedDate { get; set; }

        public DepartmentDto Department { get; set; }
        public List<ProjectDto> Projects { get; set; }
        public SalariesDto Salary { get; set; }

        public FullEmployeeDto() { }

        public FullEmployeeDto(Employee employee)
        {
            Id = employee.Id;
            Name = employee.Name;
            DepartmentId = employee.DepartmentId;
            JoinedDate = employee.JoinedDate;
            Department = employee.Department != null ? new DepartmentDto(employee.Department) : null;
            Projects = (employee.ProjectEmployees != null && employee.ProjectEmployees.Any()) ?
                employee.ProjectEmployees.Select(pe => (pe.Project != null ? new ProjectDto(pe.Project) : null)).ToList() : [];
            Salary = employee.Salary != null ? new SalariesDto(employee.Salary) : null;
        }
    }
}
