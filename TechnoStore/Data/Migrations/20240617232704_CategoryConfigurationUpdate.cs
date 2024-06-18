using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class CategoryConfigurationUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Sliders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 18, 3, 27, 2, 785, DateTimeKind.Utc).AddTicks(7619),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 16, 23, 46, 30, 585, DateTimeKind.Utc).AddTicks(9344));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ShopSliders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 18, 3, 27, 2, 785, DateTimeKind.Utc).AddTicks(3091),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 16, 23, 46, 30, 585, DateTimeKind.Utc).AddTicks(6224));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Settings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 18, 3, 27, 2, 784, DateTimeKind.Utc).AddTicks(5513),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 18, 3, 27, 2, 783, DateTimeKind.Utc).AddTicks(7991),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 16, 23, 46, 30, 584, DateTimeKind.Utc).AddTicks(8335));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Faq",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 18, 3, 27, 2, 782, DateTimeKind.Utc).AddTicks(7230),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 16, 23, 46, 30, 583, DateTimeKind.Utc).AddTicks(9471));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Colors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 18, 3, 27, 2, 783, DateTimeKind.Utc).AddTicks(2509),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 16, 23, 46, 30, 584, DateTimeKind.Utc).AddTicks(4330));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 18, 3, 27, 2, 780, DateTimeKind.Utc).AddTicks(7805),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 18, 3, 27, 2, 780, DateTimeKind.Utc).AddTicks(3248),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 16, 23, 46, 30, 581, DateTimeKind.Utc).AddTicks(2726));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Sliders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 16, 23, 46, 30, 585, DateTimeKind.Utc).AddTicks(9344),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 18, 3, 27, 2, 785, DateTimeKind.Utc).AddTicks(7619));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ShopSliders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 16, 23, 46, 30, 585, DateTimeKind.Utc).AddTicks(6224),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 18, 3, 27, 2, 785, DateTimeKind.Utc).AddTicks(3091));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Settings",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 18, 3, 27, 2, 784, DateTimeKind.Utc).AddTicks(5513));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 16, 23, 46, 30, 584, DateTimeKind.Utc).AddTicks(8335),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 18, 3, 27, 2, 783, DateTimeKind.Utc).AddTicks(7991));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Faq",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 16, 23, 46, 30, 583, DateTimeKind.Utc).AddTicks(9471),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 18, 3, 27, 2, 782, DateTimeKind.Utc).AddTicks(7230));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Colors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 16, 23, 46, 30, 584, DateTimeKind.Utc).AddTicks(4330),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 18, 3, 27, 2, 783, DateTimeKind.Utc).AddTicks(2509));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 18, 3, 27, 2, 780, DateTimeKind.Utc).AddTicks(7805));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 16, 23, 46, 30, 581, DateTimeKind.Utc).AddTicks(2726),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 18, 3, 27, 2, 780, DateTimeKind.Utc).AddTicks(3248));
        }
    }
}
