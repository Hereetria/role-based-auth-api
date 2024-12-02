using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityWithJwtTestProject.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppRoleEndpointId",
                table: "AspNetRoles",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "AppRoleEndpoints",
                columns: table => new
                {
                    AppRoleEndpointId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AppRoleId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndpointId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoleEndpoints", x => x.AppRoleEndpointId);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    MenuId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.MenuId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Endpoints",
                columns: table => new
                {
                    EndpointId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ActionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HttpType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Definition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MenuId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AppRoleEndpointId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endpoints", x => x.EndpointId);
                    table.ForeignKey(
                        name: "FK_Endpoints_AppRoleEndpoints_AppRoleEndpointId",
                        column: x => x.AppRoleEndpointId,
                        principalTable: "AppRoleEndpoints",
                        principalColumn: "AppRoleEndpointId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Endpoints_Menu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menu",
                        principalColumn: "MenuId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_AppRoleEndpointId",
                table: "AspNetRoles",
                column: "AppRoleEndpointId");

            migrationBuilder.CreateIndex(
                name: "IX_Endpoints_AppRoleEndpointId",
                table: "Endpoints",
                column: "AppRoleEndpointId");

            migrationBuilder.CreateIndex(
                name: "IX_Endpoints_MenuId",
                table: "Endpoints",
                column: "MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoles_AppRoleEndpoints_AppRoleEndpointId",
                table: "AspNetRoles",
                column: "AppRoleEndpointId",
                principalTable: "AppRoleEndpoints",
                principalColumn: "AppRoleEndpointId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoles_AppRoleEndpoints_AppRoleEndpointId",
                table: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Endpoints");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AppRoleEndpoints");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropIndex(
                name: "IX_AspNetRoles_AppRoleEndpointId",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "AppRoleEndpointId",
                table: "AspNetRoles");
        }
    }
}
