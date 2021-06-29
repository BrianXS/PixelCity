using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.Migrations
{
    public partial class ModifiedAnIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Communities",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Communities_Url",
                table: "Communities",
                column: "Url",
                unique: true,
                filter: "[Url] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Communities_Url",
                table: "Communities");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Communities");
        }
    }
}
