using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthPrestamos.Migrations
{
    public partial class change_property_user_id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "IdUsuario",
                table: "Prestamo",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "AlgoMas",
                table: "Abono",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdAlgoMas",
                table: "Abono",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PrestamoId",
                table: "Abono",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Abono_PrestamoId",
                table: "Abono",
                column: "PrestamoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Abono_Prestamo_PrestamoId",
                table: "Abono",
                column: "PrestamoId",
                principalTable: "Prestamo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Abono_Prestamo_PrestamoId",
                table: "Abono");

            migrationBuilder.DropIndex(
                name: "IX_Abono_PrestamoId",
                table: "Abono");

            migrationBuilder.DropColumn(
                name: "AlgoMas",
                table: "Abono");

            migrationBuilder.DropColumn(
                name: "IdAlgoMas",
                table: "Abono");

            migrationBuilder.DropColumn(
                name: "PrestamoId",
                table: "Abono");

            migrationBuilder.AlterColumn<string>(
                name: "IdUsuario",
                table: "Prestamo",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }
    }
}
