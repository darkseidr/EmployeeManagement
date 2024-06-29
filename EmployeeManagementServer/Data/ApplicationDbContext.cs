using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Shared.Models;

namespace EmployeeManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<LoginModel> LoginModels { get; set; }

    }
}
