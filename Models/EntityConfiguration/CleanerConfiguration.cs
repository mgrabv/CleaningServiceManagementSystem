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
    public class CleanerConfiguration : IEntityTypeConfiguration<Cleaner>
    {
        public void Configure(EntityTypeBuilder<Cleaner> builder)
        {
            builder.ToTable("Cleaner");

            builder.HasKey(x => x.CleanerID);
            builder.Property(x => x.CleanerID)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.PayPerSqrMeter)
                .IsRequired();

            builder.HasOne(x => x._employee)
                .WithOne(x => x._cleaner)
                .HasForeignKey("Cleaner", "Employee")
                .IsRequired();

            builder.HasMany(x => x._assignedOrders)
                .WithMany(x => x._cleaners);
        }
    }
}
