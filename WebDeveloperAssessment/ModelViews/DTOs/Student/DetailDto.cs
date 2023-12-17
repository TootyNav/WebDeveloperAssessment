using System.ComponentModel.DataAnnotations;

namespace WebDeveloperAssessment.ModelViews.DTOs.Student
{
    public class DetailDto
    {
        public required int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public DateOnly Dob { get; set; }

        [Display(Name = "Year of Study")]
        public required string YearOfStudy { get; set; }

        public string Subjects { get; set; }
    }
}
