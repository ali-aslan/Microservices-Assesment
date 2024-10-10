using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sale.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupplierID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShipperID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SellerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Email", "Name", "Phone", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("0cd23974-eb16-484a-9c5c-56287c63c64f"), new DateTime(2024, 10, 10, 21, 18, 25, 611, DateTimeKind.Local).AddTicks(4620), null, "charlie.brown@example.com", "Charlie Brown", "+1223344556", null },
                    { new Guid("1d44b7f4-ba6d-4f7a-a5a3-8ae3c9aeb5a1"), new DateTime(2024, 10, 10, 21, 18, 25, 611, DateTimeKind.Local).AddTicks(4371), null, "customer_two@test.com", "Jane Smith", "+1987654321", null },
                    { new Guid("54813738-73ac-4efc-be5d-89d07cd4c337"), new DateTime(2024, 10, 10, 21, 18, 25, 611, DateTimeKind.Local).AddTicks(4614), null, "alice.johnson@example.com", "Alice Johnson", "+1098765432", null },
                    { new Guid("a2abb0c3-3fe6-4d27-917f-27406251c503"), new DateTime(2024, 10, 10, 21, 18, 25, 611, DateTimeKind.Local).AddTicks(4618), null, "bob.williams@example.com", "Bob Williams", "+1122334455", null },
                    { new Guid("c9bf9e57-1685-4c89-bdcf-5698f00a4d78"), new DateTime(2024, 10, 10, 21, 18, 25, 611, DateTimeKind.Local).AddTicks(4314), null, "customer_one@test.com", "John Doe", "+1234567890", null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryName", "CreatedDate", "DeletedDate", "Name", "Price", "StockQuantity", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("3f2504e0-4f89-11d3-9a0c-0305e82c3301"), "Automotive", new DateTime(2024, 10, 10, 21, 18, 25, 612, DateTimeKind.Local).AddTicks(9314), null, "UltraGrip 5000 Tires", 149.95m, 300, null },
                    { new Guid("6dcb4b0c-f3d8-4725-af41-9ae757ef13e1"), "Photography", new DateTime(2024, 10, 10, 21, 18, 25, 612, DateTimeKind.Local).AddTicks(9333), null, "Professional DSLR Camera", 1499.99m, 50, null },
                    { new Guid("6f9619ff-8b86-d011-b42d-00cf4fc964ff"), "Electronics", new DateTime(2024, 10, 10, 21, 18, 25, 612, DateTimeKind.Local).AddTicks(9303), null, "SmartWatch Pro", 199.99m, 150, null },
                    { new Guid("7fdf433f-a6b6-4cd8-b801-9f56e197c633"), "Kitchen Appliances", new DateTime(2024, 10, 10, 21, 18, 25, 612, DateTimeKind.Local).AddTicks(9327), null, "HealthMaster Blender", 79.99m, 100, null },
                    { new Guid("e1f28cb7-3b18-4165-ad02-2b036e30d0ac"), "Outdoor Gear", new DateTime(2024, 10, 10, 21, 18, 25, 612, DateTimeKind.Local).AddTicks(9330), null, "Adventure Backpack", 129.50m, 75, null }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreatedDate", "CustomerID", "DeletedDate", "ProductID", "SellerID", "ShipperID", "SupplierID", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("06ef57c5-8e9b-4992-be4e-6027183956e4"), new DateTime(2024, 10, 10, 21, 18, 25, 612, DateTimeKind.Local).AddTicks(4224), new Guid("c9bf9e57-1685-4c89-bdcf-5698f00a4d78"), null, new Guid("6f9619ff-8b86-d011-b42d-00cf4fc964ff"), new Guid("f65a5e9f-621d-4e5c-91f9-0a8e357929b2"), new Guid("b19b03b2-fe50-4c30-beac-41a3c648e721"), new Guid("5d7ddf1b-1f2f-4a72-ac0a-0106e2912b34"), null },
                    { new Guid("a000ce5a-b1c6-4a80-a607-88903b7f5f3c"), new DateTime(2024, 10, 10, 21, 18, 25, 612, DateTimeKind.Local).AddTicks(4242), new Guid("1d44b7f4-ba6d-4f7a-a5a3-8ae3c9aeb5a1"), null, new Guid("3f2504e0-4f89-11d3-9a0c-0305e82c3301"), new Guid("f65a5e9f-621d-4e5c-91f9-0a8e357929b2"), new Guid("a5a07aab-706b-4a30-97a5-25b0d37bd6ab"), new Guid("e462e1a5-b32c-44d3-a74b-fa60c1e76d89"), null }
                });

            migrationBuilder.CreateIndex(
                name: "UK_Customers_Name",
                table: "Customers",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerID",
                table: "Orders",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductID",
                table: "Orders",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "UK_Products_Name",
                table: "Products",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
