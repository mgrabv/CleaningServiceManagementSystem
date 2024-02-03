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
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");

            builder.HasKey(x => x.OrderID);
            builder.Property(x => x.OrderID)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.JobType)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.OrderDate)
                .IsRequired();

            builder.Property(x => x.JobDate)
                .IsRequired();
        }
    }
}
