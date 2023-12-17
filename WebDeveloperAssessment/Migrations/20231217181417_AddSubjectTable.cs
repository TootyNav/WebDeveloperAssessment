using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebDeveloperAssessment.Migrations
{
    /// <inheritdoc />
    public partial class AddSubjectTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.Id);
                });

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
            migrationBuilder.DropTable(
                name: "Subject");
        }
    }
}
