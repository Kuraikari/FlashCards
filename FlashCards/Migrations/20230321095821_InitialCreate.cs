using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlashCards.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FlashCardSides",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Content = table.Column<string>(type: "TEXT", nullable: false),
                    BackgroundColor = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlashCardSides", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FlashCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Topics = table.Column<int>(type: "INTEGER", nullable: false),
                    SubTopics = table.Column<string>(type: "TEXT", nullable: false),
                    FrontId = table.Column<int>(type: "INTEGER", nullable: false),
                    BackId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlashCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlashCards_FlashCardSides_BackId",
                        column: x => x.BackId,
                        principalTable: "FlashCardSides",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlashCards_FlashCardSides_FrontId",
                        column: x => x.FrontId,
                        principalTable: "FlashCardSides",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlashCards_BackId",
                table: "FlashCards",
                column: "BackId");

            migrationBuilder.CreateIndex(
                name: "IX_FlashCards_FrontId",
                table: "FlashCards",
                column: "FrontId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlashCards");

            migrationBuilder.DropTable(
                name: "FlashCardSides");
        }
    }
}
