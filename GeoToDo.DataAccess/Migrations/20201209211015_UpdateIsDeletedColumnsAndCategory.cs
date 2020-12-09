using Microsoft.EntityFrameworkCore.Migrations;

namespace GeoToDo.DataAccess.Migrations
{
    public partial class UpdateIsDeletedColumnsAndCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CategoryActivities_ActivityId",
                table: "CategoryActivities");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryActivities_ActivityId_CategoryId",
                table: "CategoryActivities",
                columns: new[] { "ActivityId", "CategoryId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CategoryActivities_ActivityId_CategoryId",
                table: "CategoryActivities");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryActivities_ActivityId",
                table: "CategoryActivities",
                column: "ActivityId");
        }
    }
}
