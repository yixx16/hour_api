using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace horas.Migrations
{
    /// <inheritdoc />
    public partial class pruebadecambiodetabla2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Houras",
                table: "Houras");

            migrationBuilder.RenameTable(
                name: "Houras",
                newName: "Hours");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hours",
                table: "Hours",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Hours",
                table: "Hours");

            migrationBuilder.RenameTable(
                name: "Hours",
                newName: "Houras");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Houras",
                table: "Houras",
                column: "Id");
        }
    }
}
