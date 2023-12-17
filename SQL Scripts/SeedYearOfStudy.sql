USE [WebDeveloperAssessment]
GO

SET IDENTITY_INSERT YearOfStudy ON;

INSERT INTO [dbo].[YearOfStudy]
           ([Id], [Year])
     VALUES
           (1, '1st'),
		   (2, '2nd'),
		   (3, '3rd'),
		   (4, '4th')

SET IDENTITY_INSERT YearOfStudy OFF;

GO