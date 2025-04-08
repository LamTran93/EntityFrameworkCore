namespace EntityFrameworkCore.Models
{
    public class Salary
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public Employee Employee { get; set; }
    }
}
