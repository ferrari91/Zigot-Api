using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Zigot.Infrastructure.Identity.Migrations
{
    /// <inheritdoc />
    public partial class StartUp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pes_cliente",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    data_nascimento = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    nome_mae = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    nome_pai = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    profissao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    tem_filhos = table.Column<bool>(type: "boolean", nullable: false),
                    data_cadastro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    estado_civil = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pes_cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pes_contato",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PersonId = table.Column<long>(type: "bigint", nullable: false),
                    telefone = table.Column<string>(type: "character varying(35)", maxLength: 35, nullable: false),
                    email = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    cidade_origem = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    uf_origem = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pes_contato", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pes_contato_pes_cliente_PersonId",
                        column: x => x.PersonId,
                        principalTable: "pes_cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pes_documento",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PersonId = table.Column<long>(type: "bigint", nullable: false),
                    cpf = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    rg = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    orgao = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    euf = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    data_emissao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    titulo_eleitoral = table.Column<string>(type: "character varying(35)", maxLength: 35, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pes_documento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pes_documento_pes_cliente_PersonId",
                        column: x => x.PersonId,
                        principalTable: "pes_cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pes_endereco",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PersonId = table.Column<long>(type: "bigint", nullable: false),
                    endereco = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    numero = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    bairro = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    complemento = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    cidade = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    uf = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    cep = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pes_endereco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pes_endereco_pes_cliente_PersonId",
                        column: x => x.PersonId,
                        principalTable: "pes_cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pes_processo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PersonId = table.Column<long>(type: "bigint", nullable: false),
                    arma = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    tipo_registro = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    data_cadastro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    calibre = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pes_processo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pes_processo_pes_cliente_PersonId",
                        column: x => x.PersonId,
                        principalTable: "pes_cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reg_federal",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProcessId = table.Column<long>(type: "bigint", nullable: false),
                    data_cadastro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    finalizado = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reg_federal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_reg_federal_pes_processo_ProcessId",
                        column: x => x.ProcessId,
                        principalTable: "pes_processo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reg_federal_documentos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FederalRegistrationId = table.Column<long>(type: "bigint", nullable: false),
                    descricao_documento = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    codigo_referencia_bucket = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reg_federal_documentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_reg_federal_documentos_reg_federal_FederalRegistrationId",
                        column: x => x.FederalRegistrationId,
                        principalTable: "reg_federal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pes_contato_PersonId",
                table: "pes_contato",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_pes_documento_PersonId",
                table: "pes_documento",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_pes_endereco_PersonId",
                table: "pes_endereco",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_pes_processo_PersonId",
                table: "pes_processo",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_reg_federal_ProcessId",
                table: "reg_federal",
                column: "ProcessId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_reg_federal_documentos_FederalRegistrationId",
                table: "reg_federal_documentos",
                column: "FederalRegistrationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pes_contato");

            migrationBuilder.DropTable(
                name: "pes_documento");

            migrationBuilder.DropTable(
                name: "pes_endereco");

            migrationBuilder.DropTable(
                name: "reg_federal_documentos");

            migrationBuilder.DropTable(
                name: "reg_federal");

            migrationBuilder.DropTable(
                name: "pes_processo");

            migrationBuilder.DropTable(
                name: "pes_cliente");
        }
    }
}
