using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace basic_api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTable8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserFromId",
                table: "chats",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserToId",
                table: "chats",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_chats_UserFromId",
                table: "chats",
                column: "UserFromId");

            migrationBuilder.CreateIndex(
                name: "IX_chats_UserToId",
                table: "chats",
                column: "UserToId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_chats_users_UserFromId",
                table: "chats");

            migrationBuilder.DropForeignKey(
                name: "FK_chats_users_UserToId",
                table: "chats");

            migrationBuilder.DropIndex(
                name: "IX_chats_UserFromId",
                table: "chats");

            migrationBuilder.DropIndex(
                name: "IX_chats_UserToId",
                table: "chats");

            migrationBuilder.DropColumn(
                name: "UserFromId",
                table: "chats");

            migrationBuilder.DropColumn(
                name: "UserToId",
                table: "chats");

            migrationBuilder.UpdateData(
                table: "car_types",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 10, 19, 5, 5, 53, 537, DateTimeKind.Utc).AddTicks(8230), new DateTime(2024, 10, 19, 5, 5, 53, 537, DateTimeKind.Utc).AddTicks(8230) });

            migrationBuilder.UpdateData(
                table: "car_types",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 10, 19, 5, 5, 53, 537, DateTimeKind.Utc).AddTicks(8230), new DateTime(2024, 10, 19, 5, 5, 53, 537, DateTimeKind.Utc).AddTicks(8230) });

            migrationBuilder.UpdateData(
                table: "cars",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 10, 19, 5, 5, 53, 537, DateTimeKind.Utc).AddTicks(8260), new DateTime(2024, 10, 19, 5, 5, 53, 537, DateTimeKind.Utc).AddTicks(8260) });

            migrationBuilder.UpdateData(
                table: "cars",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 10, 19, 5, 5, 53, 537, DateTimeKind.Utc).AddTicks(8260), new DateTime(2024, 10, 19, 5, 5, 53, 537, DateTimeKind.Utc).AddTicks(8260) });
        }
    }
}
