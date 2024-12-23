using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace basic_api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTable5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_chats_orders_OrderId",
                table: "chats");

            migrationBuilder.DropForeignKey(
                name: "FK_chats_users_FromUserId",
                table: "chats");

            migrationBuilder.DropIndex(
                name: "IX_chats_FromUserId",
                table: "chats");

            migrationBuilder.DropColumn(
                name: "FromUserId",
                table: "chats");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "chats",
                newName: "FromToId");

            migrationBuilder.RenameIndex(
                name: "IX_chats_OrderId",
                table: "chats",
                newName: "IX_chats_FromToId");

            migrationBuilder.CreateTable(
                name: "car_orders",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_id = table.Column<int>(type: "int", nullable: true),
                    car_id = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_car_orders", x => x.id);
                    table.ForeignKey(
                        name: "FK_car_orders_cars_car_id",
                        column: x => x.car_id,
                        principalTable: "cars",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_car_orders_orders_order_id",
                        column: x => x.order_id,
                        principalTable: "orders",
                        principalColumn: "id");
                });

            migrationBuilder.UpdateData(
                table: "car_types",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 10, 19, 5, 0, 13, 949, DateTimeKind.Utc).AddTicks(2950), new DateTime(2024, 10, 19, 5, 0, 13, 949, DateTimeKind.Utc).AddTicks(2950) });

            migrationBuilder.UpdateData(
                table: "car_types",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 10, 19, 5, 0, 13, 949, DateTimeKind.Utc).AddTicks(2950), new DateTime(2024, 10, 19, 5, 0, 13, 949, DateTimeKind.Utc).AddTicks(2950) });

            migrationBuilder.UpdateData(
                table: "cars",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 10, 19, 5, 0, 13, 949, DateTimeKind.Utc).AddTicks(2980), new DateTime(2024, 10, 19, 5, 0, 13, 949, DateTimeKind.Utc).AddTicks(2980) });

            migrationBuilder.UpdateData(
                table: "cars",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 10, 19, 5, 0, 13, 949, DateTimeKind.Utc).AddTicks(2980), new DateTime(2024, 10, 19, 5, 0, 13, 949, DateTimeKind.Utc).AddTicks(2980) });

            migrationBuilder.CreateIndex(
                name: "IX_car_orders_car_id",
                table: "car_orders",
                column: "car_id");

            migrationBuilder.CreateIndex(
                name: "IX_car_orders_order_id",
                table: "car_orders",
                column: "order_id");

            migrationBuilder.AddForeignKey(
                name: "FK_chats_users_FromToId",
                table: "chats",
                column: "FromToId",
                principalTable: "users",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_chats_users_FromToId",
                table: "chats");

            migrationBuilder.DropTable(
                name: "car_orders");

            migrationBuilder.RenameColumn(
                name: "FromToId",
                table: "chats",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_chats_FromToId",
                table: "chats",
                newName: "IX_chats_OrderId");

            migrationBuilder.AddColumn<int>(
                name: "FromUserId",
                table: "chats",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "car_types",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 10, 19, 3, 55, 44, 832, DateTimeKind.Utc).AddTicks(430), new DateTime(2024, 10, 19, 3, 55, 44, 832, DateTimeKind.Utc).AddTicks(430) });

            migrationBuilder.UpdateData(
                table: "car_types",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 10, 19, 3, 55, 44, 832, DateTimeKind.Utc).AddTicks(440), new DateTime(2024, 10, 19, 3, 55, 44, 832, DateTimeKind.Utc).AddTicks(440) });

            migrationBuilder.UpdateData(
                table: "cars",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 10, 19, 3, 55, 44, 832, DateTimeKind.Utc).AddTicks(460), new DateTime(2024, 10, 19, 3, 55, 44, 832, DateTimeKind.Utc).AddTicks(460) });

            migrationBuilder.UpdateData(
                table: "cars",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 10, 19, 3, 55, 44, 832, DateTimeKind.Utc).AddTicks(460), new DateTime(2024, 10, 19, 3, 55, 44, 832, DateTimeKind.Utc).AddTicks(460) });

            migrationBuilder.CreateIndex(
                name: "IX_chats_FromUserId",
                table: "chats",
                column: "FromUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_chats_orders_OrderId",
                table: "chats",
                column: "OrderId",
                principalTable: "orders",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_chats_users_FromUserId",
                table: "chats",
                column: "FromUserId",
                principalTable: "users",
                principalColumn: "id");
        }
    }
}
