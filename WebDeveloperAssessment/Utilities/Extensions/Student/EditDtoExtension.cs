using WebDeveloperAssessment.ModelViews.DTOs.Student;
using WebDeveloperAssessment.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace WebDeveloperAssessment.Utilities.Extensions;

    public static class EditDtoExtension
{
    public static EditDto GetStudentEditDto(this Student student, int selectedYearOfStudy, IEnumerable<YearOfStudy> yearOfStudyList)
    {
        return new EditDto()
        {
            Id = student.Id,
            FirstName = student.FirstName,
            LastName = student.LastName,
            Dob = student.Dob,
            SelectedYearOfStudy = selectedYearOfStudy,
            YearOfStudy = new SelectList(yearOfStudyList, "Id", "Year")
        };
    }
}

