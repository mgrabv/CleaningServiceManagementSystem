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
    public class WarehouseConfiguration : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            builder.ToTable("Warehouse");

            builder.HasKey(x => x.WarehouseID);
            builder.Property(x => x.WarehouseID)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Capacity)
                .IsRequired();
        }
    }
}
