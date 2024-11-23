using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CLubBackend.Migrations
{
    /// <inheritdoc />
    public partial class inicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cuotas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Monto = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuotas", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Profesores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Apellido = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesores", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Socios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Apellido = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Direccion = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CuotaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Socios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Socios_Cuotas_CuotaId",
                        column: x => x.CuotaId,
                        principalTable: "Cuotas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Deportes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Hora = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    ProfesorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deportes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deportes_Profesores_ProfesorId",
                        column: x => x.ProfesorId,
                        principalTable: "Profesores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Deportistas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Apellido = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Direccion = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DeporteId = table.Column<int>(type: "int", nullable: false),
                    CuotaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deportistas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deportistas_Cuotas_CuotaId",
                        column: x => x.CuotaId,
                        principalTable: "Cuotas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Deportistas_Deportes_DeporteId",
                        column: x => x.DeporteId,
                        principalTable: "Deportes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Cuotas",
                columns: new[] { "Id", "Descripcion", "Monto", "Nombre" },
                values: new object[,]
                {
                    { 1, "Acceso a actividades deportivas", 1500.00m, "Cuota Deportista" },
                    { 2, "Membresía del club", 1000.00m, "Cuota Socio" }
                });

            migrationBuilder.InsertData(
                table: "Profesores",
                columns: new[] { "Id", "Apellido", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, "Pérez", "Juan", "1234567890" },
                    { 2, "Gómez", "María", "0987654321" },
                    { 3, "López", "Carlos", "1122334455" }
                });

            migrationBuilder.InsertData(
                table: "Deportes",
                columns: new[] { "Id", "Descripcion", "Hora", "Nombre", "ProfesorId" },
                values: new object[,]
                {
                    { 1, "Deporte en equipo", new TimeSpan(0, 18, 0, 0, 0), "Fútbol", 1 },
                    { 2, "Juego de baloncesto", new TimeSpan(0, 19, 30, 0, 0), "Básquet", 2 },
                    { 3, "Deporte acuático", new TimeSpan(0, 17, 0, 0, 0), "Natación", 3 }
                });

            migrationBuilder.InsertData(
                table: "Socios",
                columns: new[] { "Id", "Apellido", "CuotaId", "Direccion", "Email", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, "Pérez", 2, "Av. Central 101", "ana@mail.com", "Ana", "6789012345" },
                    { 2, "Fernández", 2, "Calle Real 202", "javier@mail.com", "Javier", "7890123456" },
                    { 3, "Rodríguez", 2, "Av. Norte 303", "marina@mail.com", "Marina", "8901234567" }
                });

            migrationBuilder.InsertData(
                table: "Deportistas",
                columns: new[] { "Id", "Apellido", "CuotaId", "DeporteId", "Direccion", "Email", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, "Ramírez", 1, 1, "Calle Falsa 123", "pedro@mail.com", "Pedro", "3456789012" },
                    { 2, "Martínez", 1, 2, "Av. Principal 456", "lucia@mail.com", "Lucía", "4567890123" },
                    { 3, "González", 1, 3, "Calle Secundaria 789", "sofia@mail.com", "Sofía", "5678901234" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Deportes_ProfesorId",
                table: "Deportes",
                column: "ProfesorId");

            migrationBuilder.CreateIndex(
                name: "IX_Deportistas_CuotaId",
                table: "Deportistas",
                column: "CuotaId");

            migrationBuilder.CreateIndex(
                name: "IX_Deportistas_DeporteId",
                table: "Deportistas",
                column: "DeporteId");

            migrationBuilder.CreateIndex(
                name: "IX_Socios_CuotaId",
                table: "Socios",
                column: "CuotaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deportistas");

            migrationBuilder.DropTable(
                name: "Socios");

            migrationBuilder.DropTable(
                name: "Deportes");

            migrationBuilder.DropTable(
                name: "Cuotas");

            migrationBuilder.DropTable(
                name: "Profesores");
        }
    }
}
