using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicantsSystem.Data.Migrations
{
    public partial class UniqueEmailApplicantTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Applicants",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_Applicants_Email",
                table: "Applicants",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Applicants_Email",
                table: "Applicants");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Applicants",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
