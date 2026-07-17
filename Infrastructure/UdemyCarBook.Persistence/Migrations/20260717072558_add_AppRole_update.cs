using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UdemyCarBook.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class add_AppRole_update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_AppleRoles_AppleRoleId",
                table: "AppUsers");

            migrationBuilder.DropTable(
                name: "AppleRoles");

            migrationBuilder.DropIndex(
                name: "IX_AppUsers_AppleRoleId",
                table: "AppUsers");

            migrationBuilder.AddColumn<int>(
                name: "AppRoleId",
                table: "AppUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AppRoles",
                columns: table => new
                {
                    AppRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppRoleName = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoles", x => x.AppRoleId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_AppRoleId",
                table: "AppUsers",
                column: "AppRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_AppRoles_AppRoleId",
                table: "AppUsers",
                column: "AppRoleId",
                principalTable: "AppRoles",
                principalColumn: "AppRoleId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_AppRoles_AppRoleId",
                table: "AppUsers");

            migrationBuilder.DropTable(
                name: "AppRoles");

            migrationBuilder.DropIndex(
                name: "IX_AppUsers_AppRoleId",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "AppRoleId",
                table: "AppUsers");

            migrationBuilder.CreateTable(
                name: "AppleRoles",
                columns: table => new
                {
                    AppleRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppleRoleName = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppleRoles", x => x.AppleRoleId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_AppleRoleId",
                table: "AppUsers",
                column: "AppleRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_AppleRoles_AppleRoleId",
                table: "AppUsers",
                column: "AppleRoleId",
                principalTable: "AppleRoles",
                principalColumn: "AppleRoleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
