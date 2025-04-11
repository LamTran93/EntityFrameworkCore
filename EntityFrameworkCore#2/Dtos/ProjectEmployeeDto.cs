using EntityFrameworkCore_2.Domain.Models;

namespace EntityFrameworkCore_2.Dtos
{
    public class ProjectEmployeeDto
    {
        public int Id { get; set; } 
        public int ProjectId { get; set; }
        public int EmployeeId { get; set; }
        public bool IsEnabled { get; set; }

        public ProjectEmployeeDto() { }

        public ProjectEmployeeDto(ProjectEmployee pe)
        {
            Id = pe.Id;
            ProjectId = pe.ProjectId;
            EmployeeId = pe.EmployeeId;
            IsEnabled = pe.IsEnabled;
        }

        public ProjectEmployee ToProjectEmployee()
        {
            return new ProjectEmployee
            {
                Id = Id,
                ProjectId = ProjectId,
                EmployeeId = EmployeeId,
                IsEnabled = IsEnabled
            };
        }

        public ProjectEmployee ToProjectEmployeeWithoutId()
        {
            return new ProjectEmployee
            {
                ProjectId = ProjectId,
                EmployeeId = EmployeeId,
                IsEnabled = IsEnabled
            };
        }
    }
}
