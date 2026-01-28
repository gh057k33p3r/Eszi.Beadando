
using Eszi.Beadando.Database;
using Eszi.Beadando.Server.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Eszi.Beadando.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthenticationServices(builder.Configuration);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors();

            builder.Services.AddDbContext<CoreDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString(nameof(CoreDbContext))));

            var app = builder.Build();

            // Adatbázist migrálja automatikusan indításnál
            using var scope = app.Services.CreateScope();
            using var coreDbContext = scope.ServiceProvider.GetRequiredService<CoreDbContext>();
            coreDbContext.Database.Migrate();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseDefaultFiles();
            app.MapStaticAssets();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseCors(builder =>
            {
                builder
                    .WithOrigins("http://localhost:3000")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });

            app.UseMiddleware<AuthorizationHeaderSetterMiddleware>();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}
