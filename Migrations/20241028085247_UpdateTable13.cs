using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace basic_api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTable13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "contract",
                table: "orders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "cost",
                table: "orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "is_deposit",
                table: "orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "car_types",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 10, 28, 8, 52, 47, 124, DateTimeKind.Utc).AddTicks(1240), new DateTime(2024, 10, 28, 8, 52, 47, 124, DateTimeKind.Utc).AddTicks(1240) });

            migrationBuilder.UpdateData(
                table: "car_types",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 10, 28, 8, 52, 47, 124, DateTimeKind.Utc).AddTicks(1240), new DateTime(2024, 10, 28, 8, 52, 47, 124, DateTimeKind.Utc).AddTicks(1240) });

            migrationBuilder.UpdateData(
                table: "cars",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 10, 28, 8, 52, 47, 124, DateTimeKind.Utc).AddTicks(1260), new DateTime(2024, 10, 28, 8, 52, 47, 124, DateTimeKind.Utc).AddTicks(1260) });

            migrationBuilder.UpdateData(
                table: "cars",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 10, 28, 8, 52, 47, 124, DateTimeKind.Utc).AddTicks(1270), new DateTime(2024, 10, 28, 8, 52, 47, 124, DateTimeKind.Utc).AddTicks(1270) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cost",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "is_deposit",
                table: "orders");

            migrationBuilder.AlterColumn<string>(
                name: "contract",
                table: "orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
        }
    }
}