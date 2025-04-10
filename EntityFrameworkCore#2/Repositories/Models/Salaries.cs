using System.ComponentModel.DataAnnotations;

namespace Repositories.Models
{
    public class Salaries : BaseEntity
    {
        [Required]
        public decimal Salary { get; set; }

        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
    }
}
