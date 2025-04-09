using System.ComponentModel.DataAnnotations;

namespace Repository.Models
{
    public class Employee : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public Department Department { get; set; }

        [Required]
        public DateTime JoinedDate { get; set; }

        public ICollection<Project> Projects { get; set; }
        public Salary Salary { get; set; }
    }
}
