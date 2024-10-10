using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Dealer.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shippers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shippers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Shippers",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "Phone", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("a5a07aab-706b-4a30-97a5-25b0d37bd6ab"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "FastTrack Logistics", "+987654321", null },
                    { new Guid("b19b03b2-fe50-4c30-beac-41a3c648e721"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Global Express", "+123456789", null }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "ContactName", "CreatedDate", "DeletedDate", "Name", "Phone", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("5d7ddf1b-1f2f-4a72-ac0a-0106e2912b34"), "Alice Johnson", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TechSource Supplies", "+1122334455", null },
                    { new Guid("e462e1a5-b32c-44d3-a74b-fa60c1e76d89"), "Bob Williams", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "HomeGoods Wholesale", "+9988776655", null }
                });

            migrationBuilder.CreateIndex(
                name: "UK_Shippers_Name",
                table: "Shippers",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UK_Suppliers_Name",
                table: "Suppliers",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shippers");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
