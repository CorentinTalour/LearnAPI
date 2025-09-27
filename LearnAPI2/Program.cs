using LearnAPI2.Data;
using LearnAPI2.Services;
using Microsoft.EntityFrameworkCore;

namespace LearnAPI2;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        // Récupère la chaîne de connexion
        string? connect = builder.Configuration.GetConnectionString("ConnexionBDD");

        builder.Services.AddDbContext<Contexte>(opt => opt.UseSqlServer(connect)
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
        
        //Ajoute les services métiers
        builder.Services.AddScoped<IServiceLivres, ServiceLivres>();
        builder.Services.AddScoped<IServiceAvis, ServiceAvis>();
        
        // Add services to the container.
        builder.Services.AddAuthorization();

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyOrigin()
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
        
        app.UseHttpsRedirection();
        
        app.UseCors("AllowAll");

        app.UseAuthorization();
        
        app.MapControllers();

        app.Run();
    }
}