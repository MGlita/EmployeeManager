using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Surname).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Gender).HasMaxLength(1).IsRequired();
            builder.Property(x => x.Nationality).HasMaxLength(50).IsRequired();
            builder.Property(x => x.PhoneNumber).HasMaxLength(15).IsRequired();
            builder.Property(x => x.BirthDate).IsRequired();
            builder.Property(x => x.Email).IsRequired().HasMaxLength(50);
            builder.Property(x => x.HiredDate).IsRequired();
            builder.Property(x => x.Salary).IsRequired();
            builder.Property(x => x.JobTitle).IsRequired().HasMaxLength(100);
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            builder.Property(x => x.City).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Street).HasMaxLength(50).IsRequired();
            builder.Property(x => x.StreetNo).HasMaxLength(10).IsRequired();
            builder.Property(x => x.ZipCode).HasMaxLength(6).IsRequired();
        }
    }
}
