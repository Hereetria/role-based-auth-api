using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityWithJwtTestProject.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Definition",
                table: "Endpoints",
                newName: "MethodName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MethodName",
                table: "Endpoints",
                newName: "Definition");
        }
    }
}
