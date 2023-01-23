using Microsoft.EntityFrameworkCore;
using WeatherInfo.Domain.Entitites;

namespace WeatherInfo.Infrastructure.Db;

public class WeatherInfoDbContext : DbContext
{
	public WeatherInfoDbContext(DbContextOptions options) : base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<WeatherInformation>().ToTable("WeatherInformationLogs");

		base.OnModelCreating(modelBuilder);
	}
}
