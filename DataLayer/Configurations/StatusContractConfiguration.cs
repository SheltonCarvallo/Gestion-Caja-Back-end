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
    public class StatusContractConfiguration : IEntityTypeConfiguration<StatusContractModel>
    {
        public void Configure(EntityTypeBuilder<StatusContractModel> builder)
        {
            builder
            .HasKey(e => e.StatusContractId)
            .HasName("StatusContract_PK");
            builder.Property(e => e.StatusContractId).HasMaxLength(3);
            builder.Property(p => p.Description).HasMaxLength(50);
        }
    }
}
