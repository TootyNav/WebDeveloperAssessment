using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebDeveloperAssessment.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dob = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                });

            migrationBuilder.Sql(@"
                USE [WebDeveloperAssessment]
                GO
                SET IDENTITY_INSERT [dbo].[Student] ON 
                GO
                INSERT [dbo].[Student] ([Id], [FirstName], [LastName], [Dob] ) VALUES (1, N'Riobard', N'Rumney', CAST(N'1990-06-14' AS Date) )
                GO
                INSERT [dbo].[Student] ([Id], [FirstName], [LastName], [Dob] ) VALUES (2, N'Anton', N'Summerton', CAST(N'1998-07-26' AS Date) )
                GO
                INSERT [dbo].[Student] ([Id], [FirstName], [LastName], [Dob] ) VALUES (3, N'Lilah', N'Dorricott', CAST(N'1999-04-11' AS Date) )
                GO
                INSERT [dbo].[Student] ([Id], [FirstName], [LastName], [Dob] ) VALUES (4, N'Ransom', N'Burling', CAST(N'1992-06-05' AS Date) )
                GO
                INSERT [dbo].[Student] ([Id], [FirstName], [LastName], [Dob] ) VALUES (5, N'Veronica', N'Walley', CAST(N'1992-04-05' AS Date) )
                GO
                INSERT [dbo].[Student] ([Id], [FirstName], [LastName], [Dob] ) VALUES (6, N'Arden', N'Schankel', CAST(N'1991-01-01' AS Date) )
                GO
                INSERT [dbo].[Student] ([Id], [FirstName], [LastName], [Dob] ) VALUES (7, N'Richy', N'Blacklock', CAST(N'1992-12-17' AS Date) )
                GO
                INSERT [dbo].[Student] ([Id], [FirstName], [LastName], [Dob] ) VALUES (8, N'Karlik', N'Tofano', CAST(N'1992-08-15' AS Date) )
                GO
                INSERT [dbo].[Student] ([Id], [FirstName], [LastName], [Dob] ) VALUES (9, N'Timoteo', N'Broomhead', CAST(N'1996-11-28' AS Date) )
                GO
                INSERT [dbo].[Student] ([Id], [FirstName], [LastName], [Dob] ) VALUES (10, N'Morley', N'Ceeley', CAST(N'1998-03-30' AS Date) )
                GO
                INSERT [dbo].[Student] ([Id], [FirstName], [LastName], [Dob] ) VALUES (11, N'Olivier', N'Saltern', CAST(N'1998-02-28' AS Date) )
                GO
                INSERT [dbo].[Student] ([Id], [FirstName], [LastName], [Dob] ) VALUES (12, N'Gilbertine', N'Galer', CAST(N'1993-06-19' AS Date) )
                GO
                INSERT [dbo].[Student] ([Id], [FirstName], [LastName], [Dob] ) VALUES (13, N'Belle', N'Gamet', CAST(N'1998-01-16' AS Date) )
                GO
                INSERT [dbo].[Student] ([Id], [FirstName], [LastName], [Dob] ) VALUES (14, N'Nial', N'Oventon', CAST(N'1996-05-30' AS Date) )
                GO
                INSERT [dbo].[Student] ([Id], [FirstName], [LastName], [Dob] ) VALUES (15, N'Jasmin', N'Cussins', CAST(N'1997-03-15' AS Date) )
                GO
                INSERT [dbo].[Student] ([Id], [FirstName], [LastName], [Dob] ) VALUES (16, N'Trev', N'Carvill', CAST(N'1990-07-02' AS Date) )
                GO
                INSERT [dbo].[Student] ([Id], [FirstName], [LastName], [Dob] ) VALUES (17, N'Nikaniki', N'De Andreis', CAST(N'1994-04-27' AS Date) )
                GO
                INSERT [dbo].[Student] ([Id], [FirstName], [LastName], [Dob] ) VALUES (18, N'Lannie', N'L''argent', CAST(N'1994-05-22' AS Date) )
                GO
                INSERT [dbo].[Student] ([Id], [FirstName], [LastName], [Dob] ) VALUES (19, N'Braden', N'Joseff', CAST(N'1992-03-16' AS Date) )
                GO
                INSERT [dbo].[Student] ([Id], [FirstName], [LastName], [Dob] ) VALUES (20, N'Gertruda', N'Hawtin', CAST(N'1992-01-05' AS Date) )
                GO
                SET IDENTITY_INSERT [dbo].[Student] OFF

            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student");
        }
    }
}
