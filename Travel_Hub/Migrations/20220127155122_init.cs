using Microsoft.EntityFrameworkCore.Migrations;

namespace Travel_Hub.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Firma",
                columns: table => new
                {
                    FirmaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa_firmy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firma", x => x.FirmaId);
                });

            migrationBuilder.CreateTable(
                name: "MiejscaStartu",
                columns: table => new
                {
                    MiejscaStartuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa_miejsca = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MiejscaStartu", x => x.MiejscaStartuId);
                });

            migrationBuilder.CreateTable(
                name: "OpcjeWyzywienia",
                columns: table => new
                {
                    OpcjeWyzywieniaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa_opcji_wyzyw = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpcjeWyzywienia", x => x.OpcjeWyzywieniaId);
                });

            migrationBuilder.CreateTable(
                name: "Osrodki",
                columns: table => new
                {
                    OsrodkiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa_osrodka = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Zdjecie = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Osrodki", x => x.OsrodkiId);
                });

            migrationBuilder.CreateTable(
                name: "RodzajePokoi",
                columns: table => new
                {
                    RodzajePokoiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa_rodzaju_pokoju = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RodzajePokoi", x => x.RodzajePokoiId);
                });

            migrationBuilder.CreateTable(
                name: "OferowaneWyzywienia",
                columns: table => new
                {
                    OsrodkiId = table.Column<int>(type: "int", nullable: false),
                    OpcjeWyzywieniaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OferowaneWyzywienia", x => new { x.OpcjeWyzywieniaId, x.OsrodkiId });
                    table.ForeignKey(
                        name: "FK_OferowaneWyzywienia_OpcjeWyzywienia_OpcjeWyzywieniaId",
                        column: x => x.OpcjeWyzywieniaId,
                        principalTable: "OpcjeWyzywienia",
                        principalColumn: "OpcjeWyzywieniaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OferowaneWyzywienia_Osrodki_OsrodkiId",
                        column: x => x.OsrodkiId,
                        principalTable: "Osrodki",
                        principalColumn: "OsrodkiId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WybraneWyzywienia",
                columns: table => new
                {
                    WybraneWyzywieniaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OsrodkiId = table.Column<int>(type: "int", nullable: false),
                    OpcjeWyzywieniaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WybraneWyzywienia", x => x.WybraneWyzywieniaId);
                    table.ForeignKey(
                        name: "FK_WybraneWyzywienia_OpcjeWyzywienia_OpcjeWyzywieniaId",
                        column: x => x.OpcjeWyzywieniaId,
                        principalTable: "OpcjeWyzywienia",
                        principalColumn: "OpcjeWyzywieniaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WybraneWyzywienia_Osrodki_OsrodkiId",
                        column: x => x.OsrodkiId,
                        principalTable: "Osrodki",
                        principalColumn: "OsrodkiId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wycieczka",
                columns: table => new
                {
                    WycieczkaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Max_osob = table.Column<int>(type: "int", nullable: false),
                    Cena = table.Column<float>(type: "real", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stan = table.Column<int>(type: "int", nullable: false),
                    OsrodkiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wycieczka", x => x.WycieczkaId);
                    table.ForeignKey(
                        name: "FK_Wycieczka_Osrodki_OsrodkiId",
                        column: x => x.OsrodkiId,
                        principalTable: "Osrodki",
                        principalColumn: "OsrodkiId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OferowanePokoje",
                columns: table => new
                {
                    RodzajePokoiId = table.Column<int>(type: "int", nullable: false),
                    OsrodkiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OferowanePokoje", x => new { x.OsrodkiId, x.RodzajePokoiId });
                    table.ForeignKey(
                        name: "FK_OferowanePokoje_Osrodki_OsrodkiId",
                        column: x => x.OsrodkiId,
                        principalTable: "Osrodki",
                        principalColumn: "OsrodkiId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OferowanePokoje_RodzajePokoi_RodzajePokoiId",
                        column: x => x.RodzajePokoiId,
                        principalTable: "RodzajePokoi",
                        principalColumn: "RodzajePokoiId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WybranePokoje",
                columns: table => new
                {
                    WybranePokojeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OsrodkiId = table.Column<int>(type: "int", nullable: false),
                    RodzajePokoiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WybranePokoje", x => x.WybranePokojeId);
                    table.ForeignKey(
                        name: "FK_WybranePokoje_Osrodki_OsrodkiId",
                        column: x => x.OsrodkiId,
                        principalTable: "Osrodki",
                        principalColumn: "OsrodkiId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WybranePokoje_RodzajePokoi_RodzajePokoiId",
                        column: x => x.RodzajePokoiId,
                        principalTable: "RodzajePokoi",
                        principalColumn: "RodzajePokoiId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OferowaneMiejscaStartu",
                columns: table => new
                {
                    OferowaneMiejscaStartuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MiejscaStartuId = table.Column<int>(type: "int", nullable: false),
                    WycieczkaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OferowaneMiejscaStartu", x => x.OferowaneMiejscaStartuId);
                    table.ForeignKey(
                        name: "FK_OferowaneMiejscaStartu_MiejscaStartu_MiejscaStartuId",
                        column: x => x.MiejscaStartuId,
                        principalTable: "MiejscaStartu",
                        principalColumn: "MiejscaStartuId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OferowaneMiejscaStartu_Wycieczka_WycieczkaId",
                        column: x => x.WycieczkaId,
                        principalTable: "Wycieczka",
                        principalColumn: "WycieczkaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfertaFirmy",
                columns: table => new
                {
                    FirmaId = table.Column<int>(type: "int", nullable: false),
                    WycieczkaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfertaFirmy", x => new { x.FirmaId, x.WycieczkaId });
                    table.ForeignKey(
                        name: "FK_OfertaFirmy_Firma_FirmaId",
                        column: x => x.FirmaId,
                        principalTable: "Firma",
                        principalColumn: "FirmaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfertaFirmy_Wycieczka_WycieczkaId",
                        column: x => x.WycieczkaId,
                        principalTable: "Wycieczka",
                        principalColumn: "WycieczkaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rezerwacja",
                columns: table => new
                {
                    RezerwacjaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data_zlorzenia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Zaliczka = table.Column<float>(type: "real", nullable: false),
                    Liczba_uczestnikow = table.Column<int>(type: "int", nullable: false),
                    Dane_osobowe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WycieczkaId = table.Column<int>(type: "int", nullable: false),
                    WybranePokojeId = table.Column<int>(type: "int", nullable: false),
                    WybraneWyzywieniaId = table.Column<int>(type: "int", nullable: false),
                    OferowaneMiejscaStartuId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezerwacja", x => x.RezerwacjaId);
                    table.ForeignKey(
                        name: "FK_Rezerwacja_OferowaneMiejscaStartu_OferowaneMiejscaStartuId",
                        column: x => x.OferowaneMiejscaStartuId,
                        principalTable: "OferowaneMiejscaStartu",
                        principalColumn: "OferowaneMiejscaStartuId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rezerwacja_WybranePokoje_WybranePokojeId",
                        column: x => x.WybranePokojeId,
                        principalTable: "WybranePokoje",
                        principalColumn: "WybranePokojeId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Rezerwacja_WybraneWyzywienia_WybraneWyzywieniaId",
                        column: x => x.WybraneWyzywieniaId,
                        principalTable: "WybraneWyzywienia",
                        principalColumn: "WybraneWyzywieniaId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Rezerwacja_Wycieczka_WycieczkaId",
                        column: x => x.WycieczkaId,
                        principalTable: "Wycieczka",
                        principalColumn: "WycieczkaId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OferowaneMiejscaStartu_MiejscaStartuId",
                table: "OferowaneMiejscaStartu",
                column: "MiejscaStartuId");

            migrationBuilder.CreateIndex(
                name: "IX_OferowaneMiejscaStartu_WycieczkaId",
                table: "OferowaneMiejscaStartu",
                column: "WycieczkaId");

            migrationBuilder.CreateIndex(
                name: "IX_OferowanePokoje_RodzajePokoiId",
                table: "OferowanePokoje",
                column: "RodzajePokoiId");

            migrationBuilder.CreateIndex(
                name: "IX_OferowaneWyzywienia_OsrodkiId",
                table: "OferowaneWyzywienia",
                column: "OsrodkiId");

            migrationBuilder.CreateIndex(
                name: "IX_OfertaFirmy_WycieczkaId",
                table: "OfertaFirmy",
                column: "WycieczkaId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezerwacja_OferowaneMiejscaStartuId",
                table: "Rezerwacja",
                column: "OferowaneMiejscaStartuId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezerwacja_WybranePokojeId",
                table: "Rezerwacja",
                column: "WybranePokojeId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezerwacja_WybraneWyzywieniaId",
                table: "Rezerwacja",
                column: "WybraneWyzywieniaId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezerwacja_WycieczkaId",
                table: "Rezerwacja",
                column: "WycieczkaId");

            migrationBuilder.CreateIndex(
                name: "IX_WybranePokoje_OsrodkiId",
                table: "WybranePokoje",
                column: "OsrodkiId");

            migrationBuilder.CreateIndex(
                name: "IX_WybranePokoje_RodzajePokoiId",
                table: "WybranePokoje",
                column: "RodzajePokoiId");

            migrationBuilder.CreateIndex(
                name: "IX_WybraneWyzywienia_OpcjeWyzywieniaId",
                table: "WybraneWyzywienia",
                column: "OpcjeWyzywieniaId");

            migrationBuilder.CreateIndex(
                name: "IX_WybraneWyzywienia_OsrodkiId",
                table: "WybraneWyzywienia",
                column: "OsrodkiId");

            migrationBuilder.CreateIndex(
                name: "IX_Wycieczka_OsrodkiId",
                table: "Wycieczka",
                column: "OsrodkiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OferowanePokoje");

            migrationBuilder.DropTable(
                name: "OferowaneWyzywienia");

            migrationBuilder.DropTable(
                name: "OfertaFirmy");

            migrationBuilder.DropTable(
                name: "Rezerwacja");

            migrationBuilder.DropTable(
                name: "Firma");

            migrationBuilder.DropTable(
                name: "OferowaneMiejscaStartu");

            migrationBuilder.DropTable(
                name: "WybranePokoje");

            migrationBuilder.DropTable(
                name: "WybraneWyzywienia");

            migrationBuilder.DropTable(
                name: "MiejscaStartu");

            migrationBuilder.DropTable(
                name: "Wycieczka");

            migrationBuilder.DropTable(
                name: "RodzajePokoi");

            migrationBuilder.DropTable(
                name: "OpcjeWyzywienia");

            migrationBuilder.DropTable(
                name: "Osrodki");
        }
    }
}
