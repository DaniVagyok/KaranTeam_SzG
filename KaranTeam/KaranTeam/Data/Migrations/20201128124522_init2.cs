using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KaranTeam.Data.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FajlKommentek");

            migrationBuilder.DropTable(
                name: "Fajlok");

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CAFFUri = table.Column<string>(nullable: true),
                    ThumbnailUri = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    OwnerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Files_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FileComments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileComments_Files_FileId",
                        column: x => x.FileId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FileComments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FileComments_FileId",
                table: "FileComments",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_FileComments_UserId",
                table: "FileComments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_OwnerId",
                table: "Files",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileComments");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.CreateTable(
                name: "Fajlok",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CAFFUri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Leiras = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LetrehozoId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ThumbnailUri = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FajlId = table.Column<int>(type: "int", nullable: false),
                    FelhasznaloId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Komment = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
    }
}
