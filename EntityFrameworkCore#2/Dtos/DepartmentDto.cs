using EntityFrameworkCore_2.Domain.Models;

namespace EntityFrameworkCore_2.Dtos
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DepartmentDto() { }

        public DepartmentDto(Department department)
        {
            Id = department.Id;
            Name = department.Name;
        }

        public Department ToDepartment()
        {
            return new Department
            {
                Id = Id,
                Name = Name
            };
        }

        public Department ToDepartmentWithoutId()
        {
            return new Department
            {
                Name = Name
            };
        }
    }
}
