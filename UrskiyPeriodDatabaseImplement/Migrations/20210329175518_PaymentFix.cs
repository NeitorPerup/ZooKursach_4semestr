using Microsoft.EntityFrameworkCore.Migrations;

namespace UrskiyPeriodDatabaseImplement.Migrations
{
    public partial class PaymentFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullSum",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "PaidSum",
                table: "Payment");

            migrationBuilder.AddColumn<decimal>(
                name: "Sum",
                table: "Payment",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sum",
                table: "Payment");

            migrationBuilder.AddColumn<decimal>(
                name: "FullSum",
                table: "Payment",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PaidSum",
                table: "Payment",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
