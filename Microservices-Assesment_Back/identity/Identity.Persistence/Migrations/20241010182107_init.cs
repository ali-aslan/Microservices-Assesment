using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Identity.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OperationClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    AuthenticatorType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByIp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RevokedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RevokedByIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReplacedByToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReasonRevoked = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserOperationClaims",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OperationClaimId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOperationClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserOperationClaims_OperationClaims_OperationClaimId",
                        column: x => x.OperationClaimId,
                        principalTable: "OperationClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserOperationClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Admin", null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Auth.Admin", null },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Auth.Read", null },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Auth.Write", null },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Auth.RevokeToken", null },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "OperationClaims.Admin", null },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "OperationClaims.Read", null },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "OperationClaims.Write", null },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "OperationClaims.Create", null },
                    { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "OperationClaims.Update", null },
                    { 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "OperationClaims.Delete", null },
                    { 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "UserOperationClaims.Admin", null },
                    { 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "UserOperationClaims.Read", null },
                    { 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "UserOperationClaims.Write", null },
                    { 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "UserOperationClaims.Create", null },
                    { 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "UserOperationClaims.Update", null },
                    { 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "UserOperationClaims.Delete", null },
                    { 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Users.Admin", null },
                    { 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Users.Read", null },
                    { 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Users.Write", null },
                    { 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Users.Create", null },
                    { 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Users.Update", null },
                    { 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Users.Delete", null },
                    { 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sale", null },
                    { 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sale.Admin", null },
                    { 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sale.Read", null },
                    { 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sale.Write", null },
                    { 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sale.Create", null },
                    { 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sale.Update", null },
                    { 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sale.Delete", null },
                    { 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Dealer", null },
                    { 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Dealer.Admin", null },
                    { 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Dealer.Read", null },
                    { 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Dealer.Write", null },
                    { 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Dealer.Create", null },
                    { 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Dealer.Update", null },
                    { 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Dealer.Delete", null },
                    { 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Seller", null },
                    { 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Seller.Admin", null },
                    { 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Seller.Read", null },
                    { 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Seller.Write", null },
                    { 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Seller.Create", null },
                    { 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Seller.Update", null },
                    { 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Seller.Delete", null },
                    { 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Customer", null },
                    { 46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Customer.Admin", null },
                    { 47, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Customer.Read", null },
                    { 48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Customer.Write", null },
                    { 49, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Customer.Create", null },
                    { 50, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Customer.Update", null },
                    { 51, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Customer.Delete", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("1d44b7f4-ba6d-4f7a-a5a3-8ae3c9aeb5a1"), 0, new DateTime(2024, 10, 10, 21, 21, 7, 322, DateTimeKind.Local).AddTicks(5846), null, "customer_two@test.com", new byte[] { 155, 236, 235, 255, 119, 183, 57, 67, 40, 220, 1, 208, 93, 9, 115, 115, 73, 210, 148, 95, 90, 144, 62, 115, 138, 101, 3, 175, 32, 189, 243, 45, 253, 227, 101, 57, 105, 212, 153, 120, 215, 161, 73, 163, 85, 30, 78, 34, 139, 100, 123, 248, 119, 163, 221, 192, 240, 178, 221, 171, 157, 207, 9, 126 }, new byte[] { 41, 113, 151, 82, 105, 42, 195, 120, 194, 230, 141, 54, 141, 130, 206, 154, 134, 90, 24, 4, 95, 114, 178, 15, 191, 218, 109, 72, 63, 85, 249, 218, 197, 223, 188, 72, 157, 146, 103, 214, 17, 33, 39, 33, 194, 171, 231, 177, 46, 227, 210, 16, 25, 255, 83, 108, 157, 192, 84, 35, 89, 148, 93, 186, 53, 132, 61, 114, 51, 24, 187, 168, 227, 180, 233, 119, 13, 202, 42, 123, 238, 108, 10, 156, 251, 142, 218, 29, 151, 43, 152, 62, 229, 91, 214, 49, 227, 71, 46, 17, 19, 74, 9, 199, 18, 6, 87, 17, 153, 146, 208, 74, 149, 246, 82, 21, 42, 254, 93, 156, 49, 55, 253, 95, 54, 233, 35, 188 }, null },
                    { new Guid("21e42f7e-8ed7-48b7-88c0-cde9dab75c6a"), 0, new DateTime(2024, 10, 10, 21, 21, 7, 322, DateTimeKind.Local).AddTicks(5835), null, "dealer@test.com", new byte[] { 155, 236, 235, 255, 119, 183, 57, 67, 40, 220, 1, 208, 93, 9, 115, 115, 73, 210, 148, 95, 90, 144, 62, 115, 138, 101, 3, 175, 32, 189, 243, 45, 253, 227, 101, 57, 105, 212, 153, 120, 215, 161, 73, 163, 85, 30, 78, 34, 139, 100, 123, 248, 119, 163, 221, 192, 240, 178, 221, 171, 157, 207, 9, 126 }, new byte[] { 41, 113, 151, 82, 105, 42, 195, 120, 194, 230, 141, 54, 141, 130, 206, 154, 134, 90, 24, 4, 95, 114, 178, 15, 191, 218, 109, 72, 63, 85, 249, 218, 197, 223, 188, 72, 157, 146, 103, 214, 17, 33, 39, 33, 194, 171, 231, 177, 46, 227, 210, 16, 25, 255, 83, 108, 157, 192, 84, 35, 89, 148, 93, 186, 53, 132, 61, 114, 51, 24, 187, 168, 227, 180, 233, 119, 13, 202, 42, 123, 238, 108, 10, 156, 251, 142, 218, 29, 151, 43, 152, 62, 229, 91, 214, 49, 227, 71, 46, 17, 19, 74, 9, 199, 18, 6, 87, 17, 153, 146, 208, 74, 149, 246, 82, 21, 42, 254, 93, 156, 49, 55, 253, 95, 54, 233, 35, 188 }, null },
                    { new Guid("aa0d87df-fc33-4214-992e-465b96938ff1"), 0, new DateTime(2024, 10, 10, 21, 21, 7, 322, DateTimeKind.Local).AddTicks(5803), null, "admin@test.com", new byte[] { 155, 236, 235, 255, 119, 183, 57, 67, 40, 220, 1, 208, 93, 9, 115, 115, 73, 210, 148, 95, 90, 144, 62, 115, 138, 101, 3, 175, 32, 189, 243, 45, 253, 227, 101, 57, 105, 212, 153, 120, 215, 161, 73, 163, 85, 30, 78, 34, 139, 100, 123, 248, 119, 163, 221, 192, 240, 178, 221, 171, 157, 207, 9, 126 }, new byte[] { 41, 113, 151, 82, 105, 42, 195, 120, 194, 230, 141, 54, 141, 130, 206, 154, 134, 90, 24, 4, 95, 114, 178, 15, 191, 218, 109, 72, 63, 85, 249, 218, 197, 223, 188, 72, 157, 146, 103, 214, 17, 33, 39, 33, 194, 171, 231, 177, 46, 227, 210, 16, 25, 255, 83, 108, 157, 192, 84, 35, 89, 148, 93, 186, 53, 132, 61, 114, 51, 24, 187, 168, 227, 180, 233, 119, 13, 202, 42, 123, 238, 108, 10, 156, 251, 142, 218, 29, 151, 43, 152, 62, 229, 91, 214, 49, 227, 71, 46, 17, 19, 74, 9, 199, 18, 6, 87, 17, 153, 146, 208, 74, 149, 246, 82, 21, 42, 254, 93, 156, 49, 55, 253, 95, 54, 233, 35, 188 }, null },
                    { new Guid("c9bf9e57-1685-4c89-bdcf-5698f00a4d78"), 0, new DateTime(2024, 10, 10, 21, 21, 7, 322, DateTimeKind.Local).AddTicks(5841), null, "customer_one@test.com", new byte[] { 155, 236, 235, 255, 119, 183, 57, 67, 40, 220, 1, 208, 93, 9, 115, 115, 73, 210, 148, 95, 90, 144, 62, 115, 138, 101, 3, 175, 32, 189, 243, 45, 253, 227, 101, 57, 105, 212, 153, 120, 215, 161, 73, 163, 85, 30, 78, 34, 139, 100, 123, 248, 119, 163, 221, 192, 240, 178, 221, 171, 157, 207, 9, 126 }, new byte[] { 41, 113, 151, 82, 105, 42, 195, 120, 194, 230, 141, 54, 141, 130, 206, 154, 134, 90, 24, 4, 95, 114, 178, 15, 191, 218, 109, 72, 63, 85, 249, 218, 197, 223, 188, 72, 157, 146, 103, 214, 17, 33, 39, 33, 194, 171, 231, 177, 46, 227, 210, 16, 25, 255, 83, 108, 157, 192, 84, 35, 89, 148, 93, 186, 53, 132, 61, 114, 51, 24, 187, 168, 227, 180, 233, 119, 13, 202, 42, 123, 238, 108, 10, 156, 251, 142, 218, 29, 151, 43, 152, 62, 229, 91, 214, 49, 227, 71, 46, 17, 19, 74, 9, 199, 18, 6, 87, 17, 153, 146, 208, 74, 149, 246, 82, 21, 42, 254, 93, 156, 49, 55, 253, 95, 54, 233, 35, 188 }, null },
                    { new Guid("f1a16df3-afcb-490e-a705-465c62946cce"), 0, new DateTime(2024, 10, 10, 21, 21, 7, 322, DateTimeKind.Local).AddTicks(5830), null, "sale@test.com", new byte[] { 155, 236, 235, 255, 119, 183, 57, 67, 40, 220, 1, 208, 93, 9, 115, 115, 73, 210, 148, 95, 90, 144, 62, 115, 138, 101, 3, 175, 32, 189, 243, 45, 253, 227, 101, 57, 105, 212, 153, 120, 215, 161, 73, 163, 85, 30, 78, 34, 139, 100, 123, 248, 119, 163, 221, 192, 240, 178, 221, 171, 157, 207, 9, 126 }, new byte[] { 41, 113, 151, 82, 105, 42, 195, 120, 194, 230, 141, 54, 141, 130, 206, 154, 134, 90, 24, 4, 95, 114, 178, 15, 191, 218, 109, 72, 63, 85, 249, 218, 197, 223, 188, 72, 157, 146, 103, 214, 17, 33, 39, 33, 194, 171, 231, 177, 46, 227, 210, 16, 25, 255, 83, 108, 157, 192, 84, 35, 89, 148, 93, 186, 53, 132, 61, 114, 51, 24, 187, 168, 227, 180, 233, 119, 13, 202, 42, 123, 238, 108, 10, 156, 251, 142, 218, 29, 151, 43, 152, 62, 229, 91, 214, 49, 227, 71, 46, 17, 19, 74, 9, 199, 18, 6, 87, 17, 153, 146, 208, 74, 149, 246, 82, 21, 42, 254, 93, 156, 49, 55, 253, 95, 54, 233, 35, 188 }, null },
                    { new Guid("f65a5e9f-621d-4e5c-91f9-0a8e357929b2"), 0, new DateTime(2024, 10, 10, 21, 21, 7, 322, DateTimeKind.Local).AddTicks(5838), null, "seller@test.com", new byte[] { 155, 236, 235, 255, 119, 183, 57, 67, 40, 220, 1, 208, 93, 9, 115, 115, 73, 210, 148, 95, 90, 144, 62, 115, 138, 101, 3, 175, 32, 189, 243, 45, 253, 227, 101, 57, 105, 212, 153, 120, 215, 161, 73, 163, 85, 30, 78, 34, 139, 100, 123, 248, 119, 163, 221, 192, 240, 178, 221, 171, 157, 207, 9, 126 }, new byte[] { 41, 113, 151, 82, 105, 42, 195, 120, 194, 230, 141, 54, 141, 130, 206, 154, 134, 90, 24, 4, 95, 114, 178, 15, 191, 218, 109, 72, 63, 85, 249, 218, 197, 223, 188, 72, 157, 146, 103, 214, 17, 33, 39, 33, 194, 171, 231, 177, 46, 227, 210, 16, 25, 255, 83, 108, 157, 192, 84, 35, 89, 148, 93, 186, 53, 132, 61, 114, 51, 24, 187, 168, 227, 180, 233, 119, 13, 202, 42, 123, 238, 108, 10, 156, 251, 142, 218, 29, 151, 43, 152, 62, 229, 91, 214, 49, 227, 71, 46, 17, 19, 74, 9, 199, 18, 6, 87, 17, 153, 146, 208, 74, 149, 246, 82, 21, 42, 254, 93, 156, 49, 55, 253, 95, 54, 233, 35, 188 }, null }
                });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("02c20369-19bf-4d44-baa5-0868276ff603"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 45, null, new Guid("c9bf9e57-1685-4c89-bdcf-5698f00a4d78") },
                    { new Guid("1a4ef67a-c20f-49ad-b29e-705c48275f64"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 45, null, new Guid("1d44b7f4-ba6d-4f7a-a5a3-8ae3c9aeb5a1") },
                    { new Guid("82e818dd-d4a8-4bee-bdc0-5b5b3f75a555"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 31, null, new Guid("21e42f7e-8ed7-48b7-88c0-cde9dab75c6a") },
                    { new Guid("be9ccdfd-754e-42d3-8593-6f814a5e1f06"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 38, null, new Guid("f65a5e9f-621d-4e5c-91f9-0a8e357929b2") },
                    { new Guid("e707293a-8f64-43b8-99f0-ade5545264fe"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 24, null, new Guid("f1a16df3-afcb-490e-a705-465c62946cce") },
                    { new Guid("eacb0258-2aa7-4d4e-b17c-d2c044add597"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("aa0d87df-fc33-4214-992e-465b96938ff1") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_OperationClaimId",
                table: "UserOperationClaims",
                column: "OperationClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_UserId",
                table: "UserOperationClaims",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "UserOperationClaims");

            migrationBuilder.DropTable(
                name: "OperationClaims");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
