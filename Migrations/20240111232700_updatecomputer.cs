using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QA1_SYSTEM.Migrations
{
    /// <inheritdoc />
    public partial class updatecomputer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ip_sdp",
                table: "Computers",
                newName: "macAddress");

            migrationBuilder.RenameColumn(
                name: "ip_local",
                table: "Computers",
                newName: "ip");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "macAddress",
                table: "Computers",
                newName: "ip_sdp");

            migrationBuilder.RenameColumn(
                name: "ip",
                table: "Computers",
                newName: "ip_local");
        }
    }
}
