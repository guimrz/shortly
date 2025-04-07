
using Scalar.AspNetCore;
using Shortly.Services.Shortlinks.Application.Extensions;
using Shortly.Services.Shortlinks.Repository.Extensions;

namespace Shortly.Services.Shortlinks.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddShortlinksServiceApplication();
            builder.Services.AddShortlinksServiceRepository(builder.Configuration);

            builder.Services.AddControllers();

            builder.Services.AddOpenApi();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference(config =>
                {
                    config.Title = "Products API";
                    config.Theme = ScalarTheme.Default;
                    config.HiddenClients = true;
                    config.HideModels = true;
                    config.DotNetFlag = true;
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.UseShortlinksServiceRepository();

            app.Run();
        }
    }
}
