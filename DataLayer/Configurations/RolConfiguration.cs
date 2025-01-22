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
    public class RolConfiguration : IEntityTypeConfiguration<RolModel>
    {
        public void Configure(EntityTypeBuilder<RolModel> builder)
        {
            builder
               .HasKey(e => e.RolId)
               .HasName("Rol_PK");
            builder.Property(p => p.RolDescription).HasMaxLength(50);

        }
    }
}
