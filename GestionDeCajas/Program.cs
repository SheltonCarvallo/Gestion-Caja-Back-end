using DataLayer;
using Microsoft.EntityFrameworkCore;


namespace GestionDeCajas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddDbContext<CashAdminDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionDefault")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
