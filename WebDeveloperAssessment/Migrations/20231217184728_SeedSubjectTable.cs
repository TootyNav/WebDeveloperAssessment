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
                USE [WebDeveloperAssessment]

                GO
                SET IDENTITY_INSERT [dbo].[Subject] ON 
                GO
                INSERT [dbo].[Subject] ([Id], [Name]) VALUES (1, N'Biology')
                GO
                INSERT [dbo].[Subject] ([Id], [Name]) VALUES (2, N'Chemistry')
                GO
                INSERT [dbo].[Subject] ([Id], [Name]) VALUES (3, N'Geography')
                GO
                INSERT [dbo].[Subject] ([Id], [Name]) VALUES (4, N'History')
                GO
                INSERT [dbo].[Subject] ([Id], [Name]) VALUES (5, N'Physics')
                GO
                SET IDENTITY_INSERT [dbo].[Subject] OFF
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
