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
    public class AttentionTypeConfiguration : IEntityTypeConfiguration<AttentionTypeModel>
    {
        public void Configure(EntityTypeBuilder<AttentionTypeModel> builder)
        {
            builder
                .HasKey(e => e.AttentionTypeId)
                .HasName("AttentionType_PK");
            builder.Property(p => p.AttentionTypeId).HasMaxLength(3);
            builder.Property(p => p.AttentionDescription).HasMaxLength(100);
            builder
                .HasMany(e => e.Attentions)
                .WithOne(e => e.AttentionType)
                .HasForeignKey(e => e.AttentionTypeId)
                .IsRequired();
        }
    }
}
