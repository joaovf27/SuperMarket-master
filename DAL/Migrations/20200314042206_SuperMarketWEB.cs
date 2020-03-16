using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class SuperMarketWEB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BRANDS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BRANDS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CATEGORIES",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORIES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CLIENTS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 45, nullable: false),
                    Email = table.Column<string>(maxLength: 70, nullable: false),
                    CPF = table.Column<string>(maxLength: 14, nullable: false),
                    RG = table.Column<string>(maxLength: 9, nullable: false),
                    Phone = table.Column<string>(maxLength: 18, nullable: false),
                    DateBirth = table.Column<DateTime>(type: "date", nullable: false),
                    Password = table.Column<string>(maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENTS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EMPLOYEES",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 45, nullable: false),
                    Email = table.Column<string>(maxLength: 70, nullable: false),
                    CPF = table.Column<string>(nullable: true),
                    RG = table.Column<string>(fixedLength: true, maxLength: 10, nullable: false),
                    Phone = table.Column<string>(maxLength: 18, nullable: false),
                    DateBirth = table.Column<DateTime>(type: "date", nullable: false),
                    Password = table.Column<string>(maxLength: 100, nullable: false),
                    Function = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLOYEES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PROVIDERS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FantasyName = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 80, nullable: false),
                    CNPJ = table.Column<string>(fixedLength: true, maxLength: 18, nullable: false),
                    Phone = table.Column<string>(maxLength: 18, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROVIDERS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "USERS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Password = table.Column<string>(maxLength: 100, nullable: false),
                    Name = table.Column<string>(maxLength: 45, nullable: false),
                    Permissions = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SALES",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientDTOID = table.Column<int>(nullable: false),
                    SaleDate = table.Column<DateTime>(type: "date", nullable: false),
                    TotalPrice = table.Column<double>(nullable: false),
                    EmployeeDTOID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SALES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SALES_CLIENTS_ClientDTOID",
                        column: x => x.ClientDTOID,
                        principalTable: "CLIENTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SALES_EMPLOYEES_EmployeeDTOID",
                        column: x => x.EmployeeDTOID,
                        principalTable: "EMPLOYEES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCTS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(maxLength: 40, nullable: false),
                    BrandID = table.Column<int>(nullable: false),
                    ProviderID = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PRODUCTS_BRANDS_BrandID",
                        column: x => x.BrandID,
                        principalTable: "BRANDS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PRODUCTS_PROVIDERS_ProviderID",
                        column: x => x.ProviderID,
                        principalTable: "PROVIDERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemsSaleDTO",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductDTOID = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    SaleDTOID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsSaleDTO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ItemsSaleDTO_PRODUCTS_ProductDTOID",
                        column: x => x.ProductDTOID,
                        principalTable: "PRODUCTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemsSaleDTO_SALES_SaleDTOID",
                        column: x => x.SaleDTOID,
                        principalTable: "SALES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCTS_CATEGORIES",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTS_CATEGORIES", x => new { x.ProductID, x.CategoryID });
                    table.ForeignKey(
                        name: "FK_PRODUCTS_CATEGORIES_CATEGORIES_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "CATEGORIES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PRODUCTS_CATEGORIES_PRODUCTS_ProductID",
                        column: x => x.ProductID,
                        principalTable: "PRODUCTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEES_Email",
                table: "EMPLOYEES",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEES_Phone",
                table: "EMPLOYEES",
                column: "Phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEES_RG",
                table: "EMPLOYEES",
                column: "RG",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemsSaleDTO_ProductDTOID",
                table: "ItemsSaleDTO",
                column: "ProductDTOID");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsSaleDTO_SaleDTOID",
                table: "ItemsSaleDTO",
                column: "SaleDTOID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_BrandID",
                table: "PRODUCTS",
                column: "BrandID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_ProviderID",
                table: "PRODUCTS",
                column: "ProviderID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_CATEGORIES_CategoryID",
                table: "PRODUCTS_CATEGORIES",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_PROVIDERS_CNPJ",
                table: "PROVIDERS",
                column: "CNPJ",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PROVIDERS_Email",
                table: "PROVIDERS",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PROVIDERS_Phone",
                table: "PROVIDERS",
                column: "Phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SALES_ClientDTOID",
                table: "SALES",
                column: "ClientDTOID");

            migrationBuilder.CreateIndex(
                name: "IX_SALES_EmployeeDTOID",
                table: "SALES",
                column: "EmployeeDTOID");

            migrationBuilder.CreateIndex(
                name: "IX_USERS_Email",
                table: "USERS",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemsSaleDTO");

            migrationBuilder.DropTable(
                name: "PRODUCTS_CATEGORIES");

            migrationBuilder.DropTable(
                name: "USERS");

            migrationBuilder.DropTable(
                name: "SALES");

            migrationBuilder.DropTable(
                name: "CATEGORIES");

            migrationBuilder.DropTable(
                name: "PRODUCTS");

            migrationBuilder.DropTable(
                name: "CLIENTS");

            migrationBuilder.DropTable(
                name: "EMPLOYEES");

            migrationBuilder.DropTable(
                name: "BRANDS");

            migrationBuilder.DropTable(
                name: "PROVIDERS");
        }
    }
}
