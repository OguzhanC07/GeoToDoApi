using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GeoToDo.DataAccess.Migrations
{
    public partial class newUpdatesOnSubActivityAndActivity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "SubActivities");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "SubActivities");

            migrationBuilder.DropColumn(
                name: "SelectedTime",
                table: "SubActivities");

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "Activities",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "Activities");

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "SubActivities",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "SubActivities",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SelectedTime",
                table: "SubActivities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
