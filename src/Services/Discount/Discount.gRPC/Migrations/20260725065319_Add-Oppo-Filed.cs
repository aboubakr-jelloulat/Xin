using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Discount.gRPC.Migrations
{
    /// <inheritdoc />
    public partial class AddOppoFiled : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "coubons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "ProductName" },
                values: new object[] { "Oppo Discount", "Opoo" });

            migrationBuilder.InsertData(
                table: "coubons",
                columns: new[] { "Id", "Amount", "Description", "ProductName" },
                values: new object[] { 3, 100, "Samsung Discount", "Samsung 10" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "coubons",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "coubons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "ProductName" },
                values: new object[] { "Samsung Discount", "Samsung 10" });
        }
    }
}
