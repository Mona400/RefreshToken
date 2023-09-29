using RefreshToken.Data;
using JWTAuthentication.Helpers;
using RefreshToken.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RefreshToken.Services;

namespace JWTAuthentication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            #region Default Service
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            #endregion

            #region map Jwt appsetting with JWT class

            builder.Services.Configure<JWT>(builder.Configuration.GetSection("JWT"));
            #endregion

            #region Configration Identity
            builder.Services.AddIdentity<Client, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();
            #endregion

            #region Connection String
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            #endregion

            // Register the AuthService correctly
            builder.Services.AddTransient<IAuthService, AuthService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
