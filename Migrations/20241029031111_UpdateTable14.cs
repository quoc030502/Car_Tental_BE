using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace basic_api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTable14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_cars_car_id",
                table: "orders");

            migrationBuilder.RenameColumn(
                name: "car_id",
                table: "orders",
                newName: "CarId");

            migrationBuilder.RenameIndex(
                name: "IX_orders_car_id",
                table: "orders",
                newName: "IX_orders_CarId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_orders_cars_CarId",
                table: "orders",
                column: "CarId",
                principalTable: "cars",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_cars_CarId",
                table: "orders");

            migrationBuilder.RenameColumn(
                name: "CarId",
                table: "orders",
                newName: "car_id");

            migrationBuilder.RenameIndex(
                name: "IX_orders_CarId",
                table: "orders",
                newName: "IX_orders_car_id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_orders_cars_car_id",
                table: "orders",
                column: "car_id",
                principalTable: "cars",
                principalColumn: "id");
        }
    }
}