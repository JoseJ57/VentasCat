using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VentasSD.Migrations
{
    /// <inheritdoc />
    public partial class RelacionUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Usuarios_IdUsuario",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Usuarios_IdUsuario",
                table: "Empleados");

            migrationBuilder.DropIndex(
                name: "IX_Empleados_IdUsuario",
                table: "Empleados");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_IdUsuario",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "Clientes");

            migrationBuilder.AddColumn<int>(
                name: "IdCliente",
                table: "Usuarios",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdEmpleado",
                table: "Usuarios",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdCliente",
                table: "Usuarios",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdEmpleado",
                table: "Usuarios",
                column: "IdEmpleado");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Clientes_IdCliente",
                table: "Usuarios",
                column: "IdCliente",
                principalTable: "Clientes",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Empleados_IdEmpleado",
                table: "Usuarios",
                column: "IdEmpleado",
                principalTable: "Empleados",
                principalColumn: "IdEmpleado",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Clientes_IdCliente",
                table: "Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Empleados_IdEmpleado",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_IdCliente",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_IdEmpleado",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "IdCliente",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "IdEmpleado",
                table: "Usuarios");

            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "Empleados",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "Clientes",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_IdUsuario",
                table: "Empleados",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_IdUsuario",
                table: "Clientes",
                column: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Usuarios_IdUsuario",
                table: "Clientes",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Usuarios_IdUsuario",
                table: "Empleados",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
