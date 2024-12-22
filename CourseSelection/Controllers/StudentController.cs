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

        //[HttpGet("CourseSelection")]
        //public async Task<IActionResult> CourseSelection(int id)
        //{
        //    // Öğrenci, ders seçimleri ve danışmanı al
        //    var student = await _context.Students
        //                                 .Include(s => s.StudentCourseSelections)
        //                                     .ThenInclude(sc => sc.Course)
        //                                 .Include(s => s.Advisor) // Advisor bilgisi dahil edildi
        //                                 .FirstOrDefaultAsync(s => s.StudentID == id);


        //    // Eğer öğrenci bulunamazsa hata mesajı gönderin
        //    if (student == null)
        //    {
        //        ViewBag.Message = "Student not found.";
        //        return View(); // Boş bir View döner
        //    }

        //    // Öğrenci modelini View'a gönderin
        //    return View(student); // Student modelini gönderiyoruz
        //}
        [HttpPost]
        public async Task<IActionResult> SubmitCourseSelection(int id, List<int> SelectedCourseIds)
        {
            // Öğrenciyi veritabanından al
            var student = await _context.Students
                                        .Include(s => s.StudentCourseSelections)
                                        .FirstOrDefaultAsync(s => s.StudentID == id);

            if (student == null)
            {
                TempData["Message"] = "Student not found.";
                return RedirectToAction("CourseSelection", new { id });
            }

            // Seçilen dersleri al ve öğrenciye ekle
            if (SelectedCourseIds != null && SelectedCourseIds.Any())
            {
                foreach (var courseId in SelectedCourseIds)
                {
                    // Seçilen ders veritabanında var mı kontrol et
                    var course = await _context.Courses.FindAsync(courseId);
                    if (course != null)
                    {
                        var selection = new StudentCourseSelection
                        {
                            StudentID = student.StudentID,
                            CourseID = course.CourseID
                        };

                        _context.StudentCourseSelections.Add(selection);
                    }
                }

                await _context.SaveChangesAsync();
                TempData["Message"] = "Courses selected successfully!";
            }
            else
            {
                TempData["Message"] = "No courses selected.";
            }

            return RedirectToAction("CourseSelection", new { id });
        }


        //------------------------
        public IActionResult CourseSelection(int id)
        {
            var courses = _context.Courses.ToList();
            ViewBag.StudentID = id;
            return View(courses); // Student/CourseSelection.cshtml
        }

        [HttpPost]
        public async Task<IActionResult> CourseSelection(int studentId, List<int> selectedCourses)
        {
            foreach (var courseId in selectedCourses)
            {
                var existingSelection = _context.StudentCourseSelections
                    .FirstOrDefault(s => s.StudentID == studentId && s.CourseID == courseId);

                if (existingSelection == null) // Aynı ders iki kere eklenmesin
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

            await _context.SaveChangesAsync();
            return RedirectToAction("Details", new { id = studentId });
        }


        // Kurs seçimi formunu gösteren GET aksiyonu
        //[HttpPost]
        //public IActionResult SelectCourse(int courseId, string studentId)
        //{
        //    // Öğrenciyi oturumdan almak
        //    var student = _context.Students.FirstOrDefault(s => s.StudentID == int.Parse(studentId));

        //    if (student == null)
        //    {
        //        TempData["Message"] = "Öğrenci bulunamadı!";
        //        return RedirectToAction("Index");
        //    }

        //    // Kursu öğrenciye ekle
        //    var courseSelection = new StudentCourseSelection
        //    {
        //        StudentID = student.StudentID,
        //        CourseID = courseId
        //    };

        //    _context.StudentCourseSelections.Add(courseSelection);
        //    _context.SaveChanges();

        //    TempData["Message"] = "Kurs başarıyla seçildi!";
        //    return RedirectToAction("Index"); // Kurs listesine geri dön
        //}

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
        //public IActionResult SelectCourse(int studentId)
        //{

        //    var student = _context.Students.Include(s => s.Course).FirstOrDefault(s => s.StudentID == studentId);
        //    if (student == null)
        //    {
        //        return NotFound();
        //    }

        //    var courses = student.Course.ToList();

        //    // Tüm kursları listele
        //    //var student = _context.Courses?.ToList() ?? new List<Course>();

        //    return View(courses);
        //}

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

