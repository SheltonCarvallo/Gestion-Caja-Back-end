using DataLayer.Configurations;
using Microsoft.EntityFrameworkCore;
using ModelLayer.Models;


namespace DataLayer
{
    public class CashAdminDbContext : DbContext
    {
        public CashAdminDbContext(DbContextOptions<CashAdminDbContext> options) : base(options)
        {

        }

        public CashAdminDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("data source=DESKTOP-REDKEOB;initial catalog=CashAdministratorDevelopment;user id= PortalApi;password=123456;TrustServerCertificate=True;MultipleActiveResultSets=true");


        public DbSet<UserModel> Users => Set<UserModel>();
        public DbSet<UserStatusModel> UserStatuses => Set<UserStatusModel>();
        public DbSet<RolModel> Rols => Set<RolModel>();
        public DbSet<DeviceModel> Devices => Set<DeviceModel>();
        public DbSet<ServiceModel> Services => Set<ServiceModel>();
        public DbSet<ContractModel> Contracts => Set<ContractModel>();
        public DbSet<ClientModel> Clients => Set<ClientModel>();
        public DbSet<MethodPaymentModel> PaymentMethods => Set<MethodPaymentModel>();
        public DbSet<StatusContractModel> StatusContracts => Set<StatusContractModel>();
        public DbSet<PaymentsModel> Payments => Set<PaymentsModel>();
        public DbSet<AttentionModel> Attentions => Set<AttentionModel>();
        public DbSet<AttentionTypeModel> AttentiontTypes => Set<AttentionTypeModel>();
        public DbSet<AttentionStatusModel> AttentionsStatuses => Set<AttentionStatusModel>();
        public DbSet<TurnModel> Turns => Set<TurnModel>();
        public DbSet<UserCashModel> UsersCashes => Set<UserCashModel>();
        public DbSet<CashModel> Cashs => Set<CashModel>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new AttentionConfiguration().Configure(modelBuilder.Entity<AttentionModel>());
            new AttentionStatusConfiguration().Configure(modelBuilder.Entity<AttentionStatusModel>());
            new AttentionTypeConfiguration().Configure(modelBuilder.Entity<AttentionTypeModel>());
            new CashConfiguration().Configure(modelBuilder.Entity<CashModel>());
            new ClientConfiguration().Configure(modelBuilder.Entity<ClientModel>());
            new ContractConfiguration().Configure(modelBuilder.Entity<ContractModel>());
            new DeviceConfiguration().Configure(modelBuilder.Entity<DeviceModel>());
            new MethodPaymentConfiguration().Configure(modelBuilder.Entity<MethodPaymentModel>());
            new RolConfiguration().Configure(modelBuilder.Entity<RolModel>());
            new ServiceConfiguration().Configure(modelBuilder.Entity<ServiceModel>());
            new StatusContractConfiguration().Configure(modelBuilder.Entity<StatusContractModel>());
            new TurnConfiguration().Configure(modelBuilder.Entity<TurnModel>());
            new UserCashConfiguration().Configure(modelBuilder.Entity<UserCashModel>());
            new UserConfiguration().Configure(modelBuilder.Entity<UserModel>());
            new UserStatusConfiguration().Configure(modelBuilder.Entity<UserStatusModel>());
            new PaymentConfiguration().Configure(modelBuilder.Entity<PaymentsModel>());


        }
    }
}
