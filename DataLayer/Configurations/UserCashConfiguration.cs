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
    public class UserCashConfiguration : IEntityTypeConfiguration<UserCashModel>
    {
        public void Configure(EntityTypeBuilder<UserCashModel> builder)
        {
            builder
                .HasKey(e => new { e.UserId, e.CashId });

            builder
                .HasOne(e => e.User)
                .WithMany(e => e.UsersCashes)
                .HasForeignKey(e => e.UserId);
            builder
                .HasOne(e => e.Cash)
                .WithMany(e => e.UsersCashes)
                .HasForeignKey(e => e.CashId);
        }
    }
}
