using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogTag_Blogs_BlogId",
                table: "BlogTag");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogTag_Tags_TagId",
                table: "BlogTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogTag",
                table: "BlogTag");

            migrationBuilder.RenameTable(
                name: "BlogTag",
                newName: "BlogTags");

            migrationBuilder.RenameIndex(
                name: "IX_BlogTag_TagId",
                table: "BlogTags",
                newName: "IX_BlogTags_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_BlogTag_BlogId",
                table: "BlogTags",
                newName: "IX_BlogTags_BlogId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Teams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 30, 4, 8, 9, 137, DateTimeKind.Utc).AddTicks(1089),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 29, 22, 4, 55, 863, DateTimeKind.Utc).AddTicks(5217));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Tags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 30, 4, 8, 9, 136, DateTimeKind.Utc).AddTicks(9654),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 29, 22, 4, 55, 863, DateTimeKind.Utc).AddTicks(3827));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Sliders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 30, 4, 8, 9, 136, DateTimeKind.Utc).AddTicks(8223),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 29, 22, 4, 55, 863, DateTimeKind.Utc).AddTicks(2445));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ShopSliders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 30, 4, 8, 9, 136, DateTimeKind.Utc).AddTicks(6753),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 29, 22, 4, 55, 863, DateTimeKind.Utc).AddTicks(936));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Settings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 30, 4, 8, 9, 136, DateTimeKind.Utc).AddTicks(5278),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 29, 22, 4, 55, 862, DateTimeKind.Utc).AddTicks(9451));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 30, 4, 8, 9, 136, DateTimeKind.Utc).AddTicks(3705),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 29, 22, 4, 55, 862, DateTimeKind.Utc).AddTicks(7872));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Faq",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 30, 4, 8, 9, 135, DateTimeKind.Utc).AddTicks(9870),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 29, 22, 4, 55, 862, DateTimeKind.Utc).AddTicks(3784));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Colors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 30, 4, 8, 9, 136, DateTimeKind.Utc).AddTicks(1693),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 29, 22, 4, 55, 862, DateTimeKind.Utc).AddTicks(5824));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 30, 4, 8, 9, 135, DateTimeKind.Utc).AddTicks(850),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 29, 22, 4, 55, 861, DateTimeKind.Utc).AddTicks(3751));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 30, 4, 8, 9, 134, DateTimeKind.Utc).AddTicks(9288),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 29, 22, 4, 55, 861, DateTimeKind.Utc).AddTicks(1710));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 30, 4, 8, 9, 134, DateTimeKind.Utc).AddTicks(7662),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 29, 22, 4, 55, 860, DateTimeKind.Utc).AddTicks(8990));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "BlogCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 30, 4, 8, 9, 134, DateTimeKind.Utc).AddTicks(5213),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 29, 22, 4, 55, 860, DateTimeKind.Utc).AddTicks(1972));

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogTags",
                table: "BlogTags",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogTags_Blogs_BlogId",
                table: "BlogTags",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogTags_Tags_TagId",
                table: "BlogTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogTags_Blogs_BlogId",
                table: "BlogTags");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogTags_Tags_TagId",
                table: "BlogTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogTags",
                table: "BlogTags");

            migrationBuilder.RenameTable(
                name: "BlogTags",
                newName: "BlogTag");

            migrationBuilder.RenameIndex(
                name: "IX_BlogTags_TagId",
                table: "BlogTag",
                newName: "IX_BlogTag_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_BlogTags_BlogId",
                table: "BlogTag",
                newName: "IX_BlogTag_BlogId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Teams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 29, 22, 4, 55, 863, DateTimeKind.Utc).AddTicks(5217),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 30, 4, 8, 9, 137, DateTimeKind.Utc).AddTicks(1089));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Tags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 29, 22, 4, 55, 863, DateTimeKind.Utc).AddTicks(3827),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 30, 4, 8, 9, 136, DateTimeKind.Utc).AddTicks(9654));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Sliders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 29, 22, 4, 55, 863, DateTimeKind.Utc).AddTicks(2445),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 30, 4, 8, 9, 136, DateTimeKind.Utc).AddTicks(8223));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ShopSliders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 29, 22, 4, 55, 863, DateTimeKind.Utc).AddTicks(936),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 30, 4, 8, 9, 136, DateTimeKind.Utc).AddTicks(6753));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Settings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 29, 22, 4, 55, 862, DateTimeKind.Utc).AddTicks(9451),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 30, 4, 8, 9, 136, DateTimeKind.Utc).AddTicks(5278));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 29, 22, 4, 55, 862, DateTimeKind.Utc).AddTicks(7872),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 30, 4, 8, 9, 136, DateTimeKind.Utc).AddTicks(3705));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Faq",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 29, 22, 4, 55, 862, DateTimeKind.Utc).AddTicks(3784),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 30, 4, 8, 9, 135, DateTimeKind.Utc).AddTicks(9870));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Colors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 29, 22, 4, 55, 862, DateTimeKind.Utc).AddTicks(5824),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 30, 4, 8, 9, 136, DateTimeKind.Utc).AddTicks(1693));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 29, 22, 4, 55, 861, DateTimeKind.Utc).AddTicks(3751),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 30, 4, 8, 9, 135, DateTimeKind.Utc).AddTicks(850));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 29, 22, 4, 55, 861, DateTimeKind.Utc).AddTicks(1710),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 30, 4, 8, 9, 134, DateTimeKind.Utc).AddTicks(9288));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 29, 22, 4, 55, 860, DateTimeKind.Utc).AddTicks(8990),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 30, 4, 8, 9, 134, DateTimeKind.Utc).AddTicks(7662));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "BlogCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 29, 22, 4, 55, 860, DateTimeKind.Utc).AddTicks(1972),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 30, 4, 8, 9, 134, DateTimeKind.Utc).AddTicks(5213));

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogTag",
                table: "BlogTag",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogTag_Blogs_BlogId",
                table: "BlogTag",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogTag_Tags_TagId",
                table: "BlogTag",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
