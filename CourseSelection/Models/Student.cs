using CourseSelection.Models;

namespace CourseSelection.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int? AdvisorID { get; set; }
        public DateTime EnrollmentDate { get; set; }
        

        // Navigation Properties
        public Advisor Advisor { get; set; } // Danışman bilgisi için eklendi

        // Navigation Properties
        public ICollection<StudentCourseSelection> StudentCourseSelections { get; set; } = new List<StudentCourseSelection>();
    }
}
//Data Source=AHSEN\SQLEXPRESS;Initial Catalog=UniversityCourseSelection;Integrated Security=True;Trust Server Certificate=True