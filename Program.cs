namespace Horas
{
    class Program
    {
        public static void Main(string[] args)
        {
            //estoy intentando crear una api
            var builder = WebApplication.CreateBuilder();
            builder.Services.AddSwaggerGen();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddControllers();

            var app = builder.Build();
            
            app.UseSwagger();
            app.UseSwaggerUI();
            app.MapControllers();
            
            Console.WriteLine("Ya esta corriendo mi api :)))");
            app.Run("http://localhost:4050/");
        }
    }
}