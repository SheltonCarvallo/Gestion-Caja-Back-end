using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModelLayer.Models;

namespace DataLayer.Configurations
{
    public class DeviceConfiguration : IEntityTypeConfiguration<DeviceModel>
    {
        public void Configure(EntityTypeBuilder<DeviceModel> builder)
        {
            builder
                .HasKey(e => e.DeviceId)
                .HasName("Device_PK");
            builder.Property(p => p.DeviceName).HasMaxLength(50);
            builder
               .HasOne(e => e.Service)
               .WithOne(e => e.Device)
               .HasForeignKey<DeviceModel>(e => e.ServiceId)
               .IsRequired();
        }
    }
}
