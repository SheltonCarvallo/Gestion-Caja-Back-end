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
    public class CashConfiguration : IEntityTypeConfiguration<CashModel>
    {
        public void Configure(EntityTypeBuilder<CashModel> builder)
        {
            builder
               .HasKey(e => e.CashId)
               .HasName("Cash_PK");
            builder.Property(p => p.CashDescription).HasMaxLength(50);
            builder.Property(p => p.active).HasMaxLength(1);
            /*builder
                .HasMany(e => e.Users)
                .WithMany(e => e.Cashes)
                .UsingEntity<UserCashModel>(
                    l => l.HasOne<UserModel>().WithMany().HasForeignKey(e => e.UserId),
                    r => r.HasOne<CashModel>().WithMany().HasForeignKey(e => e.CashId)
                );*/
        }
    }
}
