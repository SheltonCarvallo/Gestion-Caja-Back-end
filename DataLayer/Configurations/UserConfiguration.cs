using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModelLayer.Models;

namespace DataLayer.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder
                .HasKey(e => e.UserId)
                .HasName("User_PK");
            builder.Property(p => p.UserName).HasMaxLength(50);
            builder.Property(p => p.Email).HasMaxLength(100);
            builder.Property(p => p.Password).HasMaxLength(100);
            /*builder
                .HasOne(e => e.Rol)
                .WithOne(e => e.User)
                .HasForeignKey<UserModel>(e => e.RolId)
                .IsRequired();

            builder
                .HasOne(e => e.UserStatus)
                .WithOne(e => e.User)
                .HasForeignKey<UserModel>(e => e.UserStatusId)
                .IsRequired();*/
        }
    }
}
