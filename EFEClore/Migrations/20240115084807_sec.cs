using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFEClore.Migrations
{
    /// <inheritdoc />
    public partial class sec : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Students_Name",
                table: "Students");

            migrationBuilder.CreateSequence<int>(
                name: "DeliveryOrder",
                startValue: 101L);

            migrationBuilder.AddColumn<int>(
                name: "DeliveryOrder",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValueSql: "Next Value For DeliveryOrder");

            migrationBuilder.CreateTable(
                name: "uniforms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryOrder = table.Column<int>(type: "int", nullable: false, defaultValueSql: "Next Value For DeliveryOrder")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uniforms", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX-my-index",
                table: "Students",
                column: "Name",
                unique: true,
                filter: "Name is not null");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "uniforms");

            migrationBuilder.DropIndex(
                name: "IX-my-index",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "DeliveryOrder",
                table: "Books");

            migrationBuilder.DropSequence(
                name: "DeliveryOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Students_Name",
                table: "Students",
                column: "Name");
        }
    }
}
