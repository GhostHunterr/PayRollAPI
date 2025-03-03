
using Microsoft.EntityFrameworkCore;
using PayRollApi.Models;

namespace PayRollApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var myAllowSpecificOrigins = "myAllowSpecificOrigins";

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddDbContext<DataContext>(Options =>
            {
                Options.UseSqlServer(builder.Configuration.GetConnectionString("Myconnection"));
            });

            //Enable CORS
            builder.Services.AddCors(opitons =>
            {
                opitons.AddPolicy(name: myAllowSpecificOrigins, builder =>
                {
                    builder.WithOrigins("http://localhost:4200") //Angular
                    //builder.WithOrigins("http://localhost:3000") //React
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(myAllowSpecificOrigins);

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
