using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class ShopSliderTableCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Sliders",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 11, 20, 19, 1, 503, DateTimeKind.Utc).AddTicks(1722));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedDate",
                table: "Sliders",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 11, 20, 19, 1, 503, DateTimeKind.Utc).AddTicks(1369));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Sliders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 11, 22, 59, 55, 920, DateTimeKind.Utc).AddTicks(9377),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 11, 20, 19, 1, 503, DateTimeKind.Utc).AddTicks(625));

            migrationBuilder.CreateTable(
                name: "ShopSliders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 6, 11, 22, 59, 55, 920, DateTimeKind.Utc).AddTicks(6612)),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopSliders", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShopSliders");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Sliders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 11, 20, 19, 1, 503, DateTimeKind.Utc).AddTicks(1722),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedDate",
                table: "Sliders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 11, 20, 19, 1, 503, DateTimeKind.Utc).AddTicks(1369),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Sliders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 11, 20, 19, 1, 503, DateTimeKind.Utc).AddTicks(625),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 11, 22, 59, 55, 920, DateTimeKind.Utc).AddTicks(9377));
        }
    }
}
