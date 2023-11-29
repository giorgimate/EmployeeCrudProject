namespace EmployeeCrud.Models
{
    public class UpdateEmployeeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DayOfBirth { get; set; }
        public double Sallary { get; set; }
        public string Department { get; set; }
    }
}
