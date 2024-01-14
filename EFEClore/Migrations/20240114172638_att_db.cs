using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFEClore.Migrations
{
    /// <inheritdoc />
    public partial class att_db : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "newScemaName");

            migrationBuilder.CreateTable(
                name: "newTableName",
                schema: "newScemaName",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    newName = table.Column<string>(type: "varchar(50)", nullable: true),
                    studentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_newTableName", x => x.Id);
                    table.ForeignKey(
                        name: "FK_newTableName_Students_studentId",
                        column: x => x.studentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_newTableName_studentId",
                schema: "newScemaName",
                table: "newTableName",
                column: "studentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "newTableName",
                schema: "newScemaName");
        }
    }
}
