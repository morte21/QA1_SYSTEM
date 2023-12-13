using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QA1_SYSTEM.Migrations
{
    /// <inheritdoc />
    public partial class purchaseTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "requestor_name",
                table: "Requestor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "request_qty",
                table: "Requestor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "request_ate",
                table: "Requestor",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "reason_request",
                table: "Requestor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "part_number",
                table: "Requestor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "item_description",
                table: "Requestor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Purchasing",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date_request = table.Column<DateTime>(type: "datetime2", nullable: true),
                    purchase_dept = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    part_number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    item_description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    maker = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    supplier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    request_qty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    request_unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    unit_price = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    total_price = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    item_currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    request_reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    request_status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date_submitPR = table.Column<DateTime>(type: "datetime2", nullable: true),
                    person_submitPR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    purchase_order = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    po_path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    est_time_arrival = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date_needed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date_received = table.Column<DateTime>(type: "datetime2", nullable: true),
                    received_qty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    item_comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pr_number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pr_path = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchasing", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Purchasing");

            migrationBuilder.AlterColumn<string>(
                name: "requestor_name",
                table: "Requestor",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "request_qty",
                table: "Requestor",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "request_ate",
                table: "Requestor",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "reason_request",
                table: "Requestor",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "part_number",
                table: "Requestor",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "item_description",
                table: "Requestor",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
