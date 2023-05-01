using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantWebApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedImageURLToProjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Project",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Project");
        }
    }
}
