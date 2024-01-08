using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Webshop2.Migrations
{
    /// <inheritdoc />
    public partial class okej : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Size",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Orderdetail");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "Orderdetail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
