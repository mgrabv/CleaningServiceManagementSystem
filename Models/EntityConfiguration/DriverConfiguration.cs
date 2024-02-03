using CSMS.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMS.Models.EntityConfiguration
{
    public class DriverConfiguration : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            builder.ToTable("Driver");

            builder.HasKey(x => x.DriverID);
            builder.Property(x => x.DriverID)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.PayPerOrder)
                .IsRequired();

            builder.HasOne(x => x._employee)
                .WithOne(x => x._driver)
                .HasForeignKey("Driver", "Employee")
                .IsRequired();

            builder.HasMany(x => x._assignedOrders)
                .WithOne(x => x._driver);

            builder.HasOne(x => x._car)
                .WithOne(x => x._driver)
                .HasForeignKey("Car", "Driver")
                .IsRequired(false);
        }
    }
}
