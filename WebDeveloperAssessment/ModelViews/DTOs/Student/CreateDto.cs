using System.ComponentModel.DataAnnotations;
using WebDeveloperAssessment.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;

namespace WebDeveloperAssessment.ModelViews.DTOs.Student
{
    public class CreateDto
    {
        public required int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public DateOnly Dob { get; set; }

        [Display(Name = "Year of Study")]
        public SelectList? YearOfStudy { get; set; }
        public int SelectedYearOfStudy { get; set; }

        public SelectList? Subjects { get; set; }
        public int SelectedSubject { get; set; }
    }
}
