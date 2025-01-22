using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<ClientModel>
    {
        public void Configure(EntityTypeBuilder<ClientModel> builder)
        {
            builder
                .HasKey(e => e.ClientId)
                .HasName("Client_PK");
            builder.Property(p => p.Name).HasMaxLength(50);
            builder.Property(p => p.LastName).HasMaxLength(50);
            builder.Property(p => p.identification).HasMaxLength(13);
            builder.Property(p => p.Email).HasMaxLength(120);
            builder.Property(p => p.PhoneNumber).HasMaxLength(13);
            builder.Property(p => p.Address).HasMaxLength(100);
            builder.Property(p => p.ReferenceAddress).HasMaxLength(100);

        }
    }
}
