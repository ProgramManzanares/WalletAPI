using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIWalletNew.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNameColumnPasswordHashtoPassword_hash : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "passwordHash",
                table: "users",
                newName: "password_hash"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "password_hash",
                table: "users",
                newName: "passwordHash"
            );
        }
    }
}
