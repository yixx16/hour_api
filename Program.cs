using Horas.Controllers;
using Horas.Persistence;
using Horas.Services;
using Microsoft.EntityFrameworkCore;

namespace Horas
{
    class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder();

            //services
            builder.Services.AddSwaggerGen();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddControllers();

            //db
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<HourContext>(options =>
                options.UseNpgsql(connectionString));

            //dependency inyection
            builder.Services.AddScoped<IHourRepository, HourRepository>();
            builder.Services.AddScoped<HourService>();


            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();

            //configurar el middleware para capturar excepciones de not found y demas, para evitar usar try catch en controllers

            app.MapControllers();


            Console.WriteLine("Ya esta corriendo mi api :)))");
            /* params hands on lab
            path and query params, with common uses
            app.MapGet("", () => "Hello world!");
            app.MapGet("/users/{userId}/posts/{slug}", (int userId, string slug) =>
            {
                return $"Hello {userId}, the post {slug} isn't avalaible right now :/, try later...";
            });
            app.MapGet("/report/{year?}", (int? year = 2026) =>
            {
                return $"the report for the {year} isnt avalaible right now :/ \nTry later";
            });

            app.MapGet("/search", (string? q, int page = 1) 
                => $"alrigth there u got the {page} page for {q} \n Good luck"
            );

            app.MapGet("/files/{*path}", (string path)=> $"are you looking for?: '{path}'");

            */

            app.Run("http://localhost:4050/");
        }
    }
}