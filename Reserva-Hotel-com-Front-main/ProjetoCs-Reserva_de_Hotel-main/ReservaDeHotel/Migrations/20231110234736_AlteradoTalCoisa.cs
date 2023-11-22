using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReservaDeHotel.Migrations
{
    /// <inheritdoc />
    public partial class AlteradoTalCoisa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Avaliacao",
                columns: table => new
                {
                    IdAvaliacao = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HotelId = table.Column<int>(type: "INTEGER", nullable: true),
                    AvaliacaoEstrelas = table.Column<int>(type: "INTEGER", nullable: true),
                    Comentario = table.Column<string>(type: "TEXT", nullable: true),
                    DataAvaliacao = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacao", x => x.IdAvaliacao);
                });

            migrationBuilder.CreateTable(
                name: "Cidade",
                columns: table => new
                {
                    IdCidade = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Estado = table.Column<string>(type: "TEXT", nullable: true),
                    País = table.Column<string>(type: "TEXT", nullable: true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidade", x => x.IdCidade);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    NumeroTelefone = table.Column<int>(type: "INTEGER", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Login = table.Column<string>(type: "TEXT", nullable: true),
                    Senha = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Dono",
                columns: table => new
                {
                    IdDono = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    NumeroTelefone = table.Column<int>(type: "INTEGER", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Login = table.Column<string>(type: "TEXT", nullable: true),
                    Senha = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dono", x => x.IdDono);
                });

            migrationBuilder.CreateTable(
                name: "EstadiaHotel",
                columns: table => new
                {
                    IdEstadia = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    QtdQuartos = table.Column<int>(type: "INTEGER", nullable: true),
                    DataEntrada = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DataSaida = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadiaHotel", x => x.IdEstadia);
                });

            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    IDHotel = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Endereco = table.Column<string>(type: "TEXT", nullable: true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true),
                    ListaDeQuartos = table.Column<string>(type: "TEXT", nullable: true),
                    NumeroTotalDeQuartos = table.Column<int>(type: "INTEGER", nullable: false),
                    NumeroDeQuartosDisponiveis = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.IDHotel);
                });

            migrationBuilder.CreateTable(
                name: "ReservaHotel",
                columns: table => new
                {
                    IdReserva = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeHospede = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservaHotel", x => x.IdReserva);
                });

            migrationBuilder.CreateTable(
                name: "AvaliacaoHotel",
                columns: table => new
                {
                    HoteisIDHotel = table.Column<int>(type: "INTEGER", nullable: false),
                    ListaAvaliacoesIdAvaliacao = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvaliacaoHotel", x => new { x.HoteisIDHotel, x.ListaAvaliacoesIdAvaliacao });
                    table.ForeignKey(
                        name: "FK_AvaliacaoHotel_Avaliacao_ListaAvaliacoesIdAvaliacao",
                        column: x => x.ListaAvaliacoesIdAvaliacao,
                        principalTable: "Avaliacao",
                        principalColumn: "IdAvaliacao",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AvaliacaoHotel_Hotel_HoteisIDHotel",
                        column: x => x.HoteisIDHotel,
                        principalTable: "Hotel",
                        principalColumn: "IDHotel",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CidadeHotel",
                columns: table => new
                {
                    CidadesIdCidade = table.Column<int>(type: "INTEGER", nullable: false),
                    HoteisIDHotel = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CidadeHotel", x => new { x.CidadesIdCidade, x.HoteisIDHotel });
                    table.ForeignKey(
                        name: "FK_CidadeHotel_Cidade_CidadesIdCidade",
                        column: x => x.CidadesIdCidade,
                        principalTable: "Cidade",
                        principalColumn: "IdCidade",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CidadeHotel_Hotel_HoteisIDHotel",
                        column: x => x.HoteisIDHotel,
                        principalTable: "Hotel",
                        principalColumn: "IDHotel",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comodidade",
                columns: table => new
                {
                    IDComodidade = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NumeroDoQuarto = table.Column<int>(type: "INTEGER", nullable: true),
                    TipoDeQuarto = table.Column<string>(type: "TEXT", nullable: true),
                    PrecoPorNoite = table.Column<decimal>(type: "TEXT", nullable: true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true),
                    Disponibilidade = table.Column<bool>(type: "INTEGER", nullable: true),
                    HotelId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comodidade", x => x.IDComodidade);
                    table.ForeignKey(
                        name: "FK_Comodidade_Hotel_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotel",
                        principalColumn: "IDHotel");
                });

            migrationBuilder.CreateTable(
                name: "DonoHotel",
                columns: table => new
                {
                    DonosIdDono = table.Column<int>(type: "INTEGER", nullable: false),
                    HoteisIDHotel = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonoHotel", x => new { x.DonosIdDono, x.HoteisIDHotel });
                    table.ForeignKey(
                        name: "FK_DonoHotel_Dono_DonosIdDono",
                        column: x => x.DonosIdDono,
                        principalTable: "Dono",
                        principalColumn: "IdDono",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DonoHotel_Hotel_HoteisIDHotel",
                        column: x => x.HoteisIDHotel,
                        principalTable: "Hotel",
                        principalColumn: "IDHotel",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EstadiaHotelReservaHotel",
                columns: table => new
                {
                    EstadiasIdEstadia = table.Column<int>(type: "INTEGER", nullable: false),
                    ReservasIdReserva = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadiaHotelReservaHotel", x => new { x.EstadiasIdEstadia, x.ReservasIdReserva });
                    table.ForeignKey(
                        name: "FK_EstadiaHotelReservaHotel_EstadiaHotel_EstadiasIdEstadia",
                        column: x => x.EstadiasIdEstadia,
                        principalTable: "EstadiaHotel",
                        principalColumn: "IdEstadia",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstadiaHotelReservaHotel_ReservaHotel_ReservasIdReserva",
                        column: x => x.ReservasIdReserva,
                        principalTable: "ReservaHotel",
                        principalColumn: "IdReserva",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pagamento",
                columns: table => new
                {
                    IdPagamento = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ReservaId = table.Column<int>(type: "INTEGER", nullable: true),
                    MetodoPagamento = table.Column<string>(type: "TEXT", nullable: true),
                    Valor = table.Column<decimal>(type: "TEXT", nullable: true),
                    DataPagamento = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamento", x => x.IdPagamento);
                    table.ForeignKey(
                        name: "FK_Pagamento_ReservaHotel_ReservaId",
                        column: x => x.ReservaId,
                        principalTable: "ReservaHotel",
                        principalColumn: "IdReserva");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacaoHotel_ListaAvaliacoesIdAvaliacao",
                table: "AvaliacaoHotel",
                column: "ListaAvaliacoesIdAvaliacao");

            migrationBuilder.CreateIndex(
                name: "IX_CidadeHotel_HoteisIDHotel",
                table: "CidadeHotel",
                column: "HoteisIDHotel");

            migrationBuilder.CreateIndex(
                name: "IX_Comodidade_HotelId",
                table: "Comodidade",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_DonoHotel_HoteisIDHotel",
                table: "DonoHotel",
                column: "HoteisIDHotel");

            migrationBuilder.CreateIndex(
                name: "IX_EstadiaHotelReservaHotel_ReservasIdReserva",
                table: "EstadiaHotelReservaHotel",
                column: "ReservasIdReserva");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamento_ReservaId",
                table: "Pagamento",
                column: "ReservaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvaliacaoHotel");

            migrationBuilder.DropTable(
                name: "CidadeHotel");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Comodidade");

            migrationBuilder.DropTable(
                name: "DonoHotel");

            migrationBuilder.DropTable(
                name: "EstadiaHotelReservaHotel");

            migrationBuilder.DropTable(
                name: "Pagamento");

            migrationBuilder.DropTable(
                name: "Avaliacao");

            migrationBuilder.DropTable(
                name: "Cidade");

            migrationBuilder.DropTable(
                name: "Dono");

            migrationBuilder.DropTable(
                name: "Hotel");

            migrationBuilder.DropTable(
                name: "EstadiaHotel");

            migrationBuilder.DropTable(
                name: "ReservaHotel");
        }
    }
}
