using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UsuariosApi.Migrations
{
    public partial class customidntityuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataDeNascimento",
                table: "AspNetUsers",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99997,
                column: "ConcurrencyStamp",
                value: "cd9c2fd5-6179-4cc0-b2b1-f10bf3657bee");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "6a6d08f2-cbda-4dcc-88f9-ad2f09466946");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bad9a2eb-c035-4c6c-945c-03456be7d185", "AQAAAAEAACcQAAAAENOTyNxIkCcfnCuTMLqnHKFxjosm7+B74qeaFE07HxZh9iI+9vviW2aBdSdACjjpFA==", "1db68fcc-38f0-4e4d-b69d-d4f0c42f3b93" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataDeNascimento",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99997,
                column: "ConcurrencyStamp",
                value: "1b8a7bd0-a412-4c7d-a378-118f897f8383");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "44ac59be-6a9f-4ee5-9f31-05927e206b3f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "482d36f6-c7a5-43d1-b4b8-5db0850b1239", "AQAAAAEAACcQAAAAEDjKOB4b0SPCbQnoBK/gUwnQZqCardiVnf6iWcQS1tc95jgOtUHWLStjzx8dcrqQIg==", "6c53dd0d-15cb-4531-a4b9-7baed114c92a" });
        }
    }
}
