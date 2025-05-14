using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PROG7311.Migrations
{
    /// <inheritdoc />
    public partial class initialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    employeeID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    surname = table.Column<string>(type: "TEXT", nullable: false),
                    email = table.Column<string>(type: "TEXT", nullable: false),
                    password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.employeeID);
                });

            migrationBuilder.CreateTable(
                name: "Farmers",
                columns: table => new
                {
                    farmerID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    surname = table.Column<string>(type: "TEXT", nullable: false),
                    email = table.Column<string>(type: "TEXT", nullable: false),
                    password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farmers", x => x.farmerID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    productID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    farmerID = table.Column<int>(type: "INTEGER", nullable: false),
                    productName = table.Column<string>(type: "TEXT", nullable: false),
                    productDescription = table.Column<string>(type: "TEXT", nullable: false),
                    productCategory = table.Column<string>(type: "TEXT", nullable: false),
                    dateAdded = table.Column<DateOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.productID);
                    table.ForeignKey(
                        name: "FK_Products_Farmers_farmerID",
                        column: x => x.farmerID,
                        principalTable: "Farmers",
                        principalColumn: "farmerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_farmerID",
                table: "Products",
                column: "farmerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Farmers");
        }
    }
}
