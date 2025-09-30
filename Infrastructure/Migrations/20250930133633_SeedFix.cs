using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Trains",
                keyColumn: "Id",
                keyValue: new Guid("2fb1a38d-068e-47b4-b270-6acc0882ad25"));

            migrationBuilder.DeleteData(
                table: "Trains",
                keyColumn: "Id",
                keyValue: new Guid("a029b781-f7c2-4496-9e9d-0b6811f54124"));

            migrationBuilder.InsertData(
                table: "Trains",
                columns: new[] { "Id", "Created", "TrainNumber", "TrainType", "Updated" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "73271", 0, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "73272", 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Trains",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Trains",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.InsertData(
                table: "Trains",
                columns: new[] { "Id", "Created", "TrainNumber", "TrainType", "Updated" },
                values: new object[,]
                {
                    { new Guid("2fb1a38d-068e-47b4-b270-6acc0882ad25"), new DateTime(2025, 9, 30, 14, 53, 33, 147, DateTimeKind.Local).AddTicks(7208), "73271", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a029b781-f7c2-4496-9e9d-0b6811f54124"), new DateTime(2025, 9, 30, 14, 53, 33, 150, DateTimeKind.Local).AddTicks(4574), "73272", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }
    }
}
