using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantWebApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixedImageURL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagURL",
                table: "MenuItem",
                newName: "ImageURL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageURL",
                table: "MenuItem",
                newName: "ImagURL");
        }
    }
}
