using System.ComponentModel.DataAnnotations;

namespace Repositories.Models
{
    public class Salary : BaseEntity
    {
        [Required]
        public decimal Amount { get; set; }

        public Employee Employee { get; set; }
    }
}
