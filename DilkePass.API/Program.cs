
using DilkePass.Application.Users.Interfaces;
using DilkePass.Application.Users.Commands.CreateUser;
using DilkePass.Infrastructure.Database;
using DilkePass.Infrastructure.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using DilkePass.Application.Users.Queries.GetUser;
using DilkePass.Application.Users.Commands.AuthenticateUser;
using DilkePass.Application.Users.Commands.CreateTourAttractions;
using DilkePass.Application.Users.Queries.GetPlaces;
using DilkePass.Application.Users.Commands.CreatePrice;
using DilkePass.Infrastructure.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;


namespace DilkePass.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<DilkePassDBContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));
            
            // Dependency Injection 
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<GetUserHandler>();
            builder.Services.AddScoped<CreateUserHandler>();
            builder.Services.AddScoped<AuthenticateUserHandler>();
            builder.Services.AddScoped<GetTourAttractionbyStateHandler>();
            builder.Services.AddScoped<IPriceRepository, PriceRepository>();
            builder.Services.AddScoped<CreatePriceHandler>();

            builder.Services.AddScoped<ITourAttractionsRespository, TourAttractionRepository>();
            builder.Services.AddScoped<CreateTourAttractionHandler>();
            builder.Services.AddScoped<IJwtTokenServices, JwtTokenServices>();


            builder.Services.AddAuthentication(
                JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters =
            new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,

                ValidIssuer =
                    builder.Configuration["Jwt:Issuer"],

                ValidAudience =
                    builder.Configuration["Jwt:Audience"],

                IssuerSigningKey =
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(
                            builder.Configuration["Jwt:Key"]))
            };
    });
            builder.Services.AddScoped<IDilkePassDBContext>(provider => provider.GetRequiredService<DilkePassDBContext>());

            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
