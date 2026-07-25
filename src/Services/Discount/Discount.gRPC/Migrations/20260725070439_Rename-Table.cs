using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Discount.gRPC.Migrations
{
    /// <inheritdoc />
    public partial class RenameTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_coubons",
                table: "coubons");

            migrationBuilder.RenameTable(
                name: "coubons",
                newName: "Coupons");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Coupons",
                table: "Coupons",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Coupons",
                table: "Coupons");

            migrationBuilder.RenameTable(
                name: "Coupons",
                newName: "coubons");

            migrationBuilder.AddPrimaryKey(
                name: "PK_coubons",
                table: "coubons",
                column: "Id");
        }
    }
}
