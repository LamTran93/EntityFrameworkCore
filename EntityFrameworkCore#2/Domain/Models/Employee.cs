using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCore_2.Domain.Models
{
    public class Employee : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        [Required]
        public DateTime JoinedDate { get; set; }

        public Department Department { get; set; }
        public ICollection<ProjectEmployee> ProjectEmployees { get; set; }
        public Salaries Salary { get; set; }
    }
}
