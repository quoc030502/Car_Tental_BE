using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace basic_api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTable9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_chats_users_UserFromId",
                table: "chats");

            migrationBuilder.DropForeignKey(
                name: "FK_chats_users_UserToId",
                table: "chats");

            migrationBuilder.RenameColumn(
                name: "UserToId",
                table: "chats",
                newName: "ToUserId");

            migrationBuilder.RenameColumn(
                name: "UserFromId",
                table: "chats",
                newName: "FromUserId");

            migrationBuilder.RenameIndex(
                name: "IX_chats_UserToId",
                table: "chats",
                newName: "IX_chats_ToUserId");

            migrationBuilder.RenameIndex(
                name: "IX_chats_UserFromId",
                table: "chats",
                newName: "IX_chats_FromUserId");

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

            migrationBuilder.RenameColumn(
                name: "ToUserId",
                table: "chats",
                newName: "UserToId");

            migrationBuilder.RenameColumn(
                name: "FromUserId",
                table: "chats",
                newName: "UserFromId");

            migrationBuilder.RenameIndex(
                name: "IX_chats_ToUserId",
                table: "chats",
                newName: "IX_chats_UserToId");

            migrationBuilder.RenameIndex(
                name: "IX_chats_FromUserId",
                table: "chats",
                newName: "IX_chats_UserFromId");

            migrationBuilder.UpdateData(
                table: "car_types",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 10, 19, 5, 7, 27, 338, DateTimeKind.Utc).AddTicks(2020), new DateTime(2024, 10, 19, 5, 7, 27, 338, DateTimeKind.Utc).AddTicks(2020) });

            migrationBuilder.UpdateData(
                table: "car_types",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 10, 19, 5, 7, 27, 338, DateTimeKind.Utc).AddTicks(2030), new DateTime(2024, 10, 19, 5, 7, 27, 338, DateTimeKind.Utc).AddTicks(2030) });

            migrationBuilder.UpdateData(
                table: "cars",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 10, 19, 5, 7, 27, 338, DateTimeKind.Utc).AddTicks(2050), new DateTime(2024, 10, 19, 5, 7, 27, 338, DateTimeKind.Utc).AddTicks(2050) });

            migrationBuilder.UpdateData(
                table: "cars",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 10, 19, 5, 7, 27, 338, DateTimeKind.Utc).AddTicks(2070), new DateTime(2024, 10, 19, 5, 7, 27, 338, DateTimeKind.Utc).AddTicks(2070) });

            migrationBuilder.AddForeignKey(
                name: "FK_chats_users_UserFromId",
                table: "chats",
                column: "UserFromId",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_chats_users_UserToId",
                table: "chats",
                column: "UserToId",
                principalTable: "users",
                principalColumn: "id");
        }
    }
}
