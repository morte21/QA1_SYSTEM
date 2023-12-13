using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QA1_SYSTEM.Migrations
{
    /// <inheritdoc />
    public partial class addpicPCeqp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "path_pic",
                table: "EquipmentMachine",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "path_pic",
                table: "Computers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "path_pic",
                table: "EquipmentMachine");

            migrationBuilder.DropColumn(
                name: "path_pic",
                table: "Computers");
        }
    }
}
