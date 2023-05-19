using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DinoProject.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "When",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_When", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dinos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WhenId = table.Column<int>(type: "INTEGER", nullable: true),
                    Photo = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dinos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dinos_When_WhenId",
                        column: x => x.WhenId,
                        principalTable: "When",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dinos_WhenId",
                table: "Dinos",
                column: "WhenId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dinos");

            migrationBuilder.DropTable(
                name: "When");
        }
    }
}
