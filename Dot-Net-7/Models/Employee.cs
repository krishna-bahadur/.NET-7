namespace Dot_Net_7.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string LastName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

    }
}
