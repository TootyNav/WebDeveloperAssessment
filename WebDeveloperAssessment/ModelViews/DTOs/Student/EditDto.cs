using System.ComponentModel.DataAnnotations;
using WebDeveloperAssessment.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;

namespace WebDeveloperAssessment.ModelViews.DTOs.Student
{
    public class EditDto
    {
        public required int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public DateOnly Dob { get; set; }

        [Display(Name = "Year of Study")]
        public required SelectList YearOfStudy { get; set; }

        public int SelectedYearOfStudy { get; set; }
    }
}
