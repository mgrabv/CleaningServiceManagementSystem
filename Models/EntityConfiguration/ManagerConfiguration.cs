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
    public class ManagerConfiguration : IEntityTypeConfiguration<Manager>
    {
        public void Configure(EntityTypeBuilder<Manager> builder)
        {
            builder.ToTable("Manager");

            builder.HasKey(x => x.ManagerID);
            builder.Property(x => x.ManagerID)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.LicenceID)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasOne(x => x._person)
                .WithOne(x => x._manager)
                .HasForeignKey("Manager", "Person")
                .IsRequired();
        }
    }
}