using Microsoft.EntityFrameworkCore.Migrations;

namespace Teleagendamento.Migrations
{
    public partial class ColunaDeVagas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VagasDiarias",
                table: "Clinica",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VagasDiarias",
                table: "Clinica");
        }
    }
}
