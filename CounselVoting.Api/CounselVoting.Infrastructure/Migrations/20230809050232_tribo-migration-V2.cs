using Microsoft.EntityFrameworkCore.Migrations;

namespace CounselVoting.Infrastructure.Migrations
{
    public partial class tribomigrationV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MeasureRule",
                columns: table => new
                {
                    MeasureRuleId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MinNumberOfVotes = table.Column<int>(type: "INTEGER", nullable: false),
                    MinPercentageOfYes = table.Column<int>(type: "INTEGER", nullable: false),
                    UserMustUploadPicture = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasureRule", x => x.MeasureRuleId);
                });

            migrationBuilder.CreateTable(
                name: "UserNamesMustVoteToPassModel",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    MeasureRuleId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNamesMustVoteToPassModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserNamesMustVoteToPassModel_MeasureRule_MeasureRuleId",
                        column: x => x.MeasureRuleId,
                        principalTable: "MeasureRule",
                        principalColumn: "MeasureRuleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserNamesMustVoteToPassModel_MeasureRuleId",
                table: "UserNamesMustVoteToPassModel",
                column: "MeasureRuleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserNamesMustVoteToPassModel");

            migrationBuilder.DropTable(
                name: "MeasureRule");
        }
    }
}
