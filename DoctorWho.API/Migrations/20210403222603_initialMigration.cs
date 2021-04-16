using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorWho.API.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblAuthors",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblAuthors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "TblCompanions",
                columns: table => new
                {
                    CompanionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WhoPlayed = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCompanions", x => x.CompanionId);
                });

            migrationBuilder.CreateTable(
                name: "TblDoctors",
                columns: table => new
                {
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorNumber = table.Column<int>(type: "int", nullable: true),
                    DoctorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FirstEpisodeDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastEpisodeDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblDoctors", x => x.DoctorId);
                });

            migrationBuilder.CreateTable(
                name: "TblEnemies",
                columns: table => new
                {
                    EnemyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnemyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblEnemies", x => x.EnemyId);
                });

            migrationBuilder.CreateTable(
                name: "TblEpisodes",
                columns: table => new
                {
                    EpisodeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeriesNumber = table.Column<int>(type: "int", nullable: true),
                    EpisodeNumber = table.Column<int>(type: "int", nullable: true),
                    EpisodeType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EpisodeDatedate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AuthorId = table.Column<int>(type: "int", nullable: true),
                    DoctorId = table.Column<int>(type: "int", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblEpisodes", x => x.EpisodeId);
                    table.ForeignKey(
                        name: "FK_TblEpisodes_TblAuthors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "TblAuthors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblEpisodes_TblDoctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "TblDoctors",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblEpisodeCompanions",
                columns: table => new
                {
                    EpisodeCompanionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EpisodeId = table.Column<int>(type: "int", nullable: true),
                    CompanionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblEpisodeCompanions", x => x.EpisodeCompanionId);
                    table.ForeignKey(
                        name: "FK_TblEpisodeCompanions_TblCompanions_CompanionId",
                        column: x => x.CompanionId,
                        principalTable: "TblCompanions",
                        principalColumn: "CompanionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblEpisodeCompanions_TblEpisodes_EpisodeId",
                        column: x => x.EpisodeId,
                        principalTable: "TblEpisodes",
                        principalColumn: "EpisodeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblEpisodeEnemies",
                columns: table => new
                {
                    EpisodeEnemyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EpisodeId = table.Column<int>(type: "int", nullable: true),
                    EnemyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblEpisodeEnemies", x => x.EpisodeEnemyId);
                    table.ForeignKey(
                        name: "FK_TblEpisodeEnemies_TblEnemies_EnemyId",
                        column: x => x.EnemyId,
                        principalTable: "TblEnemies",
                        principalColumn: "EnemyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblEpisodeEnemies_TblEpisodes_EpisodeId",
                        column: x => x.EpisodeId,
                        principalTable: "TblEpisodes",
                        principalColumn: "EpisodeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "TblAuthors",
                columns: new[] { "AuthorId", "AuthorName" },
                values: new object[,]
                {
                    { 1, "Author1" },
                    { 2, "Author2" },
                    { 3, "Author3" },
                    { 4, "Author4" },
                    { 5, "Author5" }
                });

            migrationBuilder.InsertData(
                table: "TblCompanions",
                columns: new[] { "CompanionId", "CompanionName", "WhoPlayed" },
                values: new object[,]
                {
                    { 4, "Name4", "palyer4" },
                    { 3, "Name3", "palyer3" },
                    { 5, "Name5", "palyer5" },
                    { 1, "Name1", "palyer1" },
                    { 2, "Name2", "palyer2" }
                });

            migrationBuilder.InsertData(
                table: "TblDoctors",
                columns: new[] { "DoctorId", "BirthDate", "DoctorName", "DoctorNumber", "FirstEpisodeDate", "LastEpisodeDate" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "doctor1", 1, new DateTime(2000, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2010, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(1990, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "doctor2", 2, new DateTime(2000, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2010, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(1990, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "doctor3", 3, new DateTime(2000, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2010, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(1990, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "doctor4", 4, new DateTime(2000, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2010, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(1990, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "doctor5", 5, new DateTime(2000, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2010, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "TblEnemies",
                columns: new[] { "EnemyId", "Description", "EnemyName" },
                values: new object[,]
                {
                    { 4, "Des4", "Name4" },
                    { 1, "Des1", "Name1" },
                    { 2, "Des2", "Name2" },
                    { 3, "Des3", "Name3" },
                    { 5, "Des5", "Name5" }
                });

            migrationBuilder.InsertData(
                table: "TblEpisodes",
                columns: new[] { "EpisodeId", "AuthorId", "DoctorId", "EpisodeDatedate", "EpisodeNumber", "EpisodeType", "Notes", "SeriesNumber", "Title" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "comedey", "Funny", 2, "Brooklyn99" },
                    { 2, 2, 2, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "comedey", "Funny", 2, "Brooklyn99" },
                    { 3, 3, 3, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "comedey", "Funny", 2, "Brooklyn99" },
                    { 4, 4, 4, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "comedey", "Funny", 2, "Brooklyn99" },
                    { 5, 5, 5, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "comedey", "Funny", 2, "Brooklyn99" }
                });

            migrationBuilder.InsertData(
                table: "TblEpisodeCompanions",
                columns: new[] { "EpisodeCompanionId", "CompanionId", "EpisodeId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 },
                    { 4, 4, 4 },
                    { 5, 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "TblEpisodeEnemies",
                columns: new[] { "EpisodeEnemyId", "EnemyId", "EpisodeId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 },
                    { 4, 4, 4 },
                    { 5, 5, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblEpisodeCompanions_CompanionId",
                table: "TblEpisodeCompanions",
                column: "CompanionId");

            migrationBuilder.CreateIndex(
                name: "IX_TblEpisodeCompanions_EpisodeId",
                table: "TblEpisodeCompanions",
                column: "EpisodeId");

            migrationBuilder.CreateIndex(
                name: "IX_TblEpisodeEnemies_EnemyId",
                table: "TblEpisodeEnemies",
                column: "EnemyId");

            migrationBuilder.CreateIndex(
                name: "IX_TblEpisodeEnemies_EpisodeId",
                table: "TblEpisodeEnemies",
                column: "EpisodeId");

            migrationBuilder.CreateIndex(
                name: "IX_TblEpisodes_AuthorId",
                table: "TblEpisodes",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_TblEpisodes_DoctorId",
                table: "TblEpisodes",
                column: "DoctorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblEpisodeCompanions");

            migrationBuilder.DropTable(
                name: "TblEpisodeEnemies");

            migrationBuilder.DropTable(
                name: "TblCompanions");

            migrationBuilder.DropTable(
                name: "TblEnemies");

            migrationBuilder.DropTable(
                name: "TblEpisodes");

            migrationBuilder.DropTable(
                name: "TblAuthors");

            migrationBuilder.DropTable(
                name: "TblDoctors");
        }
    }
}
