namespace EntityFrameworkCore.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Department Department { get; set; }
        public DateTime JoinedDate { get; set; }
    }
}
