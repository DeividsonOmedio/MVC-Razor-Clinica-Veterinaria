using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaVeterinaria.Migrations
{
    /// <inheritdoc />
    public partial class atualizaTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FuncionarioId",
                table: "Procedimentos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UltimaAtualizacao",
                table: "Procedimentos",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Procedimentos_FuncionarioId",
                table: "Procedimentos",
                column: "FuncionarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Procedimentos_Funcionarios_FuncionarioId",
                table: "Procedimentos",
                column: "FuncionarioId",
                principalTable: "Funcionarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Procedimentos_Funcionarios_FuncionarioId",
                table: "Procedimentos");

            migrationBuilder.DropIndex(
                name: "IX_Procedimentos_FuncionarioId",
                table: "Procedimentos");

            migrationBuilder.DropColumn(
                name: "FuncionarioId",
                table: "Procedimentos");

            migrationBuilder.DropColumn(
                name: "UltimaAtualizacao",
                table: "Procedimentos");
        }
    }
}
