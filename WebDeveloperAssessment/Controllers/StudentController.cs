
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebDeveloperAssessment.ModelViews.DTOs.Student;
using WebDeveloperAssessment.Services;
using WebDeveloperAssessment.Utilities.Extensions;

namespace WebDeveloperAssessment.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IYearOfStudyService _yearOfStudyService;
        private readonly ISubjectService _SubjectService;

        public StudentController(IStudentService studentService, IYearOfStudyService yearOfStudyService, ISubjectService subjectService)
        {
            _studentService = studentService;
            _yearOfStudyService = yearOfStudyService;
            _SubjectService = subjectService;
        }

        public async Task<IActionResult> Index()
        {
            var students = await _studentService.GetStudentsLazyLoad();
            return View(students.Select(x => x.GetDetailDto()));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _studentService.GetStudentByIdLazyLoad(id.Value);
            if (student == null)
            {
                return NotFound();
            }

           return View(student.GetDetailDto());
        }

        public async Task<IActionResult> Create()
        {
            var yearOfStudyList = await _yearOfStudyService.GetYearOfStudy();
            var subjects = await _SubjectService.GetSubjects();

            var model = new CreateViewDto()
            {
                SelectedYearOfStudy = 1,
                YearOfStudy = new SelectList(yearOfStudyList, "Id", "Year"),
                SelectedSubject = 1,
                Subjects = new SelectList(subjects, "Id", "Name")
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateDto student)
        {
            var yearOfStudyList = await _yearOfStudyService.GetYearOfStudy();
            var subjects = await _SubjectService.GetSubjects();

            if (ModelState.IsValid)
            {
                await _studentService.CreateStudent(student.GetStudentEntity(yearOfStudyList));

                return RedirectToAction(nameof(Index));
            }
            student.YearOfStudy = new SelectList(yearOfStudyList, "Id", "Year");
            student.Subjects = new SelectList(subjects, "Id", "Year");
            return View(student);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _studentService.GetStudentByIdLazyLoad(id.Value);
            if (student == null)
            {
                return NotFound();
            }

            var yearOfStudyList = await _yearOfStudyService.GetYearOfStudy();
            var subjects = await _SubjectService.GetSubjects();

            var selectedYearOfStudy = yearOfStudyList.SingleOrDefault(x => x.Year == student.YearOfStudy)?.Id;
            if (selectedYearOfStudy == null)
            {
                return NotFound();
            }

            var studentDto = student.GetStudentEditDto(selectedYearOfStudy.Value, yearOfStudyList, subjects);

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

            var yearOfStudyList = await _yearOfStudyService.GetYearOfStudy();
            if (ModelState.IsValid)
            {
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

            var student = await _studentService.GetStudentByIdLazyLoad(id.Value);

            if (student == null)
            {
                return NotFound();
            }

            return View(student.GetDetailDto());
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
