namespace Repositories.Models
{
    public class ProjectEmployee : BaseEntity
    {
        public int ProjectId { get; set; }
        public int EmployeeId { get; set; }
        public bool IsEnabled { get; set; }

        public Project Project { get; set; }
        public Employee Employee { get; set; }
    }
}
