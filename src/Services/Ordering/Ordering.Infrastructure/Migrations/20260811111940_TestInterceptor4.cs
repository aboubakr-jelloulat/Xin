using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ordering.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TestInterceptor4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "l9lawi",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "l9lawi",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "l9lawi",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "l9lawi",
                table: "Customers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "l9lawi",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "l9lawi",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "l9lawi",
                table: "OrderItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "l9lawi",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
