using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Units.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conversions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Units = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Dimension = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Factor = table.Column<decimal>(type: "numeric(15,8)", precision: 15, scale: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conversions_Dimension",
                table: "Conversions",
                column: "Dimension");

            migrationBuilder.CreateIndex(
                name: "IX_Conversions_Id",
                table: "Conversions",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conversions");
        }
    }
}
