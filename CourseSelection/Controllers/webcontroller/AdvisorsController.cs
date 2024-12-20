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
            return View(students); // Öğrencilerin listesi gönderiliyor
        

        //// Advisor ID'ye göre danışman ve öğrencileri alınıyor
        //var students = _context.Advisors
        //    .Where(a => a.AdvisorID == id)
        //    .Select(a => new
        //    {
        //        a.Students
        //    })
        //    .FirstOrDefault();

        //if (advisors == null || advisors.Students == null)
        //{
        //    return NotFound(); // Eğer danışman ya da öğrencileri bulunamazsa 404 döndür
        //}

        //return View(advisors.Students); // Öğrencileri View'e gönder
    }


    //[HttpGet("ApproveCourses")]
    //public IActionResult ApproveCourses(int id)
    //{
    //    // Danışman tarafından onaylanacak dersler burada işlenir.
    //    var advisor = _context.Advisors
    //        .Include(a => a.Students)
    //        .FirstOrDefault(a => a.AdvisorID == id);

    //    if (advisor == null)
    //    {
    //        return NotFound(new { Message = "Advisor not found." });
    //    }
    //    return View(advisor);
    //}

    //[HttpGet("ViewStudentCourses/{studentId}")]
    //public IActionResult ViewStudentCourses(int studentId)
    //{
    //    // Öğrenciyi ve seçtiği dersleri çekiyoruz
    //    var student = _context.Students
    //        .Include(s => s.StudentCourseSelections)
    //            .ThenInclude(sc => sc.Course)
    //        .FirstOrDefault(s => s.StudentID == studentId);

    //    if (student == null)
    //    {
    //        return NotFound(new { Message = "Student not found." });
    //    }

    //    return View(student);
    //}

    //[HttpGet("getAdvisorList")]
    //public async Task<ActionResult<IEnumerable<Advisor>>> GetAdvisors()
    //{
    //    return await _context.Advisors.ToListAsync();
    //}

    //// GET: api/AdvisorController/getById?id=5
    //[HttpGet("getById")]
    //public async Task<ActionResult<Advisor>> GetAdvisor(int id)
    //{
    //    var advisor = await _context.Advisors.FindAsync(id);

    //    if (advisor == null)
    //    {
    //        return NotFound(new { Message = "Advisor not found." });
    //    }

    //    return advisor;
    //}


    //public IActionResult Index(int id)
    //{
    //    var advisor = _context.Advisors.ToList();
    //    return View(advisor);
    //    //var advisor = _context.Advisors.Find(id);
    //    //if (advisor == null)
    //    //{
    //    //    return NotFound();
    //    //}
    //    //return View(new List<Advisor> { advisor });
    //}
    //var advisor = _context.Advisors.Where(p => p.AdvisorID == id).ToList();
    //return View(advisor);


    //public IActionResult Details(int id)
    //{
    //    var advisor = _context.Advisors.Where(p => p.AdvisorID == id).ToList();

    //    return View(advisor);
    //}


}
}

