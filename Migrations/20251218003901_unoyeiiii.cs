using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VentasSD.Migrations
{
    /// <inheritdoc />
    public partial class unoyeiiii : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    IdMarca = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Pais = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.IdMarca);
                });

            migrationBuilder.CreateTable(
                name: "Materiales",
                columns: table => new
                {
                    IdMaterial = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materiales", x => x.IdMaterial);
                });

            migrationBuilder.CreateTable(
                name: "Tallas",
                columns: table => new
                {
                    IdTalla = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tallas", x => x.IdTalla);
                });

            migrationBuilder.CreateTable(
                name: "Tipos",
                columns: table => new
                {
                    IdTipo = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipos", x => x.IdTipo);
                });

            migrationBuilder.CreateTable(
                name: "Transportes",
                columns: table => new
                {
                    IdTransporte = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Tipo = table.Column<int>(type: "INTEGER", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Empresa = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Celular = table.Column<string>(type: "TEXT", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transportes", x => x.IdTransporte);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreUsuario = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Estado = table.Column<bool>(type: "INTEGER", nullable: false),
                    Rol = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Articulos",
                columns: table => new
                {
                    IdArticulo = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Recomendaciones = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Eslogan = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Precio = table.Column<decimal>(type: "TEXT", nullable: false),
                    Estado = table.Column<int>(type: "INTEGER", nullable: false),
                    Imagen = table.Column<string>(type: "TEXT", nullable: false),
                    Categoria = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoArticulo = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    IdMarca = table.Column<int>(type: "INTEGER", nullable: false),
                    IdTipo = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulos", x => x.IdArticulo);
                    table.ForeignKey(
                        name: "FK_Articulos_Marcas_IdMarca",
                        column: x => x.IdMarca,
                        principalTable: "Marcas",
                        principalColumn: "IdMarca",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Articulos_Tipos_IdTipo",
                        column: x => x.IdTipo,
                        principalTable: "Tipos",
                        principalColumn: "IdTipo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TallaTipos",
                columns: table => new
                {
                    IdTallaTipo = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdTalla = table.Column<int>(type: "INTEGER", nullable: false),
                    IdTipo = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TallaTipos", x => x.IdTallaTipo);
                    table.ForeignKey(
                        name: "FK_TallaTipos_Tallas_IdTalla",
                        column: x => x.IdTalla,
                        principalTable: "Tallas",
                        principalColumn: "IdTalla",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TallaTipos_Tipos_IdTipo",
                        column: x => x.IdTipo,
                        principalTable: "Tipos",
                        principalColumn: "IdTipo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TipoMateriales",
                columns: table => new
                {
                    IdTipoMaterial = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdMaterial = table.Column<int>(type: "INTEGER", nullable: false),
                    IdTipo = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMateriales", x => x.IdTipoMaterial);
                    table.ForeignKey(
                        name: "FK_TipoMateriales_Materiales_IdMaterial",
                        column: x => x.IdMaterial,
                        principalTable: "Materiales",
                        principalColumn: "IdMaterial",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TipoMateriales_Tipos_IdTipo",
                        column: x => x.IdTipo,
                        principalTable: "Tipos",
                        principalColumn: "IdTipo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Envios",
                columns: table => new
                {
                    IdEnvio = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Direccion = table.Column<string>(type: "TEXT", nullable: false),
                    FechaEntrega = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Costo = table.Column<decimal>(type: "TEXT", nullable: false),
                    Estado = table.Column<int>(type: "INTEGER", nullable: false),
                    PagoIncluido = table.Column<bool>(type: "INTEGER", nullable: false),
                    IdTransporte = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Envios", x => x.IdEnvio);
                    table.ForeignKey(
                        name: "FK_Envios_Transportes_IdTransporte",
                        column: x => x.IdTransporte,
                        principalTable: "Transportes",
                        principalColumn: "IdTransporte",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Apellido = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Carnet = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    FechaNacimiento = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Nit = table.Column<int>(type: "INTEGER", nullable: false),
                    Frecuente = table.Column<bool>(type: "INTEGER", nullable: false),
                    Celular = table.Column<string>(type: "TEXT", maxLength: 8, nullable: false),
                    IdUsuario = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.IdCliente);
                    table.ForeignKey(
                        name: "FK_Clientes_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    IdEmpleado = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Apellido = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Celular = table.Column<string>(type: "TEXT", maxLength: 8, nullable: false),
                    Carnet = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    Cargo = table.Column<int>(type: "INTEGER", nullable: false),
                    Sueldo = table.Column<decimal>(type: "TEXT", nullable: false),
                    Estado = table.Column<bool>(type: "INTEGER", nullable: false),
                    FechaNacimiento = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    IdUsuario = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.IdEmpleado);
                    table.ForeignKey(
                        name: "FK_Empleados_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaterialArticulos",
                columns: table => new
                {
                    IdMaterialArticulo = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdArticulo = table.Column<int>(type: "INTEGER", nullable: false),
                    IdMaterial = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialArticulos", x => x.IdMaterialArticulo);
                    table.ForeignKey(
                        name: "FK_MaterialArticulos_Articulos_IdArticulo",
                        column: x => x.IdArticulo,
                        principalTable: "Articulos",
                        principalColumn: "IdArticulo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaterialArticulos_Materiales_IdMaterial",
                        column: x => x.IdMaterial,
                        principalTable: "Materiales",
                        principalColumn: "IdMaterial",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TallaArticulos",
                columns: table => new
                {
                    IdTallaArticulo = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdArticulo = table.Column<int>(type: "INTEGER", nullable: false),
                    IdTalla = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TallaArticulos", x => x.IdTallaArticulo);
                    table.ForeignKey(
                        name: "FK_TallaArticulos_Articulos_IdArticulo",
                        column: x => x.IdArticulo,
                        principalTable: "Articulos",
                        principalColumn: "IdArticulo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TallaArticulos_Tallas_IdTalla",
                        column: x => x.IdTalla,
                        principalTable: "Tallas",
                        principalColumn: "IdTalla",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Creditos",
                columns: table => new
                {
                    IdCredito = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Monto = table.Column<decimal>(type: "TEXT", nullable: false),
                    Observacion = table.Column<string>(type: "TEXT", nullable: true),
                    IdCliente = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Creditos", x => x.IdCredito);
                    table.ForeignKey(
                        name: "FK_Creditos_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ordenes",
                columns: table => new
                {
                    IdOrden = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Pago = table.Column<int>(type: "INTEGER", nullable: false),
                    Total = table.Column<decimal>(type: "TEXT", nullable: false),
                    Estado = table.Column<int>(type: "INTEGER", nullable: false),
                    ConEnvio = table.Column<bool>(type: "INTEGER", nullable: false),
                    IdUsuario = table.Column<int>(type: "INTEGER", nullable: false),
                    IdCredito = table.Column<int>(type: "INTEGER", nullable: false),
                    IdEnvio = table.Column<int>(type: "INTEGER", nullable: false),
                    ClienteIdCliente = table.Column<int>(type: "INTEGER", nullable: true),
                    EmpleadoIdEmpleado = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordenes", x => x.IdOrden);
                    table.ForeignKey(
                        name: "FK_Ordenes_Clientes_ClienteIdCliente",
                        column: x => x.ClienteIdCliente,
                        principalTable: "Clientes",
                        principalColumn: "IdCliente");
                    table.ForeignKey(
                        name: "FK_Ordenes_Creditos_IdCredito",
                        column: x => x.IdCredito,
                        principalTable: "Creditos",
                        principalColumn: "IdCredito",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ordenes_Empleados_EmpleadoIdEmpleado",
                        column: x => x.EmpleadoIdEmpleado,
                        principalTable: "Empleados",
                        principalColumn: "IdEmpleado");
                    table.ForeignKey(
                        name: "FK_Ordenes_Envios_IdEnvio",
                        column: x => x.IdEnvio,
                        principalTable: "Envios",
                        principalColumn: "IdEnvio",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ordenes_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleOrdenes",
                columns: table => new
                {
                    IdDetalleOrden = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    Subtotal = table.Column<decimal>(type: "TEXT", nullable: false),
                    Observacion = table.Column<string>(type: "TEXT", nullable: false),
                    Descuento = table.Column<decimal>(type: "TEXT", nullable: false),
                    IdOrden = table.Column<int>(type: "INTEGER", nullable: false),
                    IdArticulo = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleOrdenes", x => x.IdDetalleOrden);
                    table.ForeignKey(
                        name: "FK_DetalleOrdenes_Articulos_IdArticulo",
                        column: x => x.IdArticulo,
                        principalTable: "Articulos",
                        principalColumn: "IdArticulo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleOrdenes_Ordenes_IdOrden",
                        column: x => x.IdOrden,
                        principalTable: "Ordenes",
                        principalColumn: "IdOrden",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TipoPagos",
                columns: table => new
                {
                    IdTipoPago = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Comprobante = table.Column<byte[]>(type: "BLOB", nullable: false),
                    Codigo = table.Column<string>(type: "TEXT", nullable: true),
                    Estado = table.Column<bool>(type: "INTEGER", nullable: false),
                    IdOrden = table.Column<int>(type: "INTEGER", nullable: false),
                    IdCredito = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPagos", x => x.IdTipoPago);
                    table.ForeignKey(
                        name: "FK_TipoPagos_Creditos_IdCredito",
                        column: x => x.IdCredito,
                        principalTable: "Creditos",
                        principalColumn: "IdCredito",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TipoPagos_Ordenes_IdOrden",
                        column: x => x.IdOrden,
                        principalTable: "Ordenes",
                        principalColumn: "IdOrden",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventarios",
                columns: table => new
                {
                    IdInventario = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaUpdate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Accion = table.Column<int>(type: "INTEGER", nullable: false),
                    PrecioIngreso = table.Column<decimal>(type: "TEXT", nullable: false),
                    IdArticulo = table.Column<int>(type: "INTEGER", nullable: false),
                    DetalleOrdenIdDetalleOrden = table.Column<int>(type: "INTEGER", nullable: true),
                    EmpleadoIdEmpleado = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventarios", x => x.IdInventario);
                    table.ForeignKey(
                        name: "FK_Inventarios_Articulos_IdArticulo",
                        column: x => x.IdArticulo,
                        principalTable: "Articulos",
                        principalColumn: "IdArticulo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventarios_DetalleOrdenes_DetalleOrdenIdDetalleOrden",
                        column: x => x.DetalleOrdenIdDetalleOrden,
                        principalTable: "DetalleOrdenes",
                        principalColumn: "IdDetalleOrden");
                    table.ForeignKey(
                        name: "FK_Inventarios_Empleados_EmpleadoIdEmpleado",
                        column: x => x.EmpleadoIdEmpleado,
                        principalTable: "Empleados",
                        principalColumn: "IdEmpleado");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_IdMarca",
                table: "Articulos",
                column: "IdMarca");

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_IdTipo",
                table: "Articulos",
                column: "IdTipo");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_IdUsuario",
                table: "Clientes",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Creditos_IdCliente",
                table: "Creditos",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleOrdenes_IdArticulo",
                table: "DetalleOrdenes",
                column: "IdArticulo");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleOrdenes_IdOrden",
                table: "DetalleOrdenes",
                column: "IdOrden");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_IdUsuario",
                table: "Empleados",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Envios_IdTransporte",
                table: "Envios",
                column: "IdTransporte");

            migrationBuilder.CreateIndex(
                name: "IX_Inventarios_DetalleOrdenIdDetalleOrden",
                table: "Inventarios",
                column: "DetalleOrdenIdDetalleOrden");

            migrationBuilder.CreateIndex(
                name: "IX_Inventarios_EmpleadoIdEmpleado",
                table: "Inventarios",
                column: "EmpleadoIdEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_Inventarios_IdArticulo",
                table: "Inventarios",
                column: "IdArticulo");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialArticulos_IdArticulo",
                table: "MaterialArticulos",
                column: "IdArticulo");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialArticulos_IdMaterial",
                table: "MaterialArticulos",
                column: "IdMaterial");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_ClienteIdCliente",
                table: "Ordenes",
                column: "ClienteIdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_EmpleadoIdEmpleado",
                table: "Ordenes",
                column: "EmpleadoIdEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_IdCredito",
                table: "Ordenes",
                column: "IdCredito");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_IdEnvio",
                table: "Ordenes",
                column: "IdEnvio");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_IdUsuario",
                table: "Ordenes",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_TallaArticulos_IdArticulo",
                table: "TallaArticulos",
                column: "IdArticulo");

            migrationBuilder.CreateIndex(
                name: "IX_TallaArticulos_IdTalla",
                table: "TallaArticulos",
                column: "IdTalla");

            migrationBuilder.CreateIndex(
                name: "IX_TallaTipos_IdTalla",
                table: "TallaTipos",
                column: "IdTalla");

            migrationBuilder.CreateIndex(
                name: "IX_TallaTipos_IdTipo",
                table: "TallaTipos",
                column: "IdTipo");

            migrationBuilder.CreateIndex(
                name: "IX_TipoMateriales_IdMaterial",
                table: "TipoMateriales",
                column: "IdMaterial");

            migrationBuilder.CreateIndex(
                name: "IX_TipoMateriales_IdTipo",
                table: "TipoMateriales",
                column: "IdTipo");

            migrationBuilder.CreateIndex(
                name: "IX_TipoPagos_IdCredito",
                table: "TipoPagos",
                column: "IdCredito");

            migrationBuilder.CreateIndex(
                name: "IX_TipoPagos_IdOrden",
                table: "TipoPagos",
                column: "IdOrden");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventarios");

            migrationBuilder.DropTable(
                name: "MaterialArticulos");

            migrationBuilder.DropTable(
                name: "TallaArticulos");

            migrationBuilder.DropTable(
                name: "TallaTipos");

            migrationBuilder.DropTable(
                name: "TipoMateriales");

            migrationBuilder.DropTable(
                name: "TipoPagos");

            migrationBuilder.DropTable(
                name: "DetalleOrdenes");

            migrationBuilder.DropTable(
                name: "Tallas");

            migrationBuilder.DropTable(
                name: "Materiales");

            migrationBuilder.DropTable(
                name: "Articulos");

            migrationBuilder.DropTable(
                name: "Ordenes");

            migrationBuilder.DropTable(
                name: "Marcas");

            migrationBuilder.DropTable(
                name: "Tipos");

            migrationBuilder.DropTable(
                name: "Creditos");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Envios");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Transportes");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
