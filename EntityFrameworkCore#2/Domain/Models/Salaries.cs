using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCore_2.Domain.Models
{
    public class Salaries : BaseEntity
    {
        [Required]
        public decimal Salary { get; set; }
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

    }
}
