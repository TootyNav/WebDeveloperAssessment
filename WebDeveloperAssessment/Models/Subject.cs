namespace WebDeveloperAssessment.Models
{
    public class Subject
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public virtual ICollection<StudentSubject> StudentSubjects { get; set; }

    }
}
