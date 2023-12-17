using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebDeveloperAssessment.Migrations
{
    /// <inheritdoc />
    public partial class SeedSubjectTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                BULK INSERT dbo.Subject
                FROM 'C:\Users\navid\Downloads\Confidential-WebDeveloperAssessment\Subjects.csv'
                WITH
                (
                        FORMAT='CSV',
                        FIRSTROW=2
                )
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
