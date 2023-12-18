using WebDeveloperAssessment.Models;

namespace WebDeveloperAssessment.Services
{
    public interface IYearOfStudyService
    {
        Task<List<YearOfStudy>> GetYearOfStudy();
    }
}