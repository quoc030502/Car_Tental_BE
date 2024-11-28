using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace basic_api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTable6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_chats_users_FromToId",
                table: "chats");

            migrationBuilder.RenameColumn(
                name: "FromToId",
                table: "chats",
                newName: "FromUserId");

            migrationBuilder.RenameIndex(
                name: "IX_chats_FromToId",
                table: "chats",
                newName: "IX_chats_FromUserId");

            migrationBuilder.AlterColumn<int>(
                name: "to_id",
                table: "chats",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "car_types",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 10, 19, 5, 4, 35, 486, DateTimeKind.Utc).AddTicks(3280), new DateTime(2024, 10, 19, 5, 4, 35, 486, DateTimeKind.Utc).AddTicks(3280) });

            migrationBuilder.UpdateData(
                table: "car_types",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 10, 19, 5, 4, 35, 486, DateTimeKind.Utc).AddTicks(3290), new DateTime(2024, 10, 19, 5, 4, 35, 486, DateTimeKind.Utc).AddTicks(3290) });

            migrationBuilder.UpdateData(
                table: "cars",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 10, 19, 5, 4, 35, 486, DateTimeKind.Utc).AddTicks(3330), new DateTime(2024, 10, 19, 5, 4, 35, 486, DateTimeKind.Utc).AddTicks(3330) });

            migrationBuilder.UpdateData(
                table: "cars",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 10, 19, 5, 4, 35, 486, DateTimeKind.Utc).AddTicks(3330), new DateTime(2024, 10, 19, 5, 4, 35, 486, DateTimeKind.Utc).AddTicks(3330) });

            migrationBuilder.AddForeignKey(
                name: "FK_chats_users_FromUserId",
                table: "chats",
                column: "FromUserId",
                principalTable: "users",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_chats_users_FromUserId",
                table: "chats");

            migrationBuilder.RenameColumn(
                name: "FromUserId",
                table: "chats",
                newName: "FromToId");

            migrationBuilder.RenameIndex(
                name: "IX_chats_FromUserId",
                table: "chats",
                newName: "IX_chats_FromToId");

            migrationBuilder.AlterColumn<string>(
                name: "to_id",
                table: "chats",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_chats_users_FromToId",
                table: "chats",
                column: "FromToId",
                principalTable: "users",
                principalColumn: "id");
        }
    }
}
