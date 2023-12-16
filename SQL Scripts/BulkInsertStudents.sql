BULK INSERT dbo.Student
FROM 'C:\Users\navid\Downloads\Confidential-WebDeveloperAssessment\Students.csv'
WITH
(
        FORMAT='CSV',
        FIRSTROW=2
)
GO