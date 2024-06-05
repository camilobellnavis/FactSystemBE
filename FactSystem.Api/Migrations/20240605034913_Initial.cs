using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FactSystem.Api.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cab_factura",
                columns: table => new
                {
                    id_factura = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    num_factura = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "10001, 1"),
                    dni_cliente = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    impuesto = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    subtotal = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    total = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cab_factura", x => x.id_factura);
                });

            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    id_cliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    identificacion = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    correo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "date", nullable: false),
                    activo = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.id_cliente);
                });

            migrationBuilder.CreateTable(
                name: "producto",
                columns: table => new
                {
                    id_producto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    activo = table.Column<byte>(type: "tinyint", nullable: false),
                    codigo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "date", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    precio = table.Column<decimal>(type: "decimal(38,17)", nullable: false),
                    inventario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_producto", x => x.id_producto);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    nombre_usuario = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    bloqueado = table.Column<byte>(type: "tinyint", nullable: false),
                    intentos_fallidos = table.Column<int>(type: "int", nullable: false),
                    contraseña = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.nombre_usuario);
                });

            migrationBuilder.CreateTable(
                name: "det_factura",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    codigo_producto = table.Column<int>(type: "int", nullable: false),
                    cab_factura = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_det_factura", x => x.id);
                    table.ForeignKey(
                        name: "FK_DetFactura_CabFactura",
                        column: x => x.cab_factura,
                        principalTable: "cab_factura",
                        principalColumn: "id_factura");
                });

            migrationBuilder.CreateIndex(
                name: "IX_det_factura_cab_factura",
                table: "det_factura",
                column: "cab_factura");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cliente");

            migrationBuilder.DropTable(
                name: "det_factura");

            migrationBuilder.DropTable(
                name: "producto");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "cab_factura");
        }
    }
}
