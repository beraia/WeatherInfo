using Microsoft.EntityFrameworkCore;
using WeatherInfo.Infrastructure.Db;
using WeatherInfo.Services.Abstract;
using WeatherInfo.Services.Concreate;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<WeatherInfoDbContext>(ctx=> ctx.UseSqlServer(connectionString));

builder.Services.AddScoped<IWeatherInformationService, WeatherInformationService>();
builder.Services.AddScoped<IWeatherService, WeatherService>();

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

app.UseAuthorization();

app.MapControllers();

var dbContext = app.Services.CreateScope().ServiceProvider.GetRequiredService<WeatherInfoDbContext>();
dbContext.Database.Migrate();

app.Run();
