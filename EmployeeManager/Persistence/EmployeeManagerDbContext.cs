using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistence.Configurations;

namespace Persistence
{
    public class EmployeeManagerDbContext: IdentityDbContext, IEmployeeManagerDbContext
    {

        public EmployeeManagerDbContext(DbContextOptions<EmployeeManagerDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
