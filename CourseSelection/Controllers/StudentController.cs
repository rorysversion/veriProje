using Microsoft.AspNetCore.Mvc;
using CourseSelection.Models;
using System.Security.Claims;

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
            var students = _context.Students.Where(p => p.StudentID == id).ToList();
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
        [HttpPost]
        public IActionResult Select_Course(int courseId,int id)
        {
            // Öğrencinin kimliğini alın (kullanıcı oturumundan)
            //var studentId = User.FindFirst(ClaimTypes.NameIdentifier).Value;  // Örnek olarak, kullanıcı ID'si claim'den alınır.
            var studentId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            

            var student = _context.Students.FirstOrDefault(s => s.StudentID == id);
            
            if (student != null)
            {
                // Seçilen kursu öğrenciye ekle
                var courseSelection = new StudentCourseSelection
                {
                    StudentID = student.StudentID,
                    CourseID = courseId,
                    //IsSelected = true
                };

                _context.StudentCourseSelections.Add(courseSelection);
                _context.SaveChanges();

                TempData["Message"] = "Kurs başarıyla seçildi!";
            }

            return RedirectToAction("Index"); // Kurs listesine geri dön
        }

        // Öğrenci silme


    }
}

