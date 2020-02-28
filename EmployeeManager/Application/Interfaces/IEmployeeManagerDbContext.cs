using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IEmployeeManagerDbContext
    {
        DbSet<Employee> Employees { get; set; }
        DbSet<Customer> Customer { get; set; }
        DbSet<Company> Company { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
