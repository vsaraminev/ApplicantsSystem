using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicantsSystem.Data.Migrations
{
    public partial class AllowNullTestId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_Tests_TestId",
                table: "Interviews");

            migrationBuilder.AlterColumn<int>(
                name: "TestId",
                table: "Interviews",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_Tests_TestId",
                table: "Interviews",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_Tests_TestId",
                table: "Interviews");

            migrationBuilder.AlterColumn<int>(
                name: "TestId",
                table: "Interviews",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_Tests_TestId",
                table: "Interviews",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
