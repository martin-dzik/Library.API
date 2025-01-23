
using Library.API.Configurations;
using Library.API.Contracts;
using Library.API.Data;
using Library.API.Repository;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

namespace Library.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const string allowAllPolicy = "AllowAll";
            const string dbConnectionString = "LibraryDbConnectionString";


            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString(dbConnectionString);

            builder.Services.AddDbContext<LibraryDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(allowAllPolicy, policy =>
                {
                    policy
                        .AllowAnyHeader()
                        .AllowAnyOrigin()
                        .AllowAnyMethod();
                });
            });

            builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped<IBooksRepository, BooksRepository>();
            builder.Services.AddScoped<IAuthorsRepository, AuthorsRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference(options =>
                {
                    options
                        .WithTitle("Library API")
                        .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
                });
            }

            app.UseHttpsRedirection();

            app.UseCors(allowAllPolicy);

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
