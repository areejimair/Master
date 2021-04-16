using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorWho.API.Migrations
{
    public partial class final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblEpisodes_TblAuthors_AuthorId",
                table: "TblEpisodes");

            migrationBuilder.DropForeignKey(
                name: "FK_TblEpisodes_TblDoctors_DoctorId",
                table: "TblEpisodes");

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "TblEpisodes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "TblEpisodes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TblEpisodes_TblAuthors_AuthorId",
                table: "TblEpisodes",
                column: "AuthorId",
                principalTable: "TblAuthors",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblEpisodes_TblDoctors_DoctorId",
                table: "TblEpisodes",
                column: "DoctorId",
                principalTable: "TblDoctors",
                principalColumn: "DoctorId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblEpisodes_TblAuthors_AuthorId",
                table: "TblEpisodes");

            migrationBuilder.DropForeignKey(
                name: "FK_TblEpisodes_TblDoctors_DoctorId",
                table: "TblEpisodes");

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "TblEpisodes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "TblEpisodes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_TblEpisodes_TblAuthors_AuthorId",
                table: "TblEpisodes",
                column: "AuthorId",
                principalTable: "TblAuthors",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblEpisodes_TblDoctors_DoctorId",
                table: "TblEpisodes",
                column: "DoctorId",
                principalTable: "TblDoctors",
                principalColumn: "DoctorId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
