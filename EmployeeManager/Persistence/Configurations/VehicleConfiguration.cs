using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Configurations
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.VehicleType).IsRequired();
            builder.Property(x => x.Make).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Make).HasMaxLength(50);
            builder.Property(x => x.RegistrationNumber).HasMaxLength(10).IsRequired();
            builder.Property(x => x.ProductionYear).HasMaxLength(4).IsRequired();
        }
    }
}
