
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebDeveloperAssessment.Data;
using WebDeveloperAssessment.Models;
using WebDeveloperAssessment.ModelViews.DTOs.Student;
using WebDeveloperAssessment.Services;
using WebDeveloperAssessment.Utilities.Extensions;

namespace WebDeveloperAssessment.Controllers
{
    public class StudentController : Controller
    {
        private readonly WebDeveloperAssessmentContext _context;
        private readonly IStudentService _studentService;

        public StudentController(WebDeveloperAssessmentContext context, IStudentService studentService)
        {
            _context = context;
            _studentService = studentService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _studentService.GetStudents());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _studentService.GetStudentById(id.Value);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        public async Task<IActionResult> Create()
        {
            var yearOfStudyList = await _context.YearOfStudy.ToListAsync();


            ViewBag.YearOfStudy = new SelectList(yearOfStudyList, "Id", "Year");

            var model = new CreateViewDto()
            {
                SelectedYearOfStudy = 1,
                YearOfStudy = new SelectList(yearOfStudyList, "Id", "Year")
            };



            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateDto student)
        {
            var yearOfStudyList = await _context.YearOfStudy.ToListAsync();

            if (ModelState.IsValid)
            {
                await _studentService.CreateStudent(student.GetStudentEntity(yearOfStudyList));

                return RedirectToAction(nameof(Index));
            }
            student.YearOfStudy = new SelectList(yearOfStudyList, "Id", "Year");
            return View(student);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _studentService.GetStudentById(id.Value);
            if (student == null)
            {
                return NotFound();
            }

            var yearOfStudyList = await _context.YearOfStudy.ToListAsync();

            var selectedYearOfStudy = yearOfStudyList.SingleOrDefault(x => x.Year == student.YearOfStudy)?.Id;
            if (selectedYearOfStudy == null)
            {
                return NotFound();
            }

            var studentDto = student.GetStudentEditDto(selectedYearOfStudy.Value, yearOfStudyList);

            return View(studentDto);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditDto studentDto)
        {
            if (id != studentDto.Id)
            {
                return NotFound();
            }

            var yearOfStudyList = new List<YearOfStudy>();
            if (ModelState.IsValid)
            {
                yearOfStudyList = await _context.YearOfStudy.ToListAsync();

                try
                {
                    await _studentService.UpdateStudent(studentDto.GetStudentEntity(yearOfStudyList));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _studentService.StudentExists(studentDto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            studentDto.YearOfStudy = new SelectList(yearOfStudyList, "Id", "Year");

            return View(studentDto);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _studentService.GetStudentById(id.Value);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _studentService.GetStudentById(id);
            if (student != null)
            {
                await _studentService.DeleteStudent(student);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
