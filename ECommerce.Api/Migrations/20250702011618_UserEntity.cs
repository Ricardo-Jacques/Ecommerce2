using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Server.Migrations
{
    /// <inheritdoc />
    public partial class UserEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Cpf = table.Column<string>(type: "text", nullable: false),
                    AddressCep = table.Column<string>(type: "text", nullable: false),
                    AddressUf = table.Column<string>(type: "text", nullable: false),
                    AddressLocality = table.Column<string>(type: "text", nullable: false),
                    AddressNeighborhood = table.Column<string>(type: "text", nullable: false),
                    AddressStreet = table.Column<string>(type: "text", nullable: false),
                    AddressNumber = table.Column<string>(type: "text", nullable: false),
                    Addresscomplement = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
