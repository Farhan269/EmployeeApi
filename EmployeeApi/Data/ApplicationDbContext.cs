using EmployeeApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApi.Data
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
            
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



            modelBuilder.Entity<EmployeeAttendence>().HasNoKey();
            modelBuilder.Entity<MonthlyAttendanceReport>().HasNoKey();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeAttendence> EmployeeAttendences { get; set; }
        public DbSet <MonthlyAttendanceReport> MonthlyAttendanceReports { get; set; }

    }
}
