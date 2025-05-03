
using Employee_Management_System.Configurations;
using Employee_Management_System.Context;
using Employee_Management_System.Entities;
using Employee_Management_System.Repositories;
using Employee_Management_System.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Employee_Management_System
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<DataContext>(options =>
                options.UseSqlite(builder.Configuration["ConnectionStrings:Default"]));
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddAutoMapper(typeof(MapperConfig));

            //add CORS
            var allowedOrigins = builder.Configuration.GetValue<string>("AllowedOrigins")!.Split(",");
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    //to allow requests from Angular app
                    policy.WithOrigins(allowedOrigins)
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
