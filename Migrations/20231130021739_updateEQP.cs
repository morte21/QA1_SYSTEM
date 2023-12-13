using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QA1_SYSTEM.Migrations
{
    /// <inheritdoc />
    public partial class updateEQP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentMachineHistory_EquipmentMachine_equipmentMachineEQPid",
                table: "EquipmentMachineHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_FixedAssetEQP_EquipmentMachine_equipmentMachineEQPid",
                table: "FixedAssetEQP");

            migrationBuilder.DropIndex(
                name: "IX_FixedAssetEQP_equipmentMachineEQPid",
                table: "FixedAssetEQP");

            migrationBuilder.DropIndex(
                name: "IX_EquipmentMachineHistory_equipmentMachineEQPid",
                table: "EquipmentMachineHistory");

            migrationBuilder.DropColumn(
                name: "equipmentMachineEQPid",
                table: "FixedAssetEQP");

            migrationBuilder.DropColumn(
                name: "equipmentMachineEQPid",
                table: "EquipmentMachineHistory");

            migrationBuilder.RenameColumn(
                name: "eqpMacId",
                table: "EquipmentMachineHistory",
                newName: "EqpMacId");

            migrationBuilder.CreateIndex(
                name: "IX_FixedAssetEQP_EQPid",
                table: "FixedAssetEQP",
                column: "EQPid");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentMachineHistory_EQPid",
                table: "EquipmentMachineHistory",
                column: "EQPid");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentMachineHistory_EquipmentMachine_EQPid",
                table: "EquipmentMachineHistory",
                column: "EQPid",
                principalTable: "EquipmentMachine",
                principalColumn: "EQPid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FixedAssetEQP_EquipmentMachine_EQPid",
                table: "FixedAssetEQP",
                column: "EQPid",
                principalTable: "EquipmentMachine",
                principalColumn: "EQPid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentMachineHistory_EquipmentMachine_EQPid",
                table: "EquipmentMachineHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_FixedAssetEQP_EquipmentMachine_EQPid",
                table: "FixedAssetEQP");

            migrationBuilder.DropIndex(
                name: "IX_FixedAssetEQP_EQPid",
                table: "FixedAssetEQP");

            migrationBuilder.DropIndex(
                name: "IX_EquipmentMachineHistory_EQPid",
                table: "EquipmentMachineHistory");

            migrationBuilder.RenameColumn(
                name: "EqpMacId",
                table: "EquipmentMachineHistory",
                newName: "eqpMacId");

            migrationBuilder.AddColumn<int>(
                name: "equipmentMachineEQPid",
                table: "FixedAssetEQP",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "equipmentMachineEQPid",
                table: "EquipmentMachineHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FixedAssetEQP_equipmentMachineEQPid",
                table: "FixedAssetEQP",
                column: "equipmentMachineEQPid");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentMachineHistory_equipmentMachineEQPid",
                table: "EquipmentMachineHistory",
                column: "equipmentMachineEQPid");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentMachineHistory_EquipmentMachine_equipmentMachineEQPid",
                table: "EquipmentMachineHistory",
                column: "equipmentMachineEQPid",
                principalTable: "EquipmentMachine",
                principalColumn: "EQPid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FixedAssetEQP_EquipmentMachine_equipmentMachineEQPid",
                table: "FixedAssetEQP",
                column: "equipmentMachineEQPid",
                principalTable: "EquipmentMachine",
                principalColumn: "EQPid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
