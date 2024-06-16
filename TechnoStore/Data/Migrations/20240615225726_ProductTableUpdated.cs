using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class ProductTableUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Sliders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 16, 2, 57, 25, 173, DateTimeKind.Utc).AddTicks(6908),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 15, 0, 28, 31, 96, DateTimeKind.Utc).AddTicks(2131));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ShopSliders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 16, 2, 57, 25, 173, DateTimeKind.Utc).AddTicks(4930),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 15, 0, 28, 31, 93, DateTimeKind.Utc).AddTicks(3813));

            migrationBuilder.AddColumn<bool>(
                name: "IsFeatured",
                table: "Products",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsNewArrivals",
                table: "Products",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsTopSelling",
                table: "Products",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TechnicalSpecs",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Faq",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 16, 2, 57, 25, 172, DateTimeKind.Utc).AddTicks(7434),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 15, 0, 28, 31, 92, DateTimeKind.Utc).AddTicks(3895));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Colors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 16, 2, 57, 25, 173, DateTimeKind.Utc).AddTicks(1262),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 15, 0, 28, 31, 93, DateTimeKind.Utc).AddTicks(692));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 16, 2, 57, 25, 171, DateTimeKind.Utc).AddTicks(2411),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 15, 0, 28, 31, 88, DateTimeKind.Utc).AddTicks(4630));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFeatured",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsNewArrivals",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsTopSelling",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TechnicalSpecs",
                table: "Products");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Sliders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 15, 0, 28, 31, 96, DateTimeKind.Utc).AddTicks(2131),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 16, 2, 57, 25, 173, DateTimeKind.Utc).AddTicks(6908));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ShopSliders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 15, 0, 28, 31, 93, DateTimeKind.Utc).AddTicks(3813),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 16, 2, 57, 25, 173, DateTimeKind.Utc).AddTicks(4930));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Faq",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 15, 0, 28, 31, 92, DateTimeKind.Utc).AddTicks(3895),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 16, 2, 57, 25, 172, DateTimeKind.Utc).AddTicks(7434));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Colors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 15, 0, 28, 31, 93, DateTimeKind.Utc).AddTicks(692),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 16, 2, 57, 25, 173, DateTimeKind.Utc).AddTicks(1262));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 15, 0, 28, 31, 88, DateTimeKind.Utc).AddTicks(4630),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 16, 2, 57, 25, 171, DateTimeKind.Utc).AddTicks(2411));
        }
    }
}
