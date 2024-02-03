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
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client");

            builder.HasKey(x => x.ClientID);
            builder.Property(x => x.ClientID)
                .ValueGeneratedOnAdd();

            builder.HasOne(x => x._person)
                .WithOne(x => x._client)
                .HasForeignKey("Client", "Person")
                .IsRequired();

            builder.HasMany(x => x._viewedCleaningOffers)
                .WithMany(x => x._viewedByClients);

            builder.HasMany(x => x._orders)
                .WithOne(x => x._client);
        }
    }
}
