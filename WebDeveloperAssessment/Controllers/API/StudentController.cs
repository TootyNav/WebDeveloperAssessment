using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using WebDeveloperAssessment.Data;
using WebDeveloperAssessment.Models;
using WebDeveloperAssessment.ModelViews.DTOs.Student;
using WebDeveloperAssessment.Services;
using WebDeveloperAssessment.Utilities.Extensions;

namespace WebDeveloperAssessment.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly WebDeveloperAssessmentContext _context;
        private readonly IStudentService _studentService;

        public StudentController(WebDeveloperAssessmentContext context, IStudentService studentService)
        {
            _context = context;
            _studentService = studentService;
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

            return student.GetDetailDto();
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
                var yearOfStudyList = await _context.YearOfStudy.ToListAsync();

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

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            await _studentService.CreateStudent(student);

            return CreatedAtAction("GetStudent", new { id = student.Id }, student);
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

            return NoContent();
        }
    }
}
