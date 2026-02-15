using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tamkeen.Migrations
{
    /// <inheritdoc />
    public partial class programtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_programEnrollments_TrainingProgram_ProgramId",
                table: "programEnrollments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingProgram",
                table: "TrainingProgram");

            migrationBuilder.RenameTable(
                name: "TrainingProgram",
                newName: "TrainingPrograms");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingPrograms",
                table: "TrainingPrograms",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_programEnrollments_TrainingPrograms_ProgramId",
                table: "programEnrollments",
                column: "ProgramId",
                principalTable: "TrainingPrograms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_programEnrollments_TrainingPrograms_ProgramId",
                table: "programEnrollments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingPrograms",
                table: "TrainingPrograms");

            migrationBuilder.RenameTable(
                name: "TrainingPrograms",
                newName: "TrainingProgram");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingProgram",
                table: "TrainingProgram",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_programEnrollments_TrainingProgram_ProgramId",
                table: "programEnrollments",
                column: "ProgramId",
                principalTable: "TrainingProgram",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
