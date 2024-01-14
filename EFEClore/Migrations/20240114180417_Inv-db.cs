using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFEClore.Migrations
{
    /// <inheritdoc />
    public partial class Invdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_newTableName_Students_studentId",
                schema: "newScemaName",
                table: "newTableName");

            migrationBuilder.DropPrimaryKey(
                name: "PK_newTableName",
                schema: "newScemaName",
                table: "newTableName");

            migrationBuilder.RenameTable(
                name: "newTableName",
                schema: "newScemaName",
                newName: "attendences");

            migrationBuilder.RenameColumn(
                name: "newName",
                table: "attendences",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_newTableName_studentId",
                table: "attendences",
                newName: "IX_attendences_studentId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "attendences",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "theDate",
                table: "attendences",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_attendences",
                table: "attendences",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customerTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    customerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fullName = table.Column<string>(type: "nvarchar(max)", nullable: false, computedColumnSql: "[customerTitle] + ' ' +[customerName]"),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    qty = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 1m),
                    total = table.Column<decimal>(type: "decimal(18,2)", nullable: false, computedColumnSql: "[price] * [qty]"),
                    createDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invoices", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_attendences_Students_studentId",
                table: "attendences",
                column: "studentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_attendences_Students_studentId",
                table: "attendences");

            migrationBuilder.DropTable(
                name: "invoices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_attendences",
                table: "attendences");

            migrationBuilder.DropColumn(
                name: "theDate",
                table: "attendences");

            migrationBuilder.EnsureSchema(
                name: "newScemaName");

            migrationBuilder.RenameTable(
                name: "attendences",
                newName: "newTableName",
                newSchema: "newScemaName");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "newScemaName",
                table: "newTableName",
                newName: "newName");

            migrationBuilder.RenameIndex(
                name: "IX_attendences_studentId",
                schema: "newScemaName",
                table: "newTableName",
                newName: "IX_newTableName_studentId");

            migrationBuilder.AlterColumn<string>(
                name: "newName",
                schema: "newScemaName",
                table: "newTableName",
                type: "varchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_newTableName",
                schema: "newScemaName",
                table: "newTableName",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_newTableName_Students_studentId",
                schema: "newScemaName",
                table: "newTableName",
                column: "studentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
