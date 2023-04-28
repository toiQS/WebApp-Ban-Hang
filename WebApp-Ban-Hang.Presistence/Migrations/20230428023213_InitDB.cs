using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp_Ban_Hang.Presistence.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Create_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modifiled_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Delete_At = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    BrandId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    BrandName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", maxLength: 10, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "UserDetail",
                columns: table => new
                {
                    UserDetailId = table.Column<int>(type: "int", maxLength: 11, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DetaledAddress = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    WardOrVillage = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    District = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CityOrProvince = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetail", x => x.UserDetailId);
                    table.ForeignKey(
                        name: "FK_UserDetail_Account_UserName",
                        column: x => x.UserName,
                        principalTable: "Account",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserOrder",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", maxLength: 11, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Create_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Total = table.Column<long>(type: "bigint", maxLength: 10, nullable: false),
                    Comfirmed_by = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AccountUserName = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOrder", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_UserOrder_Account_AccountUserName",
                        column: x => x.AccountUserName,
                        principalTable: "Account",
                        principalColumn: "UserName");
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Product_Line = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Product_Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Thumbnail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Discount = table.Column<long>(type: "bigint", maxLength: 3, nullable: false),
                    Create_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Delete_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Create_By = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AccountUserName = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    BrandId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CategoryID = table.Column<int>(type: "int", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Product_Line);
                    table.ForeignKey(
                        name: "FK_Product_Account_AccountUserName",
                        column: x => x.AccountUserName,
                        principalTable: "Account",
                        principalColumn: "UserName");
                    table.ForeignKey(
                        name: "FK_Product_Brand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brand",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImage",
                columns: table => new
                {
                    ImageID = table.Column<int>(type: "int", maxLength: 11, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductLine = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImage", x => x.ImageID);
                    table.ForeignKey(
                        name: "FK_ProductImage_Product_ProductLine",
                        column: x => x.ProductLine,
                        principalTable: "Product",
                        principalColumn: "Product_Line",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductInfo",
                columns: table => new
                {
                    Info_ID = table.Column<int>(type: "int", maxLength: 10, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_Line = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Product_Infomation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInfo", x => x.Info_ID);
                    table.ForeignKey(
                        name: "FK_ProductInfo_Product_Product_Line",
                        column: x => x.Product_Line,
                        principalTable: "Product",
                        principalColumn: "Product_Line",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductWarranty",
                columns: table => new
                {
                    Product_ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Purchased_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Warranty_Period = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Product_Line = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductWarranty", x => x.Product_ID);
                    table.ForeignKey(
                        name: "FK_ProductWarranty_Product_Product_Line",
                        column: x => x.Product_Line,
                        principalTable: "Product",
                        principalColumn: "Product_Line",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_AccountUserName",
                table: "Product",
                column: "AccountUserName");

            migrationBuilder.CreateIndex(
                name: "IX_Product_BrandId",
                table: "Product",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryID",
                table: "Product",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImage_ProductLine",
                table: "ProductImage",
                column: "ProductLine");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInfo_Product_Line",
                table: "ProductInfo",
                column: "Product_Line");

            migrationBuilder.CreateIndex(
                name: "IX_ProductWarranty_Product_Line",
                table: "ProductWarranty",
                column: "Product_Line");

            migrationBuilder.CreateIndex(
                name: "IX_UserDetail_UserName",
                table: "UserDetail",
                column: "UserName");

            migrationBuilder.CreateIndex(
                name: "IX_UserOrder_AccountUserName",
                table: "UserOrder",
                column: "AccountUserName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductImage");

            migrationBuilder.DropTable(
                name: "ProductInfo");

            migrationBuilder.DropTable(
                name: "ProductWarranty");

            migrationBuilder.DropTable(
                name: "UserDetail");

            migrationBuilder.DropTable(
                name: "UserOrder");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
