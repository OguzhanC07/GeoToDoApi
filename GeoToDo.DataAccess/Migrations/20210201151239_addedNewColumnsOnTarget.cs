using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GeoToDo.DataAccess.Migrations
{
    public partial class addedNewColumnsOnTarget : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AchievedTime",
                table: "Targets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "isAchieved",
                table: "Targets",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AchievedTime",
                table: "Targets");

            migrationBuilder.DropColumn(
                name: "isAchieved",
                table: "Targets");
        }
    }
}
