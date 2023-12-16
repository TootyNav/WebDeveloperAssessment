using System.ComponentModel.DataAnnotations;

namespace WebDeveloperAssessment.Utilities.Enums
{
    public enum YearOfStudyEnum
    {
        [Display(Name = "1st")]
        FirstYear,

        [Display(Name = "2nd")]
        SecondYear,

        [Display(Name = "3rd")]
        ThirdYear,
        
        [Display(Name = "4th")]
        FourthYear
    }
}
