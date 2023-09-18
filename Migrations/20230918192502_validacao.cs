using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaVeterinaria.Migrations
{
    /// <inheritdoc />
    public partial class validacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Funcionarios",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Funcionarios");
        }
    }
}
