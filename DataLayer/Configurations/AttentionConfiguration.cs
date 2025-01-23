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
    public class AttentionConfiguration : IEntityTypeConfiguration<AttentionModel>
    {
        public void Configure(EntityTypeBuilder<AttentionModel> builder)
        {
            builder
                  .HasKey(e => e.AttentionId)
                  .HasName("Attention_PK");
            builder.Property(p => p.AttentionTypeId).HasMaxLength(3);
            builder
                .HasOne(e => e.AttentionType)
                .WithOne(e => e.Attention)
                .HasForeignKey<AttentionModel>(e => e.AttentionTypeId)
                .IsRequired();

            builder
                .HasOne(e => e.AttentionStatus)
                .WithOne(e => e.Attention)
                .HasForeignKey<AttentionModel>(e => e.AttentionStatusId)
                .IsRequired();
            builder
                .HasOne(e => e.Client)
                .WithOne(e => e.Attention)
                .HasForeignKey<AttentionModel>(e => e.ClientId)
                .IsRequired();
            builder
                .HasOne(e => e.Turn)
                .WithOne(e => e.Attention)
                .HasForeignKey<AttentionModel>(e => e.TurnId)
                .IsRequired();
        }
    }
}
