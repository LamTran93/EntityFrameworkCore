namespace Repository.Models
{
    public class ProjectEmployee : BaseEntity
    {
        public Project Project { get; set; }
        public Employee Employee { get; set; }
        public bool IsEnabled { get; set; }
    }
}
