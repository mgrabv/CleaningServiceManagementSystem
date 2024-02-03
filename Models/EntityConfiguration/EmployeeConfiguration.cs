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
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");

            builder.HasKey(x => x.EmployeeID);
            builder.Property(x => x.EmployeeID)
                .ValueGeneratedOnAdd();

            builder.HasOne(x => x._person)
                .WithOne(x => x._employee)
                .HasForeignKey("Employee", "Person")
                .IsRequired();
        }
    }
}
