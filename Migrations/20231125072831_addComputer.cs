using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QA1_SYSTEM.Migrations
{
    /// <inheritdoc />
    public partial class addComputer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Computers",
                columns: table => new
                {
                    ComputerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date_reg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    computer_category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    processor_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ram_capacity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hdd_capacty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    os_installed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ip_sdp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ip_local = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    active_user = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Computers", x => x.ComputerId);
                });

            migrationBuilder.CreateTable(
                name: "ComputerHistory",
                columns: table => new
                {
                    CompHistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComputerId = table.Column<int>(type: "int", nullable: false),
                    trouble_encounter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    trouble_date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputerHistory", x => x.CompHistoryId);
                    table.ForeignKey(
                        name: "FK_ComputerHistory_Computers_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "Computers",
                        principalColumn: "ComputerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FixedAssetPC",
                columns: table => new
                {
                    FixedAssetPCId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComputerId = table.Column<int>(type: "int", nullable: false),
                    fixed_asset_no = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fixed_asset_date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inventory_found = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inventory_date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inventory_year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    item_location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pic_path = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FixedAssetPC", x => x.FixedAssetPCId);
                    table.ForeignKey(
                        name: "FK_FixedAssetPC_Computers_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "Computers",
                        principalColumn: "ComputerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComputerHistory_ComputerId",
                table: "ComputerHistory",
                column: "ComputerId");

            migrationBuilder.CreateIndex(
                name: "IX_FixedAssetPC_ComputerId",
                table: "FixedAssetPC",
                column: "ComputerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComputerHistory");

            migrationBuilder.DropTable(
                name: "FixedAssetPC");

            migrationBuilder.DropTable(
                name: "Computers");
        }
    }
}
