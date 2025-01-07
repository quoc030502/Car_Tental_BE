using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace basic_api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTable15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "car_types",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 10, 29, 3, 12, 0, 68, DateTimeKind.Utc).AddTicks(5270), new DateTime(2024, 10, 29, 3, 12, 0, 68, DateTimeKind.Utc).AddTicks(5270) });

            migrationBuilder.UpdateData(
                table: "car_types",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 10, 29, 3, 12, 0, 68, DateTimeKind.Utc).AddTicks(5270), new DateTime(2024, 10, 29, 3, 12, 0, 68, DateTimeKind.Utc).AddTicks(5270) });

            migrationBuilder.UpdateData(
                table: "cars",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 10, 29, 3, 12, 0, 68, DateTimeKind.Utc).AddTicks(5290), new DateTime(2024, 10, 29, 3, 12, 0, 68, DateTimeKind.Utc).AddTicks(5290) });

            migrationBuilder.UpdateData(
                table: "cars",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 10, 29, 3, 12, 0, 68, DateTimeKind.Utc).AddTicks(5300), new DateTime(2024, 10, 29, 3, 12, 0, 68, DateTimeKind.Utc).AddTicks(5300) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "car_types",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 10, 29, 3, 11, 11, 320, DateTimeKind.Utc).AddTicks(3580), new DateTime(2024, 10, 29, 3, 11, 11, 320, DateTimeKind.Utc).AddTicks(3580) });

            migrationBuilder.UpdateData(
                table: "car_types",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 10, 29, 3, 11, 11, 320, DateTimeKind.Utc).AddTicks(3580), new DateTime(2024, 10, 29, 3, 11, 11, 320, DateTimeKind.Utc).AddTicks(3580) });

            migrationBuilder.UpdateData(
                table: "cars",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 10, 29, 3, 11, 11, 320, DateTimeKind.Utc).AddTicks(3600), new DateTime(2024, 10, 29, 3, 11, 11, 320, DateTimeKind.Utc).AddTicks(3600) });

            migrationBuilder.UpdateData(
                table: "cars",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 10, 29, 3, 11, 11, 320, DateTimeKind.Utc).AddTicks(3610), new DateTime(2024, 10, 29, 3, 11, 11, 320, DateTimeKind.Utc).AddTicks(3610) });
        }
    }
}