using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddPaymentTicketEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentTickets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Bank = table.Column<string>(type: "text", nullable: false),
                    Agency = table.Column<string>(type: "text", nullable: false),
                    AccountNumber = table.Column<string>(type: "text", nullable: false),
                    bank = table.Column<string>(type: "text", nullable: false),
                    Wallet = table.Column<string>(type: "text", nullable: false),
                    BeneficiaryName = table.Column<string>(type: "text", nullable: false),
                    BeneficiaryCprf = table.Column<string>(type: "text", nullable: false),
                    BeneficiaryAddressCep = table.Column<string>(type: "text", nullable: false),
                    BeneficiaryAddressUf = table.Column<string>(type: "text", nullable: false),
                    BeneficiaryAddressLocality = table.Column<string>(type: "text", nullable: false),
                    BeneficiaryAddressNeighborhood = table.Column<string>(type: "text", nullable: false),
                    BeneficiaryAddressStreet = table.Column<string>(type: "text", nullable: false),
                    BeneficiaryAddressNumber = table.Column<string>(type: "text", nullable: false),
                    BeneficiaryAddresscomplement = table.Column<string>(type: "text", nullable: false),
                    TicketCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TicketDueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TicketDocument = table.Column<string>(type: "text", nullable: false),
                    TicketNumber = table.Column<string>(type: "text", nullable: false),
                    TicketTitle = table.Column<string>(type: "text", nullable: false),
                    TicketValue = table.Column<double>(type: "double precision", nullable: false),
                    TicketInstruction = table.Column<string>(type: "text", nullable: false),
                    PayerName = table.Column<string>(type: "text", nullable: false),
                    PayerCprf = table.Column<string>(type: "text", nullable: false),
                    PayerAddressCep = table.Column<string>(type: "text", nullable: false),
                    PayerAddressUf = table.Column<string>(type: "text", nullable: false),
                    PayerAddressLocality = table.Column<string>(type: "text", nullable: false),
                    PayerAddressNeighborhood = table.Column<string>(type: "text", nullable: false),
                    PayerAddressStreet = table.Column<string>(type: "text", nullable: false),
                    PayerAddressNumber = table.Column<string>(type: "text", nullable: false),
                    PayerAddresscomplement = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTickets", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentTickets");
        }
    }
}
