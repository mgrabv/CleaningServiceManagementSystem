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
    public class ApartmentConfiguration : IEntityTypeConfiguration<Apartment>
    {
        public void Configure(EntityTypeBuilder<Apartment> builder)
        {
            builder.ToTable("Apartment");

            builder.HasKey(x => x.ApartmentID);
            builder.Property(x => x.ApartmentID)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.RoomCount)
                .IsRequired();
        }
    }
}
