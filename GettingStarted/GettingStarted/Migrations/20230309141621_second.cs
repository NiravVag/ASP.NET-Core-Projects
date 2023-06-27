using Microsoft.EntityFrameworkCore.Migrations;

namespace GettingStarted.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourse_Courses_CourseId",
                table: "StudentCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourse_Students_StudentId",
                table: "StudentCourse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentCourse",
                table: "StudentCourse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "tbl_Student");

            migrationBuilder.RenameTable(
                name: "StudentCourse",
                newName: "tbl_StudentCourse");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "tbl_Course");

            migrationBuilder.RenameIndex(
                name: "IX_StudentCourse_StudentId",
                table: "tbl_StudentCourse",
                newName: "IX_tbl_StudentCourse_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentCourse_CourseId",
                table: "tbl_StudentCourse",
                newName: "IX_tbl_StudentCourse_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_Student",
                table: "tbl_Student",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_StudentCourse",
                table: "tbl_StudentCourse",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_Course",
                table: "tbl_Course",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_StudentCourse_tbl_Course_CourseId",
                table: "tbl_StudentCourse",
                column: "CourseId",
                principalTable: "tbl_Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_StudentCourse_tbl_Student_StudentId",
                table: "tbl_StudentCourse",
                column: "StudentId",
                principalTable: "tbl_Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_StudentCourse_tbl_Course_CourseId",
                table: "tbl_StudentCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_StudentCourse_tbl_Student_StudentId",
                table: "tbl_StudentCourse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_StudentCourse",
                table: "tbl_StudentCourse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_Student",
                table: "tbl_Student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_Course",
                table: "tbl_Course");

            migrationBuilder.RenameTable(
                name: "tbl_StudentCourse",
                newName: "StudentCourse");

            migrationBuilder.RenameTable(
                name: "tbl_Student",
                newName: "Students");

            migrationBuilder.RenameTable(
                name: "tbl_Course",
                newName: "Courses");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_StudentCourse_StudentId",
                table: "StudentCourse",
                newName: "IX_StudentCourse_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_StudentCourse_CourseId",
                table: "StudentCourse",
                newName: "IX_StudentCourse_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentCourse",
                table: "StudentCourse",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourse_Courses_CourseId",
                table: "StudentCourse",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourse_Students_StudentId",
                table: "StudentCourse",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
