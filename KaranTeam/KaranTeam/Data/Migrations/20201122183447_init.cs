using Microsoft.EntityFrameworkCore.Migrations;

namespace KaranTeam.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Fajlok",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CAFFUri = table.Column<string>(nullable: true),
                    ThumbnailUri = table.Column<string>(nullable: true),
                    Cim = table.Column<string>(nullable: true),
                    Leiras = table.Column<string>(nullable: true),
                    LetrehozoId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fajlok", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fajlok_AspNetUsers_LetrehozoId",
                        column: x => x.LetrehozoId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FajlKommentek",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FajlId = table.Column<int>(nullable: false),
                    FelhasznaloId = table.Column<string>(nullable: true),
                    Komment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FajlKommentek", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FajlKommentek_Fajlok_FajlId",
                        column: x => x.FajlId,
                        principalTable: "Fajlok",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FajlKommentek_AspNetUsers_FelhasznaloId",
                        column: x => x.FelhasznaloId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FajlKommentek_FajlId",
                table: "FajlKommentek",
                column: "FajlId");

            migrationBuilder.CreateIndex(
                name: "IX_FajlKommentek_FelhasznaloId",
                table: "FajlKommentek",
                column: "FelhasznaloId");

            migrationBuilder.CreateIndex(
                name: "IX_Fajlok_LetrehozoId",
                table: "Fajlok",
                column: "LetrehozoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FajlKommentek");

            migrationBuilder.DropTable(
                name: "Fajlok");

            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "AspNetUsers");
        }
    }
}
