using EmployeeCrud.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCrud.Data
{
    public class EmloyeeCrudDbContext : DbContext
    {
        public EmloyeeCrudDbContext(DbContextOptions options) : base(options) 
        {
        }
        public DbSet<Employee> employees { get; set; }
    }
}
