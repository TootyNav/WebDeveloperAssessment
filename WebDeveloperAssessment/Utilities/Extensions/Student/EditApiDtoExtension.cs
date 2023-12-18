using WebDeveloperAssessment.ModelViews.DTOs.Student;
using WebDeveloperAssessment.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace WebDeveloperAssessment.Utilities.Extensions;

    public static class EditApiDtoExtension
{
    //public static EditApiDto GetStudentEditApiDto(this Models.Student student, int selectedYearOfStudy, IEnumerable<YearOfStudy> yearOfStudyList)
    //{
    //    return new EditApiDto()
    //    {
    //        Id = student.Id,
    //        FirstName = student.FirstName,
    //        LastName = student.LastName,
    //        Dob = student.Dob,
    //        SelectedYearOfStudy = selectedYearOfStudy,
    //        YearOfStudy = new SelectList(yearOfStudyList, "Id", "Year")
    //    };
    //}

    public static Models.Student GetStudentEntity(this EditApiDto student, IEnumerable<YearOfStudy> yearOfStudyList)
    {
        return new Models.Student()
        {
            Id = student.Id,
            FirstName = student.FirstName,
            LastName = student.LastName,
            Dob = student.Dob,
            YearOfStudy = yearOfStudyList.Single(x => x.Id == student.YearOfStudy).Year,
        };
    }
}

