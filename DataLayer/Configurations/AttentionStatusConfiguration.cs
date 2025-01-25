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
    public class AttentionStatusConfiguration : IEntityTypeConfiguration<AttentionStatusModel>
    {
        public void Configure(EntityTypeBuilder<AttentionStatusModel> builder)
        {
            builder
                .HasKey(e => e.StatusId)
                .HasName("AttentionStatus_PK");
         
            builder.Property(p => p.Descrription).HasMaxLength(30);
            builder
                .HasMany(e => e.Attentions)
                .WithOne(e => e.AttentionStatus)
                .HasForeignKey(e => e.AttentionStatusId)
                .IsRequired();
        }
    }
}
