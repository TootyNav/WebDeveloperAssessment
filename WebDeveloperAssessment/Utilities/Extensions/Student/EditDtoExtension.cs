using WebDeveloperAssessment.ModelViews.DTOs.Student;
using WebDeveloperAssessment.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace WebDeveloperAssessment.Utilities.Extensions;

    public static class EditDtoExtension
{
    public static EditDto GetStudentEditDto(this Models.Student student, int selectedYearOfStudy, IEnumerable<YearOfStudy> yearOfStudyList, IEnumerable<Subject> subjects)
    {
        return new EditDto()
        {
            Id = student.Id,
            FirstName = student.FirstName,
            LastName = student.LastName,
            Dob = student.Dob,
            SelectedYearOfStudy = selectedYearOfStudy,
            YearOfStudy = new SelectList(yearOfStudyList, "Id", "Year"),
            SelectedSubject = student.StudentSubjects.FirstOrDefault().SubjectId,
            Subjects = new SelectList(subjects, "Id", "Name")
        };
    }

    public static Models.Student GetStudentEntity(this EditDto student, IEnumerable<YearOfStudy> yearOfStudyList)
    {
        return new Models.Student()
        {
            Id = student.Id,
            FirstName = student.FirstName,
            LastName = student.LastName,
            Dob = student.Dob,
            YearOfStudy = yearOfStudyList.Single(x => x.Id == student.SelectedYearOfStudy).Year,
        };
    }
}

