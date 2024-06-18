using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class SettingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Sliders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 16, 9, 42, 5, 467, DateTimeKind.Utc).AddTicks(6374),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 16, 7, 8, 28, 851, DateTimeKind.Utc).AddTicks(8205));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ShopSliders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 16, 9, 42, 5, 467, DateTimeKind.Utc).AddTicks(3644),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 16, 7, 8, 28, 851, DateTimeKind.Utc).AddTicks(6689));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 16, 9, 42, 5, 466, DateTimeKind.Utc).AddTicks(8853),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 16, 7, 8, 28, 851, DateTimeKind.Utc).AddTicks(4481));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Faq",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 16, 9, 42, 5, 466, DateTimeKind.Utc).AddTicks(1597),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 16, 7, 8, 28, 850, DateTimeKind.Utc).AddTicks(9071));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Colors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 16, 9, 42, 5, 466, DateTimeKind.Utc).AddTicks(5379),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 16, 7, 8, 28, 851, DateTimeKind.Utc).AddTicks(1586));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 16, 9, 42, 5, 464, DateTimeKind.Utc).AddTicks(2915),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 16, 7, 8, 28, 849, DateTimeKind.Utc).AddTicks(4411));

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Sliders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 16, 7, 8, 28, 851, DateTimeKind.Utc).AddTicks(8205),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 16, 9, 42, 5, 467, DateTimeKind.Utc).AddTicks(6374));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ShopSliders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 16, 7, 8, 28, 851, DateTimeKind.Utc).AddTicks(6689),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 16, 9, 42, 5, 467, DateTimeKind.Utc).AddTicks(3644));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 16, 7, 8, 28, 851, DateTimeKind.Utc).AddTicks(4481),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 16, 9, 42, 5, 466, DateTimeKind.Utc).AddTicks(8853));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Faq",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 16, 7, 8, 28, 850, DateTimeKind.Utc).AddTicks(9071),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 16, 9, 42, 5, 466, DateTimeKind.Utc).AddTicks(1597));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Colors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 16, 7, 8, 28, 851, DateTimeKind.Utc).AddTicks(1586),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 16, 9, 42, 5, 466, DateTimeKind.Utc).AddTicks(5379));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 16, 7, 8, 28, 849, DateTimeKind.Utc).AddTicks(4411),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 16, 9, 42, 5, 464, DateTimeKind.Utc).AddTicks(2915));
        }
    }
}
