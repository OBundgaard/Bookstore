
using API.Contexts;
using API.Repositories;
using Bookstore.Core.Interfaces;
using Bookstore.Core.Models;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });

            builder.Services.AddMemoryCache();

            builder.Services.AddScoped<AuthorRepository>();
            builder.Services.AddScoped<INoSQLRepository<Author>, CachedAuthorRepository>();

            builder.Services.AddScoped<BookRepository>();
            builder.Services.AddScoped<IRelationalRepository<Book>, CachedBookRepository>();

            builder.Services.AddScoped<CustomerRepository>();
            builder.Services.AddScoped<IRelationalRepository<Customer>, CachedCustomerRepository>();

            builder.Services.AddScoped<OrderRepository>();
            builder.Services.AddScoped<IRelationalRepository<Bookstore.Core.Models.Order>, CachedOrderRepository>();

            builder.Services.AddScoped<StockLevelRepository>();
            builder.Services.AddScoped<INoSQLRepository<StockLevel>, CachedStockLevelRepository>();


            builder.Services.AddDbContext<RelationalDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("BookstoreConnection"), sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(10),
                        errorNumbersToAdd: null
                    );
                });
            });
            builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
            {
                var redisConnection = builder.Configuration.GetConnectionString("RedisConnection");
                return ConnectionMultiplexer.Connect(redisConnection);
            });

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
