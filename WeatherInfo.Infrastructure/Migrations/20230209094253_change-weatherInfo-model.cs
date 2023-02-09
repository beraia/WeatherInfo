using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeatherInfo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changeweatherInfomodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Temp",
                table: "WeatherInformationLogs",
                newName: "Temperature");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Temperature",
                table: "WeatherInformationLogs",
                newName: "Temp");
        }
    }
}
