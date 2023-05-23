using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace computer_info.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComputerInfo",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    LevelName = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Brand = table.Column<string>(nullable: true),
                    CPU = table.Column<string>(nullable: true),
                    RAM = table.Column<string>(nullable: true),
                    StorageSize = table.Column<int>(nullable: false),
                    isSSD = table.Column<bool>(nullable: false),
                    isActive = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    CreatedUserId = table.Column<string>(nullable: true),
                    UpdatedUserOd = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputerInfo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComputerInfo");
        }
    }
}
