using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tamkeen.Migrations
{
    /// <inheritdoc />
    public partial class intFromPc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluation_applicationUsers_EvaluatedById",
                table: "Evaluation");

            migrationBuilder.DropForeignKey(
                name: "FK_Evaluation_programEnrollments_EnrollmentId",
                table: "Evaluation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Evaluation",
                table: "Evaluation");

            migrationBuilder.RenameTable(
                name: "Evaluation",
                newName: "Evaluations");

            migrationBuilder.RenameIndex(
                name: "IX_Evaluation_EvaluatedById",
                table: "Evaluations",
                newName: "IX_Evaluations_EvaluatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Evaluation_EnrollmentId",
                table: "Evaluations",
                newName: "IX_Evaluations_EnrollmentId");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Applications",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Evaluations",
                table: "Evaluations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluations_applicationUsers_EvaluatedById",
                table: "Evaluations",
                column: "EvaluatedById",
                principalTable: "applicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluations_programEnrollments_EnrollmentId",
                table: "Evaluations",
                column: "EnrollmentId",
                principalTable: "programEnrollments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluations_applicationUsers_EvaluatedById",
                table: "Evaluations");

            migrationBuilder.DropForeignKey(
                name: "FK_Evaluations_programEnrollments_EnrollmentId",
                table: "Evaluations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Evaluations",
                table: "Evaluations");

            migrationBuilder.RenameTable(
                name: "Evaluations",
                newName: "Evaluation");

            migrationBuilder.RenameIndex(
                name: "IX_Evaluations_EvaluatedById",
                table: "Evaluation",
                newName: "IX_Evaluation_EvaluatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Evaluations_EnrollmentId",
                table: "Evaluation",
                newName: "IX_Evaluation_EnrollmentId");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Applications",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Evaluation",
                table: "Evaluation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluation_applicationUsers_EvaluatedById",
                table: "Evaluation",
                column: "EvaluatedById",
                principalTable: "applicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluation_programEnrollments_EnrollmentId",
                table: "Evaluation",
                column: "EnrollmentId",
                principalTable: "programEnrollments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
