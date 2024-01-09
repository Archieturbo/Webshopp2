using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Webshop2.Migrations
{
    /// <inheritdoc />
    public partial class adress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Orderdetail",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Adress",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Orderdetail");

            migrationBuilder.DropColumn(
                name: "Adress",
                table: "Customer");
        }
    }
}
