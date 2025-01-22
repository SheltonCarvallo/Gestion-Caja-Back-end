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
               .HasKey(e => e.UserId)
               .HasName("Relation_user_PK");
            builder
                .HasKey(e => e.CashId)
                .HasName("Relation_cash_PK");                
        }
    }
}
