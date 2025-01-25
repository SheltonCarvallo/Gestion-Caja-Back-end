using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModelLayer.Models;

namespace DataLayer.Configurations
{
    public class UserStatusConfiguration : IEntityTypeConfiguration<UserStatusModel>
    {
        public void Configure(EntityTypeBuilder<UserStatusModel> builder)
        {
            builder
                .HasKey(e => e.StatusId)
                .HasName("UserStatus_PK");
            builder.Property(p => p.StatusId).HasMaxLength(3);
            builder.Property(p => p.Description).HasMaxLength(50);
            builder
                .HasMany(e => e.Users)
                .WithOne(e => e.UserStatus)
                .HasForeignKey(e => e.UserStatusId)
                .IsRequired();
        }
    }
}
