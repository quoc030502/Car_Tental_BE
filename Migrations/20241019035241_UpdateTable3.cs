using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace basic_api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTable3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "chats",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    from_id = table.Column<int>(type: "int", nullable: true),
                    to_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chats", x => x.id);
                    table.ForeignKey(
                        name: "FK_chats_orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "orders",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "messages",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    chat_id = table.Column<int>(type: "int", nullable: true),
                    sender_id = table.Column<int>(type: "int", nullable: true),
                    text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_messages", x => x.id);
                    table.ForeignKey(
                        name: "FK_messages_chats_chat_id",
                        column: x => x.chat_id,
                        principalTable: "chats",
                        principalColumn: "id");
                });

            migrationBuilder.UpdateData(
                table: "car_types",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 10, 19, 3, 52, 41, 401, DateTimeKind.Utc).AddTicks(8020), new DateTime(2024, 10, 19, 3, 52, 41, 401, DateTimeKind.Utc).AddTicks(8020) });

            migrationBuilder.UpdateData(
                table: "car_types",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 10, 19, 3, 52, 41, 401, DateTimeKind.Utc).AddTicks(8020), new DateTime(2024, 10, 19, 3, 52, 41, 401, DateTimeKind.Utc).AddTicks(8020) });

            migrationBuilder.UpdateData(
                table: "cars",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 10, 19, 3, 52, 41, 401, DateTimeKind.Utc).AddTicks(8040), new DateTime(2024, 10, 19, 3, 52, 41, 401, DateTimeKind.Utc).AddTicks(8040) });

            migrationBuilder.UpdateData(
                table: "cars",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 10, 19, 3, 52, 41, 401, DateTimeKind.Utc).AddTicks(8050), new DateTime(2024, 10, 19, 3, 52, 41, 401, DateTimeKind.Utc).AddTicks(8050) });

            migrationBuilder.CreateIndex(
                name: "IX_chats_OrderId",
                table: "chats",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_messages_chat_id",
                table: "messages",
                column: "chat_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "messages");

            migrationBuilder.DropTable(
                name: "chats");

            migrationBuilder.UpdateData(
                table: "car_types",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 10, 19, 3, 50, 26, 490, DateTimeKind.Utc).AddTicks(7860), new DateTime(2024, 10, 19, 3, 50, 26, 490, DateTimeKind.Utc).AddTicks(7860) });

            migrationBuilder.UpdateData(
                table: "car_types",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 10, 19, 3, 50, 26, 490, DateTimeKind.Utc).AddTicks(7860), new DateTime(2024, 10, 19, 3, 50, 26, 490, DateTimeKind.Utc).AddTicks(7860) });

            migrationBuilder.UpdateData(
                table: "cars",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 10, 19, 3, 50, 26, 490, DateTimeKind.Utc).AddTicks(7880), new DateTime(2024, 10, 19, 3, 50, 26, 490, DateTimeKind.Utc).AddTicks(7880) });

            migrationBuilder.UpdateData(
                table: "cars",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 10, 19, 3, 50, 26, 490, DateTimeKind.Utc).AddTicks(7890), new DateTime(2024, 10, 19, 3, 50, 26, 490, DateTimeKind.Utc).AddTicks(7890) });
        }
    }
}
