using Microsoft.EntityFrameworkCore.Migrations;

namespace computer_info.Migrations
{
    public partial class Fixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedUserOd",
                table: "ComputerInfo");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedUserId",
                table: "ComputerInfo",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedUserId",
                table: "ComputerInfo");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedUserOd",
                table: "ComputerInfo",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
