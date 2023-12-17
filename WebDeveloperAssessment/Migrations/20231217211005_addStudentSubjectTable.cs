using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebDeveloperAssessment.Migrations
{
    /// <inheritdoc />
    public partial class addStudentSubjectTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Subject_SubjectId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_SubjectId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Student");

            migrationBuilder.CreateTable(
                name: "StudentSubject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSubject", x => x.Id);
                });


            migrationBuilder.Sql(@"
                INSERT INTO [dbo].[StudentSubject] ([StudentId], [SubjectId])
                SELECT s.Id, 1
                FROM Student s
                WHERE s.Id BETWEEN 1 AND 5;
                INSERT INTO [dbo].[StudentSubject] ([StudentId], [SubjectId])
                SELECT s.Id, 4
                FROM Student s
                WHERE s.Id BETWEEN 1 AND 5;
                INSERT INTO [dbo].[StudentSubject] ([StudentId], [SubjectId])
                SELECT s.Id, 2
                FROM Student s
                WHERE s.Id BETWEEN 6 AND 10;
                INSERT INTO [dbo].[StudentSubject] ([StudentId], [SubjectId])
                SELECT s.Id, 4
                FROM Student s
                WHERE s.Id BETWEEN 11 AND 15;
                INSERT INTO [dbo].[StudentSubject] ([StudentId], [SubjectId])
                SELECT s.Id, 5
                FROM Student s
                WHERE s.Id BETWEEN 15 AND 20;
                INSERT INTO [dbo].[StudentSubject] ([StudentId], [SubjectId])
                SELECT s.Id, 3
                FROM Student s
                WHERE s.Id BETWEEN 15 AND 20;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentSubject");

            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "Student",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Student_SubjectId",
                table: "Student",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Subject_SubjectId",
                table: "Student",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "Id");
        }
    }
}
