using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VentasSD.Migrations
{
    /// <inheritdoc />
    public partial class usuarionullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Usuarios_IdUsuario",
                table: "Clientes");

            migrationBuilder.AlterColumn<int>(
                name: "IdUsuario",
                table: "Clientes",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Usuarios_IdUsuario",
                table: "Clientes",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Usuarios_IdUsuario",
                table: "Clientes");

            migrationBuilder.AlterColumn<int>(
                name: "IdUsuario",
                table: "Clientes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Usuarios_IdUsuario",
                table: "Clientes",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
