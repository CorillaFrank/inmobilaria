using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalInmobiliario.Migrations
{
    /// <inheritdoc />
    public partial class AddRolesSupport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Solicitante",
                table: "Visitas");

            migrationBuilder.AlterColumn<string>(
                name: "Comentarios",
                table: "Visitas",
                type: "TEXT",
                maxLength: 300,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 200,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Comentarios",
                table: "Visitas",
                type: "TEXT",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 300);

            migrationBuilder.AddColumn<string>(
                name: "Solicitante",
                table: "Visitas",
                type: "TEXT",
                maxLength: 200,
                nullable: true);
        }
    }
}
