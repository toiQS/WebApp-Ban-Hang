using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp_Ban_Hang.Presistence.Migrations
{
    /// <inheritdoc />
    public partial class IdentityDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productimage_Product_ProductLine",
                table: "Productimage");

            migrationBuilder.DropForeignKey(
                name: "FK_Productinfo_Product_Product_Line",
                table: "Productinfo");

            migrationBuilder.DropForeignKey(
                name: "FK_Productwarranty_Product_Product_Line",
                table: "Productwarranty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Productwarranty",
                table: "Productwarranty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Productinfo",
                table: "Productinfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Productimage",
                table: "Productimage");

            migrationBuilder.RenameTable(
                name: "Productwarranty",
                newName: "ProductWarranty");

            migrationBuilder.RenameTable(
                name: "Productinfo",
                newName: "ProductInfo");

            migrationBuilder.RenameTable(
                name: "Productimage",
                newName: "ProductImage");

            migrationBuilder.RenameIndex(
                name: "IX_Productwarranty_Product_Line",
                table: "ProductWarranty",
                newName: "IX_ProductWarranty_Product_Line");

            migrationBuilder.RenameIndex(
                name: "IX_Productinfo_Product_Line",
                table: "ProductInfo",
                newName: "IX_ProductInfo_Product_Line");

            migrationBuilder.RenameIndex(
                name: "IX_Productimage_ProductLine",
                table: "ProductImage",
                newName: "IX_ProductImage_ProductLine");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductWarranty",
                table: "ProductWarranty",
                column: "Product_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductInfo",
                table: "ProductInfo",
                column: "Info_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductImage",
                table: "ProductImage",
                column: "ImageID");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImage_Product_ProductLine",
                table: "ProductImage",
                column: "ProductLine",
                principalTable: "Product",
                principalColumn: "Product_Line",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInfo_Product_Product_Line",
                table: "ProductInfo",
                column: "Product_Line",
                principalTable: "Product",
                principalColumn: "Product_Line",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductWarranty_Product_Product_Line",
                table: "ProductWarranty",
                column: "Product_Line",
                principalTable: "Product",
                principalColumn: "Product_Line",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImage_Product_ProductLine",
                table: "ProductImage");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductInfo_Product_Product_Line",
                table: "ProductInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductWarranty_Product_Product_Line",
                table: "ProductWarranty");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductWarranty",
                table: "ProductWarranty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductInfo",
                table: "ProductInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductImage",
                table: "ProductImage");

            migrationBuilder.RenameTable(
                name: "ProductWarranty",
                newName: "Productwarranty");

            migrationBuilder.RenameTable(
                name: "ProductInfo",
                newName: "Productinfo");

            migrationBuilder.RenameTable(
                name: "ProductImage",
                newName: "Productimage");

            migrationBuilder.RenameIndex(
                name: "IX_ProductWarranty_Product_Line",
                table: "Productwarranty",
                newName: "IX_Productwarranty_Product_Line");

            migrationBuilder.RenameIndex(
                name: "IX_ProductInfo_Product_Line",
                table: "Productinfo",
                newName: "IX_Productinfo_Product_Line");

            migrationBuilder.RenameIndex(
                name: "IX_ProductImage_ProductLine",
                table: "Productimage",
                newName: "IX_Productimage_ProductLine");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Productwarranty",
                table: "Productwarranty",
                column: "Product_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Productinfo",
                table: "Productinfo",
                column: "Info_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Productimage",
                table: "Productimage",
                column: "ImageID");

            migrationBuilder.AddForeignKey(
                name: "FK_Productimage_Product_ProductLine",
                table: "Productimage",
                column: "ProductLine",
                principalTable: "Product",
                principalColumn: "Product_Line",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Productinfo_Product_Product_Line",
                table: "Productinfo",
                column: "Product_Line",
                principalTable: "Product",
                principalColumn: "Product_Line",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Productwarranty_Product_Product_Line",
                table: "Productwarranty",
                column: "Product_Line",
                principalTable: "Product",
                principalColumn: "Product_Line",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
