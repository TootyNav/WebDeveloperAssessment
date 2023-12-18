﻿using WebDeveloperAssessment.ModelViews.DTOs.Student;
using WebDeveloperAssessment.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace WebDeveloperAssessment.Utilities.Extensions;

public static class CreateDtoExtension
{
    public static Student GetStudentEntity(this CreateDto student, IEnumerable<YearOfStudy> yearOfStudyList)
    {
        return new Student()
        {
            Id = student.Id,
            FirstName = student.FirstName,
            LastName = student.LastName,
            Dob = student.Dob,
            YearOfStudy = yearOfStudyList.Single(x => x.Id == student.SelectedYearOfStudy).Year,
            StudentSubjects = new List<StudentSubject>() { new StudentSubject() { StudentId = student.Id, SubjectId = student.SelectedSubject } }
        };
    }
}

