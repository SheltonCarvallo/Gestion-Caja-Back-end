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
    public class TurnConfiguration : IEntityTypeConfiguration<TurnModel>
    {
        public void Configure(EntityTypeBuilder<TurnModel> builder)
        {
            builder
                .HasKey(e => e.TurnId)
                .HasName("Tun_PK");
            builder.Property(p => p.Description).HasMaxLength(7);
            builder
                .HasOne(e => e.Cash)
                .WithOne(e => e.Turn)
                .HasForeignKey<TurnModel>(e => e.CashId)
                .IsRequired();
        }
    }
}
