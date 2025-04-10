using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCore_2.Domain.Models
{
    public class Department : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
