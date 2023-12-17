using WebDeveloperAssessment.ModelViews.DTOs.Student;
using WebDeveloperAssessment.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace WebDeveloperAssessment.Utilities.Extensions;

public static class DetailDtoExtension
{
    public static Student GetStudentEntity(this DetailDto student, IEnumerable<YearOfStudy> yearOfStudyList)
    {
        return new Student()
        {
            Id = student.Id,
            FirstName = student.FirstName,
            LastName = student.LastName,
            Dob = student.Dob,
            YearOfStudy = student.YearOfStudy,
        };
    }

    public static DetailDto GetDetailDto(this Student student)
    {
        return new DetailDto()
        {
            Id = student.Id,
            FirstName = student.FirstName,
            LastName = student.LastName,
            Dob = student.Dob,
            YearOfStudy = student.YearOfStudy,
            Subjects = string.Join(" | ", student.StudentSubjects.Select(x => x.Subject.Name))
        };
    }
}

