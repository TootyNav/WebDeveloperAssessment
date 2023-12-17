using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using WebDeveloperAssessment.Data;
using WebDeveloperAssessment.Models;

namespace WebDeveloperAssessment.Services
{
    public class StudentService : IStudentService
    {
        private readonly WebDeveloperAssessmentContext _context;

        public StudentService(WebDeveloperAssessmentContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> GetStudents()
        {
            return await _context.Student.ToListAsync();
        }

        public async Task<bool> StudentExists(int id)
        {
            return await _context.Student.AnyAsync(x => x.Id == id);
        }

        public async Task<Student?> GetStudentById(int id)
        {
            return await _context.Student.Include(x => x.StudentSubjects).ThenInclude(x => x.Subject).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task CreateStudent(Student student)
        {
            _context.Add(student);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStudent(Student student)
        {
            _context.Update(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStudent(Student student)
        {
            _context.Student.Remove(student);
            await _context.SaveChangesAsync();
        }
    }
}
