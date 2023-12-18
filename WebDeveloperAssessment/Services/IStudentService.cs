using WebDeveloperAssessment.Models;

namespace WebDeveloperAssessment.Services
{
    public interface IStudentService
    {
        Task CreateStudent(Student student);
        Task<Student> CreateStudentReturnStudent(Student student);
        Task DeleteStudent(Student student);
        Task<Student?> GetStudentById(int id);
        Task<Student?> GetStudentByIdLazyLoad(int id);
        Task<List<Student>> GetStudents();
        Task<List<Student>> GetStudentsLazyLoad();
        Task<bool> StudentExists(int id);
        Task UpdateStudent(Student student);
        Task UpdateStudentApi(Student student);
    }
}