using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebDeveloperAssessment.Models
{
    public class StudentSubject
    {
        public int Id { get; set; }
        public int StudentId  { get; set; }

        public int SubjectId  { get; set; }

        public Student Student { get; set; }
        public Subject Subject { get; set; }

    }
}
