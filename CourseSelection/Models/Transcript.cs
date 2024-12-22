using CourseSelection.Models;

namespace CourseSelection.Models
{
    public class Transcript
    {
        
        public int StudentID { get; set; }
        public int CourseID { get; set; }
        public string Grade { get; set; }

        // Navigation Properties
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}

