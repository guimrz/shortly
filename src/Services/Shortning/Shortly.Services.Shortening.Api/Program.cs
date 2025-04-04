
using Shortly.Services.Shortening.Application.Extensions;
using Shortly.Services.Shortening.Repository.Extensions;

namespace Shortly.Services.Shortening.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddShorteningServiceApplication();
            builder.Services.AddShorteningServiceRepository();

            builder.Services.AddControllers();

            builder.Services.AddOpenApi();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
