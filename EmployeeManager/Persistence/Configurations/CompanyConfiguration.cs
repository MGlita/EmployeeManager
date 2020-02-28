using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(50).IsRequired();
            builder.Property(x => x.City).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Street).HasMaxLength(50).IsRequired();
            builder.Property(x => x.StreetNo).HasMaxLength(10).IsRequired();
            builder.Property(x => x.ZipCode).HasMaxLength(6).IsRequired();
        }
    }
}
