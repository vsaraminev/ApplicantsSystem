using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicantsSystem.Data.Migrations
{
    public partial class RemoveTableResult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_Results_ResultId",
                table: "Interviews");

            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropIndex(
                name: "IX_Interviews_ResultId",
                table: "Interviews");

            migrationBuilder.DropColumn(
                name: "ResultId",
                table: "Interviews");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ResultId",
                table: "Interviews",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    File = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_ResultId",
                table: "Interviews",
                column: "ResultId");

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_Results_ResultId",
                table: "Interviews",
                column: "ResultId",
                principalTable: "Results",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
