using Microsoft.EntityFrameworkCore.Migrations;

namespace Pokedex.Migrations
{
    public partial class DBMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Type",
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
                        principalTable: "Type",
                        principalColumn: "typeName",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pokemon_Typ_type2typName",
                        column: x => x.type2typName,
                        principalTable: "Type",
                        principalColumn: "typeName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Type",
                column: "typeName",
                value: "Normal");

            migrationBuilder.InsertData(
                table: "Type",
                column: "typeName",
                value: "Dark");

            migrationBuilder.InsertData(
                table: "Type",
                column: "typeName",
                value: "Dragon");

            migrationBuilder.InsertData(
                table: "Type",
                column: "typeName",
                value: "Ghost");

            migrationBuilder.InsertData(
                table: "Type",
                column: "typeName",
                value: "Rock");

            migrationBuilder.InsertData(
                table: "Type",
                column: "typeName",
                value: "Bug");

            migrationBuilder.InsertData(
                table: "Type",
                column: "typeName",
                value: "Psychic");

            migrationBuilder.InsertData(
                table: "Type",
                column: "typeName",
                value: "Flying");

            migrationBuilder.InsertData(
                table: "Type",
                column: "typeName",
                value: "Ground");

            migrationBuilder.InsertData(
                table: "Type",
                column: "typeName",
                value: "Poison");

            migrationBuilder.InsertData(
                table: "Type",
                column: "typeName",
                value: "Fighting");

            migrationBuilder.InsertData(
                table: "Type",
                column: "typeName",
                value: "Ice");

            migrationBuilder.InsertData(
                table: "Type",
                column: "typeName",
                value: "Electric");

            migrationBuilder.InsertData(
                table: "Type",
                column: "typeName",
                value: "Grass");

            migrationBuilder.InsertData(
                table: "Type",
                column: "typeName",
                value: "Water");

            migrationBuilder.InsertData(
                table: "Type",
                column: "typeName",
                value: "Fire");

            migrationBuilder.InsertData(
                table: "Type",
                column: "typeName",
                value: "Steel");

            migrationBuilder.InsertData(
                table: "Type",
                column: "typeName",
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
                name: "Type");
        }
    }
}
