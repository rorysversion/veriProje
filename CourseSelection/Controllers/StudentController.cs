using Microsoft.AspNetCore.Mvc;
using CourseSelection.Models;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace CourseSelection.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int id)
        {
            var students = _context.Students.Where(p => p.StudentID == id).ToList();
            return View(students);
        }

        public IActionResult Details(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        public IActionResult CourseSelection(int id)
        {
            var courses = _context.Courses.ToList();
            ViewBag.StudentID = id;
            return View(courses); 
        }

        [HttpPost]
        public async Task<IActionResult> CourseSelection(int studentId, List<int> selectedCourses)
        {
            foreach (var courseId in selectedCourses)
            {
                var existingSelection = _context.StudentCourseSelections
                    .FirstOrDefault(s => s.StudentID == studentId && s.CourseID == courseId);

                if (existingSelection == null) 
                {
                    var selection = new StudentCourseSelection
                    {
                        StudentID = studentId,
                        CourseID = courseId,
                        SelectionDate = DateTime.Now,
                        IsApproved = false
                    };

                    _context.StudentCourseSelections.Add(selection);
                }
            }

            await _context.SaveChangesAsync();//studentID hatası
            return RedirectToAction("Details", new { id = studentId });
        }
        
        public IActionResult SelectCourse(int studentId)
        {

            var student = _context.Courses?.ToList() ?? new List<Course>();

            return View(student);
        }
        
    }
}

