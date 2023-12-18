using Microsoft.EntityFrameworkCore;
using WebDeveloperAssessment.Data;
using WebDeveloperAssessment.Models;

namespace WebDeveloperAssessment.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly WebDeveloperAssessmentContext _context;

        public SubjectService (WebDeveloperAssessmentContext context)
        {
            _context = context;
        }

        public async Task<List<Subject>> GetSubjects()
        {
            return await _context.Subject.ToListAsync();
        }
    }
}
