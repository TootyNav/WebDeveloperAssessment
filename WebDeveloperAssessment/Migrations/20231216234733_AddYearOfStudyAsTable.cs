using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebDeveloperAssessment.Migrations
{
    /// <inheritdoc />
    public partial class AddYearOfStudyAsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "YearOfStudy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YearOfStudy", x => x.Id);
                });

            migrationBuilder.Sql(@"
                SET IDENTITY_INSERT YearOfStudy ON;

                INSERT INTO [dbo].[YearOfStudy]
                           ([Id], [Year])
                     VALUES
                           (1, '1st'),
		                   (2, '2nd'),
		                   (3, '3rd'),
		                   (4, '4th')

                SET IDENTITY_INSERT YearOfStudy OFF;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "YearOfStudy");
        }
    }
}
