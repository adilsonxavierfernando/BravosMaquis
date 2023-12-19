
using BM.Core.Shared.ModelViews;
using BM.Data.Context;
using BM.Data.Repository;
using BM.Manager.Implementation;
using BM.Manager.Interfaces;
using BM.Manager.Mappings;
using BM.Manager.Validator;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Globalization;



string ambiente = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .AddJsonFile($"appsettings.{ambiente}.json")
    .Build();

Log.Logger = new LoggerConfiguration()
    //.Enrich.FromLogContext()
    //.WriteTo.Async(x=>x.File("\\Logs\\log.txt",fileSizeLimitBytes:100000, rollOnFileSizeLimit:true, rollingInterval: RollingInterval.Day))
    .ReadFrom.Configuration(configuration)
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Host.UseSerilog();
builder.Services.AddControllers()
    .AddFluentValidation(f => 
    { 
        f.RegisterValidatorsFromAssemblyContaining<NovoJogoValidator>();
        f.RegisterValidatorsFromAssemblyContaining<UpdateClubeValidator>();
        f.RegisterValidatorsFromAssemblyContaining<AtualizarJogoValidator>();
        f.RegisterValidatorsFromAssemblyContaining<NovoJogo>();

    });
builder.Services.AddAutoMapper(
    typeof(NovoClubeMappingProfile),
    typeof(UpdateClubeMappingProfile),
    typeof(NovoJogoMappingProfile),
    typeof(UpdateJogoMappingProfile));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BMContext>(options =>
options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0))));


builder.Services.AddScoped<IClubeRepository, ClubeRepository>();
builder.Services.AddScoped<IClubeManager, ClubeManager>();
builder.Services.AddScoped<IJogoManager, JogoManager>();
builder.Services.AddScoped<IJogoRepository, JogoRepository>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
using var ServiceScoped = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
using var context = ServiceScoped.ServiceProvider.GetService<BMContext>();
await context.Database.MigrateAsync();
await context.Database.EnsureCreatedAsync();

app.MapControllers();

try
{
    Log.Information("Iniciando a API RESTFULL");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Erro catastrófico");
    throw;
}
finally
{
    Log.CloseAndFlush();
}
