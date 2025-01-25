using DataLayer;
using GestionDeCajas.Authentication;
using GestionDeCajas.Authentication.Models;
using GestionDeCajas.Interfaces;
using GestionDeCajas.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;


namespace GestionDeCajas
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddScoped<IRegister, RegisterService>();
            builder.Services.AddScoped<IClient, ClientService>();

            builder.Services.AddDbContext<CashAdminDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionDefault")));

            builder.Services.AddDbContext<AuthDbContext>();

            builder.Services.AddIdentityCore<AppUserModel>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AuthDbContext>()
                .AddDefaultTokenProviders();

            builder.Services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                }
            ).AddJwtBearer(options =>
                {
                    string? secret = builder.Configuration["JwtConfig:Secret"];
                    string? issuer = builder.Configuration["JwtConfig:ValidIssuer"];
                    string? audience = builder.Configuration["JwtConfig:ValidAudiences"];

                    if (secret is null || issuer is null || audience is null)
                    {
                        throw new ApplicationException("Jwt is not set in the configuration");
                    }

                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidAudience = audience,
                        ValidIssuer = issuer,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
                    };
                }
             );

            WebApplication app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthentication();
            app.UseAuthorization();

            //Check if the roles exist, if not they are created

            using (IServiceScope serviceScope = app.Services.CreateScope())
            {
                IServiceProvider services = serviceScope.ServiceProvider;

                //ensure the database is created
                DbContext dbContext = services.GetRequiredService<AuthDbContext>();
                //dbContext.Database.EnsureDeleted()
                dbContext.Database.EnsureCreated();
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                if(!await roleManager.RoleExistsAsync(AppRoles.Administrador))
                {
                    await roleManager.CreateAsync(new IdentityRole(AppRoles.Administrador));
                }
                if(!await roleManager.RoleExistsAsync(AppRoles.Gestor))
                {
                    await roleManager.CreateAsync(new IdentityRole(AppRoles.Gestor));
                }
                if (!await roleManager.RoleExistsAsync(AppRoles.Cajero))
                {
                    await roleManager.CreateAsync(new IdentityRole(AppRoles.Cajero));
                }
                if (!await roleManager.RoleExistsAsync(AppRoles.Cliente))
                {
                    await roleManager.CreateAsync(new IdentityRole(AppRoles.Cliente));
                }



            }

            app.MapControllers();

            app.Run();
        }
    }
}
