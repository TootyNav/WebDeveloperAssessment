using System.ComponentModel.DataAnnotations;

namespace WebDeveloperAssessment.Models
{
    public class Student
    {
        public required int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public DateOnly Dob { get; set; }

        [Display(Name = "Year of Study")]
        public required string YearOfStudy { get; set; }
    }
}
