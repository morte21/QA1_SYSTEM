using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QA1_SYSTEM.Migrations
{
    /// <inheritdoc />
    public partial class equipmentAddhistoryAssets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "item_location",
                table: "FixedAssetPC",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "inventory_year",
                table: "FixedAssetPC",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "inventory_found",
                table: "FixedAssetPC",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "inventory_date",
                table: "FixedAssetPC",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "fixed_asset_no",
                table: "FixedAssetPC",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "fixed_asset_date",
                table: "FixedAssetPC",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "trouble_encounter",
                table: "ComputerHistory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "trouble_date",
                table: "ComputerHistory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "remarks",
                table: "ComputerHistory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "EquipmentMachine",
                columns: table => new
                {
                    EQPid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date_reg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    equipment_category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    part_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    machine_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    active_user = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentMachine", x => x.EQPid);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentMachineHistory",
                columns: table => new
                {
                    eqpMacId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EQPid = table.Column<int>(type: "int", nullable: false),
                    equipmentMachineEQPid = table.Column<int>(type: "int", nullable: false),
                    trouble_encounter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    trouble_date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    remarks = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentMachineHistory", x => x.eqpMacId);
                    table.ForeignKey(
                        name: "FK_EquipmentMachineHistory_EquipmentMachine_equipmentMachineEQPid",
                        column: x => x.equipmentMachineEQPid,
                        principalTable: "EquipmentMachine",
                        principalColumn: "EQPid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FixedAssetEQP",
                columns: table => new
                {
                    EQPassetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EQPid = table.Column<int>(type: "int", nullable: false),
                    equipmentMachineEQPid = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_FixedAssetEQP", x => x.EQPassetId);
                    table.ForeignKey(
                        name: "FK_FixedAssetEQP_EquipmentMachine_equipmentMachineEQPid",
                        column: x => x.equipmentMachineEQPid,
                        principalTable: "EquipmentMachine",
                        principalColumn: "EQPid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentMachineHistory_equipmentMachineEQPid",
                table: "EquipmentMachineHistory",
                column: "equipmentMachineEQPid");

            migrationBuilder.CreateIndex(
                name: "IX_FixedAssetEQP_equipmentMachineEQPid",
                table: "FixedAssetEQP",
                column: "equipmentMachineEQPid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipmentMachineHistory");

            migrationBuilder.DropTable(
                name: "FixedAssetEQP");

            migrationBuilder.DropTable(
                name: "EquipmentMachine");

            migrationBuilder.AlterColumn<string>(
                name: "item_location",
                table: "FixedAssetPC",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "inventory_year",
                table: "FixedAssetPC",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "inventory_found",
                table: "FixedAssetPC",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "inventory_date",
                table: "FixedAssetPC",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "fixed_asset_no",
                table: "FixedAssetPC",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "fixed_asset_date",
                table: "FixedAssetPC",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "trouble_encounter",
                table: "ComputerHistory",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "trouble_date",
                table: "ComputerHistory",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "remarks",
                table: "ComputerHistory",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
