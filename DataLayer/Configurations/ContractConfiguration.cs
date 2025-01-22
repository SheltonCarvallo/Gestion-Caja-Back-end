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
    public class ContractConfiguration : IEntityTypeConfiguration<ContractModel>
    {
        public void Configure(EntityTypeBuilder<ContractModel> builder)
        {
            builder
                .HasKey(e => e.ContractId)
                .HasName("Contract_PK");
            builder.Property(p => p.StatusContractId).HasMaxLength(3);
            builder
                .HasOne(e => e.MethodPayment)
                .WithOne(e => e.Contract)
                .HasForeignKey<ContractModel>(e => e.MethodPaymentId)
                .IsRequired();
            builder
               .HasOne(e => e.StatusContract)
               .WithOne(e => e.Contract)
               .HasForeignKey<ContractModel>(e => e.StatusContractId)
               .IsRequired();
            builder
               .HasOne(e => e.Client)
               .WithOne(e => e.Contract)
               .HasForeignKey<ContractModel>(e => e.ClientId)
               .IsRequired();
            builder
               .HasOne(e => e.Service)
               .WithOne(e => e.Contract)
               .HasForeignKey<ContractModel>(e => e.ServiceId)
               .IsRequired();
        }
    }
}
