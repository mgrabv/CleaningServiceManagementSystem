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
    public class DeepCleanConfiguration : IEntityTypeConfiguration<DeepClean>
    {
        public void Configure(EntityTypeBuilder<DeepClean> builder)
        {
            builder.ToTable("DeepClean");

            builder.HasKey(x => x.DeepCleanID);
            builder.Property(x => x.DeepCleanID)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.SpecialChemicals)
                .IsRequired()
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());
        }
    }
}
