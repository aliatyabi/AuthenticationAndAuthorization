using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "InsertDateTime", "Password", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 7, 26, 12, 5, 42, 246, DateTimeKind.Local).AddTicks(3608), "12345", "UserName 1" },
                    { 2, new DateTime(2022, 7, 26, 12, 5, 42, 246, DateTimeKind.Local).AddTicks(3731), "12345", "UserName 2" },
                    { 3, new DateTime(2022, 7, 26, 12, 5, 42, 246, DateTimeKind.Local).AddTicks(3757), "12345", "UserName 3" },
                    { 4, new DateTime(2022, 7, 26, 12, 5, 42, 246, DateTimeKind.Local).AddTicks(3781), "12345", "UserName 4" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
