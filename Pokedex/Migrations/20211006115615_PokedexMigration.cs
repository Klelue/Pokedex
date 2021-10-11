using Microsoft.EntityFrameworkCore.Migrations;

namespace Pokedex.Migrations
{
    public partial class PokedexMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Typ",
                columns: table => new
                {
                    name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Typ", x => x.name);
                });

            migrationBuilder.CreateTable(
                name: "Pokemon",
                columns: table => new
                {
                    nationalDexNumber = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: true),
                    type1name = table.Column<string>(type: "TEXT", nullable: true),
                    type2name = table.Column<string>(type: "TEXT", nullable: true),
                    total = table.Column<int>(type: "INTEGER", nullable: false),
                    healthPoints = table.Column<int>(type: "INTEGER", nullable: false),
                    attack = table.Column<int>(type: "INTEGER", nullable: false),
                    defense = table.Column<int>(type: "INTEGER", nullable: false),
                    spAttack = table.Column<int>(type: "INTEGER", nullable: false),
                    spDefense = table.Column<int>(type: "INTEGER", nullable: false),
                    speed = table.Column<int>(type: "INTEGER", nullable: false),
                    generation = table.Column<int>(type: "INTEGER", nullable: false),
                    legendary = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemon", x => x.nationalDexNumber);
                    table.ForeignKey(
                        name: "FK_Pokemon_Typ_type1name",
                        column: x => x.type1name,
                        principalTable: "Typ",
                        principalColumn: "name",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pokemon_Typ_type2name",
                        column: x => x.type2name,
                        principalTable: "Typ",
                        principalColumn: "name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TypTyp",
                columns: table => new
                {
                    effectivAgainstTypsname = table.Column<string>(type: "TEXT", nullable: false),
                    weakAgainstTypsname = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypTyp", x => new { x.effectivAgainstTypsname, x.weakAgainstTypsname });
                    table.ForeignKey(
                        name: "FK_TypTyp_Typ_effectivAgainstTypsname",
                        column: x => x.effectivAgainstTypsname,
                        principalTable: "Typ",
                        principalColumn: "name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TypTyp_Typ_weakAgainstTypsname",
                        column: x => x.weakAgainstTypsname,
                        principalTable: "Typ",
                        principalColumn: "name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pokemon_type1name",
                table: "Pokemon",
                column: "type1name");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemon_type2name",
                table: "Pokemon",
                column: "type2name");

            migrationBuilder.CreateIndex(
                name: "IX_TypTyp_weakAgainstTypsname",
                table: "TypTyp",
                column: "weakAgainstTypsname");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pokemon");

            migrationBuilder.DropTable(
                name: "TypTyp");

            migrationBuilder.DropTable(
                name: "Typ");
        }
    }
}
