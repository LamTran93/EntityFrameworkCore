using System.ComponentModel.DataAnnotations;

namespace Repository.Models
{
    public class Salary : BaseEntity
    {
        [Required]
        public decimal Amount { get; set; }

        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
    }
}
