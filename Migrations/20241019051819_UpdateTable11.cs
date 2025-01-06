using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace basic_api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTable11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_chats_users_chats_from_users",
                table: "chats");

            migrationBuilder.DropForeignKey(
                name: "FK_chats_users_chats_to_users",
                table: "chats");

            migrationBuilder.RenameColumn(
                name: "chats_to_users",
                table: "chats",
                newName: "to_user");

            migrationBuilder.RenameColumn(
                name: "chats_from_users",
                table: "chats",
                newName: "from_user");

            migrationBuilder.RenameIndex(
                name: "IX_chats_chats_to_users",
                table: "chats",
                newName: "IX_chats_to_user");

            migrationBuilder.RenameIndex(
                name: "IX_chats_chats_from_users",
                table: "chats",
                newName: "IX_chats_from_user");

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

            migrationBuilder.AddForeignKey(
                name: "FK_chats_users_from_user",
                table: "chats",
                column: "from_user",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_chats_users_to_user",
                table: "chats",
                column: "to_user",
                principalTable: "users",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_chats_users_from_user",
                table: "chats");

            migrationBuilder.DropForeignKey(
                name: "FK_chats_users_to_user",
                table: "chats");

            migrationBuilder.RenameColumn(
                name: "to_user",
                table: "chats",
                newName: "chats_to_users");

            migrationBuilder.RenameColumn(
                name: "from_user",
                table: "chats",
                newName: "chats_from_users");

            migrationBuilder.RenameIndex(
                name: "IX_chats_to_user",
                table: "chats",
                newName: "IX_chats_chats_to_users");

            migrationBuilder.RenameIndex(
                name: "IX_chats_from_user",
                table: "chats",
                newName: "IX_chats_chats_from_users");

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
    }
}
