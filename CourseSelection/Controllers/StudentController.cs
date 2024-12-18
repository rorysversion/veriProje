using Microsoft.AspNetCore.Mvc;
using CourseSelection.Models;

namespace CourseSelection.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Öğrenci listesi
        public IActionResult Index(int id)
        {
            var students = _context.Students.Where(p=> p.StudentID==id).ToList();
            return View(students);
        }

        // Yeni öğrenci ekleme formu
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // Öğrenci detayları
        public IActionResult Details(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // Kurs seçimi formunu gösteren GET aksiyonu
        public IActionResult SelectCourse(int studentId)
        {
            var student = _context.Courses?.ToList() ?? new List<Course>();
            //if (student == null)
            //{
            //    return NotFound();
            //}

            // Tüm kursları listele
            //var student = _context.Courses?.ToList() ?? new List<Course>();

            return View(student);
        }

        // Kurs seçimini kaydeden POST aksiyonu
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SelectCourseConfirmed(int studentId, int courseId)
        {
            var student = _context.Students.Find(studentId);
            var course = _context.Courses.Find(courseId);

            if (student == null || course == null)
            {
                return NotFound();
            }

            // Öğrenciye kurs ekle
            student.StudentCourseSelections = _context.StudentCourseSelections.ToList();
            _context.SaveChanges();

            return RedirectToAction(nameof(Details), new { id = studentId });
        }


        // Öğrenci silme
        public IActionResult Delete(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = _context.Students.Find(id);
            _context.Students.Remove(student);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

