using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCore_2.Domain.Models
{
    public class Project : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public ICollection<ProjectEmployee> ProjectEmployees { get; set; }
    }
}
