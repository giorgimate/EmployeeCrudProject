namespace EmployeeCrud.Models.Domain
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DayOfBirth { get; set; }
        public double Sallary { get; set; }
        public string  Department { get; set; }
    }
}
