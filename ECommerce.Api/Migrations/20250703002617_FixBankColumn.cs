using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Server.Migrations
{
    /// <inheritdoc />
    public partial class FixBankColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bank",
                table: "PaymentTickets");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "bank",
                table: "PaymentTickets",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
