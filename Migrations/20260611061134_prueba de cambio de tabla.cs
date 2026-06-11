using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace horas.Migrations
{
    /// <inheritdoc />
    public partial class pruebadecambiodetabla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hours");

            migrationBuilder.CreateTable(
                name: "Houras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    H = table.Column<int>(type: "integer", nullable: false),
                    M = table.Column<int>(type: "integer", nullable: false),
                    S = table.Column<int>(type: "integer", nullable: false),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houras", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Houras");

            migrationBuilder.CreateTable(
                name: "Hours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    H = table.Column<int>(type: "integer", nullable: false),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    M = table.Column<int>(type: "integer", nullable: false),
                    S = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hours", x => x.Id);
                });
        }
    }
}
