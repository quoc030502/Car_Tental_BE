using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace basic_api.Migrations
{
    /// <inheritdoc />
    public partial class CreateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "car_types",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    detail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_car_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "coupons",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<int>(type: "int", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    discount_percent = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coupons", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    google_uid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_rent = table.Column<bool>(type: "bit", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    is_verify = table.Column<bool>(type: "bit", nullable: false),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    driving_license = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    verify_code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    verify_code_expires = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cars",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    license_plate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_in_use = table.Column<bool>(type: "bit", nullable: false),
                    price_per_hour = table.Column<int>(type: "int", nullable: false),
                    price_per_day = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    car_type_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cars", x => x.id);
                    table.ForeignKey(
                        name: "FK_cars_car_types_car_type_id",
                        column: x => x.car_type_id,
                        principalTable: "car_types",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    car_id = table.Column<int>(type: "int", nullable: true),
                    coupon_id = table.Column<int>(type: "int", nullable: true),
                    is_approval = table.Column<bool>(type: "bit", nullable: false),
                    is_pay = table.Column<bool>(type: "bit", nullable: false),
                    start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    end_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.id);
                    table.ForeignKey(
                        name: "FK_orders_cars_car_id",
                        column: x => x.car_id,
                        principalTable: "cars",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_orders_coupons_coupon_id",
                        column: x => x.coupon_id,
                        principalTable: "coupons",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_orders_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_id = table.Column<int>(type: "int", nullable: true),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comments", x => x.id);
                    table.ForeignKey(
                        name: "FK_comments_orders_order_id",
                        column: x => x.order_id,
                        principalTable: "orders",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "images",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    image_url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    order_id = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_images", x => x.id);
                    table.ForeignKey(
                        name: "FK_images_orders_order_id",
                        column: x => x.order_id,
                        principalTable: "orders",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "punishments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    order_id = table.Column<int>(type: "int", nullable: true),
                    is_pay = table.Column<bool>(type: "bit", nullable: false),
                    amount = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_punishments", x => x.id);
                    table.ForeignKey(
                        name: "FK_punishments_orders_order_id",
                        column: x => x.order_id,
                        principalTable: "orders",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_punishments_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "payments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_id = table.Column<int>(type: "int", nullable: true),
                    punishment_id = table.Column<int>(type: "int", nullable: true),
                    amount = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payments", x => x.id);
                    table.ForeignKey(
                        name: "FK_payments_orders_order_id",
                        column: x => x.order_id,
                        principalTable: "orders",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_payments_punishments_punishment_id",
                        column: x => x.punishment_id,
                        principalTable: "punishments",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "car_types",
                columns: new[] { "id", "created_at", "detail", "type", "updated_at" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 18, 5, 24, 26, 903, DateTimeKind.Utc).AddTicks(550), "An automatic car shifts gears on its own without a manual clutch. It offers a smoother, easier driving experience. Many drivers prefer it for convenience.", "Automatic Car", new DateTime(2024, 10, 18, 5, 24, 26, 903, DateTimeKind.Utc).AddTicks(550) },
                    { 2, new DateTime(2024, 10, 18, 5, 24, 26, 903, DateTimeKind.Utc).AddTicks(550), "An electric car runs on electricity instead of fuel. It’s eco-friendly and quieter than traditional cars. Many drivers choose it for sustainability.", "Electric Car", new DateTime(2024, 10, 18, 5, 24, 26, 903, DateTimeKind.Utc).AddTicks(550) }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "created_at", "driving_license", "email", "google_uid", "is_active", "is_rent", "is_verify", "password", "phone", "role", "updated_at", "username", "verify_code", "verify_code_expires" },
                values: new object[] { 1, null, "", "admin@gmail.com", "", true, false, true, "AQAAAAIAAYagAAAAEGl3jelov24IEW8Zr037HzEkXVuuOJZCc7t6eVK5/AxxfCNoQANr0rt8kQazCmW0fA==", "0999999999", "Admin", null, "Admin", "", null });

            migrationBuilder.InsertData(
                table: "cars",
                columns: new[] { "id", "car_type_id", "created_at", "is_in_use", "license_plate", "name", "price_per_day", "price_per_hour", "updated_at" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 10, 18, 5, 24, 26, 903, DateTimeKind.Utc).AddTicks(570), false, "92A-12312", "HYUNDAI ACCENT", 800000, 100000, new DateTime(2024, 10, 18, 5, 24, 26, 903, DateTimeKind.Utc).AddTicks(570) },
                    { 2, 1, new DateTime(2024, 10, 18, 5, 24, 26, 903, DateTimeKind.Utc).AddTicks(580), false, "43A-42256", "KIA CERATO", 900000, 120000, new DateTime(2024, 10, 18, 5, 24, 26, 903, DateTimeKind.Utc).AddTicks(580) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_cars_car_type_id",
                table: "cars",
                column: "car_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_comments_order_id",
                table: "comments",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_images_order_id",
                table: "images",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_car_id",
                table: "orders",
                column: "car_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_coupon_id",
                table: "orders",
                column: "coupon_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_user_id",
                table: "orders",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_payments_order_id",
                table: "payments",
                column: "order_id",
                unique: true,
                filter: "[order_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_payments_punishment_id",
                table: "payments",
                column: "punishment_id",
                unique: true,
                filter: "[punishment_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_punishments_order_id",
                table: "punishments",
                column: "order_id",
                unique: true,
                filter: "[order_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_punishments_user_id",
                table: "punishments",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comments");

            migrationBuilder.DropTable(
                name: "images");

            migrationBuilder.DropTable(
                name: "payments");

            migrationBuilder.DropTable(
                name: "punishments");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "cars");

            migrationBuilder.DropTable(
                name: "coupons");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "car_types");
        }
    }
}
