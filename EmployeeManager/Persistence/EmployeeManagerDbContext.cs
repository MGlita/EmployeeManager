using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Configurations;

namespace Persistence
{
    public class EmployeeManagerDbContext: DbContext, IEmployeeManagerDbContext
    {

        public EmployeeManagerDbContext(DbContextOptions<EmployeeManagerDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Company> Company { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());

        }
    }
}
