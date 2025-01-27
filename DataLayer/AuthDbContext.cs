using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ModelLayer.Models;

namespace DataLayer
{
    public class AuthDbContext : IdentityDbContext<AppUserModel>
    {
        private readonly IConfiguration _configuration;
        public AuthDbContext(DbContextOptions<AuthDbContext> options, IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("AuthConnection"));
        }
    }
}
