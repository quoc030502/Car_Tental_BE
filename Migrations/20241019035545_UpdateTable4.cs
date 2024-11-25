using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace basic_api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTable4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FromUserId",
                table: "chats",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ToUserId",
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

            migrationBuilder.CreateIndex(
                name: "IX_chats_ToUserId",
                table: "chats",
                column: "ToUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_chats_users_FromUserId",
                table: "chats",
                column: "FromUserId",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_chats_users_ToUserId",
                table: "chats",
                column: "ToUserId",
                principalTable: "users",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_chats_users_FromUserId",
                table: "chats");

            migrationBuilder.DropForeignKey(
                name: "FK_chats_users_ToUserId",
                table: "chats");

            migrationBuilder.DropIndex(
                name: "IX_chats_FromUserId",
                table: "chats");

            migrationBuilder.DropIndex(
                name: "IX_chats_ToUserId",
                table: "chats");

            migrationBuilder.DropColumn(
                name: "FromUserId",
                table: "chats");

            migrationBuilder.DropColumn(
                name: "ToUserId",
                table: "chats");

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
        }
    }
}
