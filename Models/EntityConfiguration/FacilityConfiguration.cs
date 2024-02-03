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
    public class FacilityConfiguration : IEntityTypeConfiguration<Facility>
    {
        public void Configure(EntityTypeBuilder<Facility> builder)
        {
            builder.ToTable("Facility");

            builder.HasKey(x => x.FacilityID);
            builder.Property(x => x.FacilityID)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.SquareMeters)
                .IsRequired();
        }
    }
}
