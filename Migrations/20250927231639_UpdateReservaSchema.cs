using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalInmobiliario.Migrations
{
    /// <inheritdoc />
    public partial class UpdateReservaSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cliente",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "EsActiva",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "Observaciones",
                table: "Reservas");

            migrationBuilder.RenameColumn(
                name: "FechaInicio",
                table: "Reservas",
                newName: "UsuarioId");

            migrationBuilder.RenameColumn(
                name: "FechaFin",
                table: "Reservas",
                newName: "FechaExpiracion");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "Reservas",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "Reservas");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Reservas",
                newName: "FechaInicio");

            migrationBuilder.RenameColumn(
                name: "FechaExpiracion",
                table: "Reservas",
                newName: "FechaFin");

            migrationBuilder.AddColumn<string>(
                name: "Cliente",
                table: "Reservas",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "EsActiva",
                table: "Reservas",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Observaciones",
                table: "Reservas",
                type: "TEXT",
                maxLength: 200,
                nullable: true);
        }
    }
}
