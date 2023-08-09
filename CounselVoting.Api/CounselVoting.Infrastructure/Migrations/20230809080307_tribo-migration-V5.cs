using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CounselVoting.Infrastructure.Migrations
{
    public partial class tribomigrationV5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "MeasureId",
                table: "MeasureRule",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "MeasureModel",
                columns: table => new
                {
                    MeasureId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Subject = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasureModel", x => x.MeasureId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MeasureRule_MeasureId",
                table: "MeasureRule",
                column: "MeasureId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MeasureRule_MeasureModel_MeasureId",
                table: "MeasureRule",
                column: "MeasureId",
                principalTable: "MeasureModel",
                principalColumn: "MeasureId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeasureRule_MeasureModel_MeasureId",
                table: "MeasureRule");

            migrationBuilder.DropTable(
                name: "MeasureModel");

            migrationBuilder.DropIndex(
                name: "IX_MeasureRule_MeasureId",
                table: "MeasureRule");

            migrationBuilder.DropColumn(
                name: "MeasureId",
                table: "MeasureRule");
        }
    }
}
