//using Microsoft.EntityFrameworkCore;
//using CourseSelection.Models;
//using System.Collections.Generic;

//namespace CourseSelection.Data
//{
//    public class ApplicationDbContext : DbContext
//    {
//        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

//        public DbSet<Advisor> Advisors { get; set; }
//        public DbSet<Student> Students { get; set; }
//    }
//}
using Microsoft.EntityFrameworkCore;
using CourseSelection.Models;

namespace CourseSelection
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        public DbSet<Advisor> Advisors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<User> Users{ get; set; }
        public DbSet<StudentCourseSelection> StudentCourseSelections { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
          
            modelBuilder.Entity<StudentCourseSelection>()
                .Property(s => s.SelectionID)
                .ValueGeneratedOnAdd(); // Otomatik artış
        

        
        modelBuilder.Entity<StudentCourseSelection>()
                .HasKey(scs => new { scs.StudentID, scs.CourseID });

            
            modelBuilder.Entity<StudentCourseSelection>()
                .HasOne(scs => scs.Student)
                .WithMany(s => s.StudentCourseSelections)
                .HasForeignKey(scs => scs.StudentID);

            modelBuilder.Entity<StudentCourseSelection>()
                .HasOne(scs => scs.Course)
                .WithMany(c => c.StudentCourseSelections)
                .HasForeignKey(scs => scs.CourseID);
            
            modelBuilder.Entity<LoginViewModel>(entity =>
            {
                entity.HasKey(e => e.Username).HasName("PK_Login");

                entity.ToTable("Login");
                entity.Property(e => e.Username).HasColumnName("Username");
                entity.Property(e => e.PasswordHash).HasMaxLength(50);
            });
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.StudentID).HasName("PK_Students");

                entity.ToTable("Students");

                entity.Property(e => e.StudentID).HasColumnName("StudentID");
                entity.Property(e => e.FirstName).HasMaxLength(50);
                entity.Property(e => e.LastName).HasMaxLength(50);
                entity.Property(e => e.Email).HasMaxLength(100);
                
                
            });
            modelBuilder.Entity<Advisor>(entity =>
            {
                entity.HasKey(e => e.AdvisorID).HasName("PK_Advisors");

                entity.ToTable("Advisors");

                entity.Property(e => e.AdvisorID).HasColumnName("AdvisorID");
                entity.Property(e => e.FullName).HasMaxLength(50);
                entity.Property(e => e.Email).HasMaxLength(100);
                entity.Property(e => e.Department).HasMaxLength(50);
                
            });
           
        }

    }
}
