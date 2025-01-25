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
    public class MethodPaymentConfiguration : IEntityTypeConfiguration<MethodPaymentModel>
    {
        public void Configure(EntityTypeBuilder<MethodPaymentModel> builder)
        {
            builder
                .HasKey(e => e.MethodPaymentId)
                .HasName("MethodPayment_PK");
            builder.Property(p => p.Description).HasMaxLength(50);
            builder
                .HasMany(e => e.Contracts)
                .WithOne(e => e.MethodPayment)
                .HasForeignKey(e => e.MethodPaymentId)
                .IsRequired();
        }
    }
}
