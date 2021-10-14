using Microsoft.EntityFrameworkCore.Migrations;

namespace Pokedex.Migrations
{
    public partial class DBMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Typ",
                columns: table => new
                {
                    typName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Typ", x => x.typName);
                });

            migrationBuilder.CreateTable(
                name: "Pokemon",
                columns: table => new
                {
                    nationalDexNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    type1typName = table.Column<string>(type: "TEXT", nullable: true),
                    type2typName = table.Column<string>(type: "TEXT", nullable: true),
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
                    table.PrimaryKey("PK_Pokemon", x => new { x.nationalDexNumber, x.name });
                    table.ForeignKey(
                        name: "FK_Pokemon_Typ_type1typName",
                        column: x => x.type1typName,
                        principalTable: "Typ",
                        principalColumn: "typName",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pokemon_Typ_type2typName",
                        column: x => x.type2typName,
                        principalTable: "Typ",
                        principalColumn: "typName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Typ",
                column: "typName",
                value: "Normal");

            migrationBuilder.InsertData(
                table: "Typ",
                column: "typName",
                value: "Dark");

            migrationBuilder.InsertData(
                table: "Typ",
                column: "typName",
                value: "Dragon");

            migrationBuilder.InsertData(
                table: "Typ",
                column: "typName",
                value: "Ghost");

            migrationBuilder.InsertData(
                table: "Typ",
                column: "typName",
                value: "Rock");

            migrationBuilder.InsertData(
                table: "Typ",
                column: "typName",
                value: "Bug");

            migrationBuilder.InsertData(
                table: "Typ",
                column: "typName",
                value: "Psychic");

            migrationBuilder.InsertData(
                table: "Typ",
                column: "typName",
                value: "Flying");

            migrationBuilder.InsertData(
                table: "Typ",
                column: "typName",
                value: "Ground");

            migrationBuilder.InsertData(
                table: "Typ",
                column: "typName",
                value: "Poison");

            migrationBuilder.InsertData(
                table: "Typ",
                column: "typName",
                value: "Fighting");

            migrationBuilder.InsertData(
                table: "Typ",
                column: "typName",
                value: "Ice");

            migrationBuilder.InsertData(
                table: "Typ",
                column: "typName",
                value: "Electric");

            migrationBuilder.InsertData(
                table: "Typ",
                column: "typName",
                value: "Grass");

            migrationBuilder.InsertData(
                table: "Typ",
                column: "typName",
                value: "Water");

            migrationBuilder.InsertData(
                table: "Typ",
                column: "typName",
                value: "Fire");

            migrationBuilder.InsertData(
                table: "Typ",
                column: "typName",
                value: "Steel");

            migrationBuilder.InsertData(
                table: "Typ",
                column: "typName",
                value: "Fairy");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemon_type1typName",
                table: "Pokemon",
                column: "type1typName");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemon_type2typName",
                table: "Pokemon",
                column: "type2typName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pokemon");

            migrationBuilder.DropTable(
                name: "Typ");
        }
    }
}
