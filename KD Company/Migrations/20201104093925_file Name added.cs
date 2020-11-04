using Microsoft.EntityFrameworkCore.Migrations;

namespace KD_Company.Migrations
{
    public partial class fileNameadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "cardetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "cardetails");
        }
    }
}
