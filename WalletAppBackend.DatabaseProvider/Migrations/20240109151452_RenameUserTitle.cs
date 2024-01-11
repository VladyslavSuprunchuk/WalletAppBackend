using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WalletAppBackend.DatabaseProvider.Migrations
{
    /// <inheritdoc />
    public partial class RenameUserTitle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Usres",
                table: "Usres");

            migrationBuilder.RenameTable(
                name: "Usres",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Usres");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usres",
                table: "Usres",
                column: "Id");
        }
    }
}
