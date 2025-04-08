namespace EntityFrameworkCore.Models
{
    public class ProjectEmployee
    {
        public Project Project { get; set; }
        public Employee Employee { get; set; }
        public bool IsEnabled { get; set; }
    }
}
