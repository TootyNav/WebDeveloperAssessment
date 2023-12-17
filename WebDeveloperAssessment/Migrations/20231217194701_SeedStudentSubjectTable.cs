using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebDeveloperAssessment.Migrations
{
    /// <inheritdoc />
    public partial class SeedStudentSubjectTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"

                INSERT INTO [dbo].[StudentSubject] ([StudentsId], [SubjectsId])
                SELECT s.Id, 1
                FROM Student s
                WHERE s.Id BETWEEN 1 AND 5;

                INSERT INTO [dbo].[StudentSubject] ([StudentsId], [SubjectsId])
                SELECT s.Id, 4
                FROM Student s
                WHERE s.Id BETWEEN 1 AND 5;

                INSERT INTO [dbo].[StudentSubject] ([StudentsId], [SubjectsId])
                SELECT s.Id, 2
                FROM Student s
                WHERE s.Id BETWEEN 6 AND 10;

                INSERT INTO [dbo].[StudentSubject] ([StudentsId], [SubjectsId])
                SELECT s.Id, 4
                FROM Student s
                WHERE s.Id BETWEEN 11 AND 15;

                INSERT INTO [dbo].[StudentSubject] ([StudentsId], [SubjectsId])
                SELECT s.Id, 5
                FROM Student s
                WHERE s.Id BETWEEN 15 AND 20;

                INSERT INTO [dbo].[StudentSubject] ([StudentsId], [SubjectsId])
                SELECT s.Id, 3
                FROM Student s
                WHERE s.Id BETWEEN 15 AND 20;

            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
