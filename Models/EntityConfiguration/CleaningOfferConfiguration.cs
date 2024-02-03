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
    public class CleaningOfferConfiguration : IEntityTypeConfiguration<CleaningOffer>
    {
        public void Configure(EntityTypeBuilder<CleaningOffer> builder)
        {
            builder.ToTable("CleaningOffer");

            builder.HasKey(x => x.CleaningOfferID);
            builder.Property(x => x.CleaningOfferID)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Price)
                .IsRequired();

            builder.HasMany(x => x._ordersCreated)
                .WithOne(x => x._offer);

            builder.HasOne(x => x._apartment)
                .WithOne(x => x._cleaningOffer)
                .HasForeignKey("Apartment", "CleaningOffer");

            builder.HasOne(x => x._facility)
                .WithOne(x => x._cleaningOffer)
                .HasForeignKey("Facility", "CleaningOffer");

            builder.HasOne(x => x._cleanUp)
                .WithOne(x => x._cleaningOffer)
                .HasForeignKey("CleanUp", "CleaningOffer");

            builder.HasOne(x => x._deepClean)
                .WithOne(x => x._cleaningOffer)
                .HasForeignKey("DeepClean", "CleaningOffer");
        }
    }
}
