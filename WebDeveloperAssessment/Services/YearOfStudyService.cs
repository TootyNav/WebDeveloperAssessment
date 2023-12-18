using Microsoft.EntityFrameworkCore;
using WebDeveloperAssessment.Data;
using WebDeveloperAssessment.Models;

namespace WebDeveloperAssessment.Services
{
    public class YearOfStudyService : IYearOfStudyService
    {
        private readonly WebDeveloperAssessmentContext _context;

        public YearOfStudyService (WebDeveloperAssessmentContext context)
        {
            _context = context;
        }

        public async Task<List<YearOfStudy>> GetYearOfStudy()
        {
            return await _context.YearOfStudy.ToListAsync();
        }
    }
}
