using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace basic_api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTable10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "to_id",
                table: "chats",
                newName: "chats_to_users");

            migrationBuilder.RenameColumn(
                name: "from_id",
                table: "chats",
                newName: "chats_from_users");

            migrationBuilder.UpdateData(
                table: "car_types",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 10, 19, 5, 17, 35, 909, DateTimeKind.Utc).AddTicks(7340), new DateTime(2024, 10, 19, 5, 17, 35, 909, DateTimeKind.Utc).AddTicks(7340) });

            migrationBuilder.UpdateData(
                table: "car_types",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 10, 19, 5, 17, 35, 909, DateTimeKind.Utc).AddTicks(7340), new DateTime(2024, 10, 19, 5, 17, 35, 909, DateTimeKind.Utc).AddTicks(7340) });

            migrationBuilder.UpdateData(
                table: "cars",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 10, 19, 5, 17, 35, 909, DateTimeKind.Utc).AddTicks(7370), new DateTime(2024, 10, 19, 5, 17, 35, 909, DateTimeKind.Utc).AddTicks(7370) });

            migrationBuilder.UpdateData(
                table: "cars",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 10, 19, 5, 17, 35, 909, DateTimeKind.Utc).AddTicks(7370), new DateTime(2024, 10, 19, 5, 17, 35, 909, DateTimeKind.Utc).AddTicks(7370) });

            migrationBuilder.CreateIndex(
                name: "IX_chats_chats_from_users",
                table: "chats",
                column: "chats_from_users");

            migrationBuilder.CreateIndex(
                name: "IX_chats_chats_to_users",
                table: "chats",
                column: "chats_to_users");

            migrationBuilder.AddForeignKey(
                name: "FK_chats_users_chats_from_users",
                table: "chats",
                column: "chats_from_users",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_chats_users_chats_to_users",
                table: "chats",
                column: "chats_to_users",
                principalTable: "users",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_chats_users_chats_from_users",
                table: "chats");

            migrationBuilder.DropForeignKey(
                name: "FK_chats_users_chats_to_users",
                table: "chats");

            migrationBuilder.DropIndex(
                name: "IX_chats_chats_from_users",
                table: "chats");

            migrationBuilder.DropIndex(
                name: "IX_chats_chats_to_users",
                table: "chats");

            migrationBuilder.RenameColumn(
                name: "chats_to_users",
                table: "chats",
                newName: "to_id");

            migrationBuilder.RenameColumn(
                name: "chats_from_users",
                table: "chats",
                newName: "from_id");

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
                values: new object[] { new DateTime(2024, 10, 19, 5, 16, 9, 0, DateTimeKind.Utc).AddTicks(1880), new DateTime(2024, 10, 19, 5, 16, 9, 0, DateTimeKind.Utc).AddTicks(1880) });

            migrationBuilder.UpdateData(
                table: "car_types",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 10, 19, 5, 16, 9, 0, DateTimeKind.Utc).AddTicks(1890), new DateTime(2024, 10, 19, 5, 16, 9, 0, DateTimeKind.Utc).AddTicks(1890) });

            migrationBuilder.UpdateData(
                table: "cars",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 10, 19, 5, 16, 9, 0, DateTimeKind.Utc).AddTicks(1910), new DateTime(2024, 10, 19, 5, 16, 9, 0, DateTimeKind.Utc).AddTicks(1910) });

            migrationBuilder.UpdateData(
                table: "cars",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 10, 19, 5, 16, 9, 0, DateTimeKind.Utc).AddTicks(1910), new DateTime(2024, 10, 19, 5, 16, 9, 0, DateTimeKind.Utc).AddTicks(1910) });

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
    }
}
