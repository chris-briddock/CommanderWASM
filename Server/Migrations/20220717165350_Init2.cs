using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Commander.WASM.Server.Migrations
{
    public partial class Init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Commands",
                keyColumn: "Id",
                keyValue: new Guid("8a60c403-8081-4a8d-8377-bdc0a6f7a1be"));

            migrationBuilder.InsertData(
                table: "Commands",
                columns: new[] { "Id", "CommandString", "OperatingSystem", "Parameters", "ParametersSummary", "RuntimeEnvironment" },
                values: new object[] { new Guid("346b6152-bd7f-4f3c-b461-348aad1330c5"), "dotnet", "All", "new api", "Create a new api.", "All" });

            migrationBuilder.InsertData(
                table: "Commands",
                columns: new[] { "Id", "CommandString", "OperatingSystem", "Parameters", "ParametersSummary", "RuntimeEnvironment" },
                values: new object[] { new Guid("91057720-99b8-43d4-bc73-07732bfc60ab"), "dotnet", "All", "ef migrations", "Create a new api.", "All" });

            migrationBuilder.InsertData(
                table: "Commands",
                columns: new[] { "Id", "CommandString", "OperatingSystem", "Parameters", "ParametersSummary", "RuntimeEnvironment" },
                values: new object[] { new Guid("b25bffff-64f6-4107-92b6-ce8704707726"), "dotnet", "All", "new console", "Create a new console app.", "All" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Commands",
                keyColumn: "Id",
                keyValue: new Guid("346b6152-bd7f-4f3c-b461-348aad1330c5"));

            migrationBuilder.DeleteData(
                table: "Commands",
                keyColumn: "Id",
                keyValue: new Guid("91057720-99b8-43d4-bc73-07732bfc60ab"));

            migrationBuilder.DeleteData(
                table: "Commands",
                keyColumn: "Id",
                keyValue: new Guid("b25bffff-64f6-4107-92b6-ce8704707726"));

            migrationBuilder.InsertData(
                table: "Commands",
                columns: new[] { "Id", "CommandString", "OperatingSystem", "Parameters", "ParametersSummary", "RuntimeEnvironment" },
                values: new object[] { new Guid("8a60c403-8081-4a8d-8377-bdc0a6f7a1be"), "dotnet", "All", "new console", "Create a new console app.", "All" });
        }
    }
}
