using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AppUserUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "AspNetUsers",
                newName: "Surname");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Sliders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 16, 23, 46, 30, 585, DateTimeKind.Utc).AddTicks(9344),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 16, 17, 4, 45, 970, DateTimeKind.Utc).AddTicks(7080));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ShopSliders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 16, 23, 46, 30, 585, DateTimeKind.Utc).AddTicks(6224),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 16, 17, 4, 45, 970, DateTimeKind.Utc).AddTicks(4662));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 16, 23, 46, 30, 584, DateTimeKind.Utc).AddTicks(8335),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 16, 17, 4, 45, 970, DateTimeKind.Utc).AddTicks(361));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Faq",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 16, 23, 46, 30, 583, DateTimeKind.Utc).AddTicks(9471),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 16, 17, 4, 45, 968, DateTimeKind.Utc).AddTicks(8736));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Colors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 16, 23, 46, 30, 584, DateTimeKind.Utc).AddTicks(4330),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 16, 17, 4, 45, 969, DateTimeKind.Utc).AddTicks(6018));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 16, 23, 46, 30, 581, DateTimeKind.Utc).AddTicks(2726),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 16, 17, 4, 45, 965, DateTimeKind.Utc).AddTicks(8621));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "AspNetUsers",
                newName: "FullName");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Sliders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 16, 17, 4, 45, 970, DateTimeKind.Utc).AddTicks(7080),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 16, 23, 46, 30, 585, DateTimeKind.Utc).AddTicks(9344));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ShopSliders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 16, 17, 4, 45, 970, DateTimeKind.Utc).AddTicks(4662),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 16, 23, 46, 30, 585, DateTimeKind.Utc).AddTicks(6224));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 16, 17, 4, 45, 970, DateTimeKind.Utc).AddTicks(361),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 16, 23, 46, 30, 584, DateTimeKind.Utc).AddTicks(8335));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Faq",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 16, 17, 4, 45, 968, DateTimeKind.Utc).AddTicks(8736),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 16, 23, 46, 30, 583, DateTimeKind.Utc).AddTicks(9471));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Colors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 16, 17, 4, 45, 969, DateTimeKind.Utc).AddTicks(6018),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 16, 23, 46, 30, 584, DateTimeKind.Utc).AddTicks(4330));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 16, 17, 4, 45, 965, DateTimeKind.Utc).AddTicks(8621),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 16, 23, 46, 30, 581, DateTimeKind.Utc).AddTicks(2726));
        }
    }
}
