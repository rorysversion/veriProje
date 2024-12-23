using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CourseSelection.Models;


namespace CourseSelection.Controllers.webcontroller
{
    public class AdvisorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdvisorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int id)
        {
            var advisor = _context.Advisors.FirstOrDefault(a => a.AdvisorID == id);
            if (advisor == null)
            {
                return NotFound();
            }
            return View(advisor);

        }

        public IActionResult Details(int id)
        {
            var advisors = _context.Advisors.ToList();
            
            return View(advisors);
        }

        public IActionResult PersonalInfo(int id)
        {
            var advisors = _context.Advisors.FirstOrDefault(a => a.AdvisorID == id);
            if (advisors == null)
            {
                return NotFound(); // Eğer danışman bulunamazsa 404 döndür
            }
            return View(advisors);
        
        }


        public IActionResult MyStudents(int id)
        {

            var students = _context.Students
                .Where(s => s.AdvisorID == id)
                .ToList();
            if (students == null || students.Count == 0)
            {
                return NotFound();
            }
            return View(students); 

        }

        [HttpGet("ViewStudentCourses/{studentId}")]
        public IActionResult ViewStudentCourses(int studentId)
        {
            
            var student = _context.Students
                .Include(s => s.StudentCourseSelections)
                    .ThenInclude(sc => sc.Course)
                .FirstOrDefault(s => s.StudentID == studentId);

            if (student == null)
            {
                return NotFound(new { Message = "Student not found." });
            }

            return View(student);
        }
        [HttpGet("ApproveCourses")]
        public IActionResult ApproveCourses(int id)
        {
            // Danışman tarafından onaylanacak dersler burada işlenir.
            var advisor = _context.Advisors
                .Include(a => a.Students)
                .FirstOrDefault(a => a.AdvisorID == id);

            if (advisor == null)
            {
                return NotFound(new { Message = "Advisor not found." });
            }
            return View(advisor);
        }
       
    }


}


