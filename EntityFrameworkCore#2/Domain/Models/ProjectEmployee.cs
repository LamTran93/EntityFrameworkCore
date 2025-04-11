using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCore_2.Domain.Models
{
    public class ProjectEmployee : BaseEntity
    {
        public int ProjectId { get; set; }
        public int EmployeeId { get; set; }
        [Column("Enable")]
        public bool IsEnabled { get; set; }

        public Project Project { get; set; }
        public Employee Employee { get; set; }
    }
}
