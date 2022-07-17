using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Commander.WASM.Server.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Commands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommandString = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Parameters = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParametersSummary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RuntimeEnvironment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OperatingSystem = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commands", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Commands",
                columns: new[] { "Id", "CommandString", "OperatingSystem", "Parameters", "ParametersSummary", "RuntimeEnvironment" },
                values: new object[] { new Guid("8a60c403-8081-4a8d-8377-bdc0a6f7a1be"), "dotnet", "All", "new console", "Create a new console app.", "All" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commands");
        }
    }
}
