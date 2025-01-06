using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace basic_api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTable12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "cars_rented",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "contract",
                table: "orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "car_types",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 10, 19, 5, 22, 30, 436, DateTimeKind.Utc).AddTicks(750), new DateTime(2024, 10, 19, 5, 22, 30, 436, DateTimeKind.Utc).AddTicks(750) });

            migrationBuilder.UpdateData(
                table: "car_types",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 10, 19, 5, 22, 30, 436, DateTimeKind.Utc).AddTicks(750), new DateTime(2024, 10, 19, 5, 22, 30, 436, DateTimeKind.Utc).AddTicks(750) });

            migrationBuilder.UpdateData(
                table: "cars",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 10, 19, 5, 22, 30, 436, DateTimeKind.Utc).AddTicks(770), new DateTime(2024, 10, 19, 5, 22, 30, 436, DateTimeKind.Utc).AddTicks(770) });

            migrationBuilder.UpdateData(
                table: "cars",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 10, 19, 5, 22, 30, 436, DateTimeKind.Utc).AddTicks(780), new DateTime(2024, 10, 19, 5, 22, 30, 436, DateTimeKind.Utc).AddTicks(780) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "cars_rented",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cars_rented",
                table: "users");

            migrationBuilder.DropColumn(
                name: "contract",
                table: "orders");

            migrationBuilder.UpdateData(
                table: "car_types",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 10, 19, 5, 18, 18, 797, DateTimeKind.Utc).AddTicks(6610), new DateTime(2024, 10, 19, 5, 18, 18, 797, DateTimeKind.Utc).AddTicks(6610) });

            migrationBuilder.UpdateData(
                table: "car_types",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 10, 19, 5, 18, 18, 797, DateTimeKind.Utc).AddTicks(6620), new DateTime(2024, 10, 19, 5, 18, 18, 797, DateTimeKind.Utc).AddTicks(6620) });

            migrationBuilder.UpdateData(
                table: "cars",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 10, 19, 5, 18, 18, 797, DateTimeKind.Utc).AddTicks(6640), new DateTime(2024, 10, 19, 5, 18, 18, 797, DateTimeKind.Utc).AddTicks(6640) });

            migrationBuilder.UpdateData(
                table: "cars",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 10, 19, 5, 18, 18, 797, DateTimeKind.Utc).AddTicks(6640), new DateTime(2024, 10, 19, 5, 18, 18, 797, DateTimeKind.Utc).AddTicks(6640) });
        }
    }
}
