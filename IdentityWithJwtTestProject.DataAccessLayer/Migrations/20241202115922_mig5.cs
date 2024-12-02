using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityWithJwtTestProject.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoles_AppRoleEndpoints_AppRoleEndpointId",
                table: "AspNetRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_Endpoints_AppRoleEndpoints_AppRoleEndpointId",
                table: "Endpoints");

            migrationBuilder.DropIndex(
                name: "IX_Endpoints_AppRoleEndpointId",
                table: "Endpoints");

            migrationBuilder.DropIndex(
                name: "IX_AspNetRoles_AppRoleEndpointId",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "AppRoleEndpointId",
                table: "Endpoints");

            migrationBuilder.DropColumn(
                name: "AppRoleEndpointId",
                table: "AspNetRoles");

            migrationBuilder.AlterColumn<string>(
                name: "EndpointId",
                table: "AppRoleEndpoints",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AppRoleId",
                table: "AppRoleEndpoints",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_AppRoleEndpoints_AppRoleId",
                table: "AppRoleEndpoints",
                column: "AppRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AppRoleEndpoints_EndpointId",
                table: "AppRoleEndpoints",
                column: "EndpointId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppRoleEndpoints_AspNetRoles_AppRoleId",
                table: "AppRoleEndpoints",
                column: "AppRoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppRoleEndpoints_Endpoints_EndpointId",
                table: "AppRoleEndpoints",
                column: "EndpointId",
                principalTable: "Endpoints",
                principalColumn: "EndpointId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppRoleEndpoints_AspNetRoles_AppRoleId",
                table: "AppRoleEndpoints");

            migrationBuilder.DropForeignKey(
                name: "FK_AppRoleEndpoints_Endpoints_EndpointId",
                table: "AppRoleEndpoints");

            migrationBuilder.DropIndex(
                name: "IX_AppRoleEndpoints_AppRoleId",
                table: "AppRoleEndpoints");

            migrationBuilder.DropIndex(
                name: "IX_AppRoleEndpoints_EndpointId",
                table: "AppRoleEndpoints");

            migrationBuilder.AddColumn<string>(
                name: "AppRoleEndpointId",
                table: "Endpoints",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AppRoleEndpointId",
                table: "AspNetRoles",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "EndpointId",
                table: "AppRoleEndpoints",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "AppRoleId",
                table: "AppRoleEndpoints",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Endpoints_AppRoleEndpointId",
                table: "Endpoints",
                column: "AppRoleEndpointId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_AppRoleEndpointId",
                table: "AspNetRoles",
                column: "AppRoleEndpointId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoles_AppRoleEndpoints_AppRoleEndpointId",
                table: "AspNetRoles",
                column: "AppRoleEndpointId",
                principalTable: "AppRoleEndpoints",
                principalColumn: "AppRoleEndpointId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Endpoints_AppRoleEndpoints_AppRoleEndpointId",
                table: "Endpoints",
                column: "AppRoleEndpointId",
                principalTable: "AppRoleEndpoints",
                principalColumn: "AppRoleEndpointId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
