using Microsoft.EntityFrameworkCore.Migrations;

namespace GeoToDo.DataAccess.Migrations
{
    public partial class ActivityImagesTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePaths",
                table: "Activities");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePaths",
                table: "Activities",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }
    }
}
