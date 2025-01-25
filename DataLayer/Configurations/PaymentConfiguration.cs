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
    public class PaymentConfiguration : IEntityTypeConfiguration<PaymentsModel>
    {
        public void Configure(EntityTypeBuilder<PaymentsModel> builder)
        {
            builder
                .HasKey(e => e.PaymentId)
                .HasName("Payments_PK");
        }
    }
}