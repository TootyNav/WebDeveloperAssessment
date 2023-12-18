using WebDeveloperAssessment.Models;

namespace WebDeveloperAssessment.Services
{
    public interface ISubjectService
    {
        Task<List<Subject>> GetSubjects();
    }
}