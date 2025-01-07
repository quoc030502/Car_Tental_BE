using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace basic_api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTable16 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_cars_CarId",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_CarId",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "orders");

            migrationBuilder.UpdateData(
                table: "car_types",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 10, 29, 3, 12, 15, 436, DateTimeKind.Utc).AddTicks(2140), new DateTime(2024, 10, 29, 3, 12, 15, 436, DateTimeKind.Utc).AddTicks(2140) });

            migrationBuilder.UpdateData(
                table: "car_types",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 10, 29, 3, 12, 15, 436, DateTimeKind.Utc).AddTicks(2150), new DateTime(2024, 10, 29, 3, 12, 15, 436, DateTimeKind.Utc).AddTicks(2150) });

            migrationBuilder.UpdateData(
                table: "cars",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 10, 29, 3, 12, 15, 436, DateTimeKind.Utc).AddTicks(2170), new DateTime(2024, 10, 29, 3, 12, 15, 436, DateTimeKind.Utc).AddTicks(2170) });

            migrationBuilder.UpdateData(
                table: "cars",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 10, 29, 3, 12, 15, 436, DateTimeKind.Utc).AddTicks(2170), new DateTime(2024, 10, 29, 3, 12, 15, 436, DateTimeKind.Utc).AddTicks(2170) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "orders",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_orders_CarId",
                table: "orders",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_cars_CarId",
                table: "orders",
                column: "CarId",
                principalTable: "cars",
                principalColumn: "id");
        }
    }
}