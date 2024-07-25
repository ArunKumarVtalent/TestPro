
using Microsoft.EntityFrameworkCore;
using WebAPIPro.Models;

namespace WebAPIPro.DatabaseContext
{
    public class DBContextPro : DbContext
    {
        public DBContextPro(DbContextOptions<DBContextPro> options) : base(options) { }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
