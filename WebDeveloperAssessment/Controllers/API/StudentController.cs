
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebDeveloperAssessment.ModelViews.DTOs.Student;
using WebDeveloperAssessment.Services;
using WebDeveloperAssessment.Utilities.Extensions;

namespace WebDeveloperAssessment.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IYearOfStudyService _yearOfStudyService;

        public StudentController(IStudentService studentService, IYearOfStudyService yearOfStudyService)
        {
            _studentService = studentService;
            _yearOfStudyService = yearOfStudyService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetailDto>>> GetStudent()
        {
            var student = await _studentService.GetStudentsLazyLoad();

            return Ok(student.Select(x => x.GetDetailDto()));
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<DetailDto>> GetStudent(int id)
        {
            var student = await _studentService.GetStudentByIdLazyLoad(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student.GetDetailDto());
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, EditApiDto student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            try
            {
                var yearOfStudyList = await _yearOfStudyService.GetYearOfStudy();

                await _studentService.UpdateStudentApi(student.GetStudentEntity(yearOfStudyList));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _studentService.StudentExists(student.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult<DetailDto>> PostStudent(CreateApiDto createApiDto)
        {
            var yearOfStudyList = await _yearOfStudyService.GetYearOfStudy();
            var CreatedStudent = await _studentService.CreateStudentReturnStudent(createApiDto.GetStudentEntity(yearOfStudyList));
            var student = await _studentService.GetStudentByIdLazyLoad(CreatedStudent.Id);

            return CreatedAtAction("GetStudent", new { id = student.Id }, student.GetDetailDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _studentService.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }

            await _studentService.DeleteStudent(student);

            return Ok();
        }
    }
}
