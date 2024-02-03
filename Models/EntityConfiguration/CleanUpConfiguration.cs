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
    public class CleanUpConfiguration : IEntityTypeConfiguration<CleanUp>
    {
        public void Configure(EntityTypeBuilder<CleanUp> builder)
        {
            builder.ToTable("CleanUp");

            builder.HasKey(x => x.CleanUpID);
            builder.Property(x => x.CleanUpID)
                .ValueGeneratedOnAdd();
        }
    }
}
