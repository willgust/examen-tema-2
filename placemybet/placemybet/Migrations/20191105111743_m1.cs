using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace placemybet.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "eventos",
                columns: table => new
                {
                    EventosID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    fecha = table.Column<DateTime>(nullable: false),
                    equipoLocal = table.Column<string>(nullable: true),
                    equipoVisitante = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eventos", x => x.EventosID);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    correoID = table.Column<string>(nullable: false),
                    edad = table.Column<int>(nullable: false),
                    nombre = table.Column<string>(nullable: true),
                    apellido = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.correoID);
                });

            migrationBuilder.CreateTable(
                name: "mercados",
                columns: table => new
                {
                    MercadoID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tipo = table.Column<decimal>(nullable: false),
                    cuotaOver = table.Column<decimal>(nullable: false),
                    cuotaUnder = table.Column<decimal>(nullable: false),
                    apostadoOver = table.Column<decimal>(nullable: false),
                    apostadoUnder = table.Column<decimal>(nullable: false),
                    EventosID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mercados", x => x.MercadoID);
                    table.ForeignKey(
                        name: "FK_mercados_eventos_EventosID",
                        column: x => x.EventosID,
                        principalTable: "eventos",
                        principalColumn: "EventosID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cuentas",
                columns: table => new
                {
                    tarjetaId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    saldo = table.Column<int>(nullable: false),
                    banco = table.Column<string>(nullable: true),
                    correoID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cuentas", x => x.tarjetaId);
                    table.ForeignKey(
                        name: "FK_cuentas_usuarios_correoID",
                        column: x => x.correoID,
                        principalTable: "usuarios",
                        principalColumn: "correoID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "apuestas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tipo = table.Column<string>(nullable: true),
                    cuota = table.Column<decimal>(nullable: false),
                    apostado = table.Column<decimal>(nullable: false),
                    correoID = table.Column<string>(nullable: true),
                    MercadoID = table.Column<int>(nullable: false),
                    esOver = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_apuestas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_apuestas_mercados_MercadoID",
                        column: x => x.MercadoID,
                        principalTable: "mercados",
                        principalColumn: "MercadoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_apuestas_usuarios_correoID",
                        column: x => x.correoID,
                        principalTable: "usuarios",
                        principalColumn: "correoID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_apuestas_MercadoID",
                table: "apuestas",
                column: "MercadoID");

            migrationBuilder.CreateIndex(
                name: "IX_apuestas_correoID",
                table: "apuestas",
                column: "correoID");

            migrationBuilder.CreateIndex(
                name: "IX_cuentas_correoID",
                table: "cuentas",
                column: "correoID");

            migrationBuilder.CreateIndex(
                name: "IX_mercados_EventosID",
                table: "mercados",
                column: "EventosID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "apuestas");

            migrationBuilder.DropTable(
                name: "cuentas");

            migrationBuilder.DropTable(
                name: "mercados");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "eventos");
        }
    }
}
