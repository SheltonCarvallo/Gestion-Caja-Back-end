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
    public class ServiceConfiguration : IEntityTypeConfiguration<ServiceModel>
    {
        public void Configure(EntityTypeBuilder<ServiceModel> builder)
        {
            builder
                .HasKey(e => e.ServiceId)
                .HasName("Service_PK");
            builder.Property(p => p.ServiceName).HasMaxLength(100);
            builder.Property(p => p.ServiceDescription).HasMaxLength(150);
            builder.Property(p => p.Price).HasPrecision(4);

        }
    }
}
