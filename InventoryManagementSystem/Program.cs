
using InventoryManagementSystem.Data;
using InventoryManagementSystem.Services;
using InventoryManagementSystem.UnitOfWork_Contract;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;

namespace InventoryManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers()
            .AddJsonOptions(options =>
             {
                 options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());//for serializing enum
             });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            builder.Services.AddDbContext<InventorySystemContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            });

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                 .AddEntityFrameworkStores<InventorySystemContext>();

            //Setting Authanticatio  Middleware check using JWTToke
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme =
                    JwtBearerDefaults.AuthenticationScheme;//check using jwt toke
                options.DefaultChallengeScheme =
                    JwtBearerDefaults.AuthenticationScheme; //redrect response in case not found cookie | token
                options.DefaultScheme =
                    JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new()
                {
                    ValidateIssuer = true,
                    ValidIssuer = builder.Configuration["JWT:Iss"],//proivder
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["JWT:Aud"],
                    IssuerSigningKey = new SymmetricSecurityKey
                    (Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
                };
            });
            //unitofwork
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            //service
            builder.Services.AddScoped<ProductService, ProductService>();
            builder.Services.AddScoped<TransactionHistoryService, TransactionHistoryService>();
            builder.Services.AddScoped<ProductStockService, ProductStockService>();
            //repository
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<ITransactionHistoryRepository, TransactionHistoryRepository>();
            builder.Services.AddScoped<IProductStockRepository, ProductStockRepository>();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
        
    }
}
