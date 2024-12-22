﻿namespace CourseSelection.Models
{
    public class StudentCourseSelection
    {
        public int SelectionID { get; set; } // Primary Key ve Identity
        public int StudentID { get; set; }
        public int CourseID { get; set; }
        public DateTime SelectionDate { get; set; }
        public bool IsApproved { get; set; }

        // Navigation Properties
        public Student? Student { get; set; }
        public Course? Course { get; set; }
    }
}


