using AssnyDemo.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssessnyApp.Container
{
    public class ApplicationDbContext: IdentityDbContext
    {
       

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Stage> Stages { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Levels> Levels { get; set; }
        public DbSet<Teacher_Stages> Teacher_Stages { get; set; }
        public DbSet<Teacher_Notes> Teacher_Notes { get; set; }
        public DbSet<Teacher_Videos> Teacher_Videos { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Questions_Exam> Questions_Exams { get; set; }
        public DbSet<Questions_Exam_Choises> Questions_Exam_Choises { get; set; }
        public DbSet<Teacher_Exams> Teacher_Exams { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Student_Subjects> student_Subjects { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher_Stages>()
                .HasKey(b => new { b.TeacherId, b.LevelId, b.SubjectId })
                .HasName("Teacher_Stages_Subject");
            modelBuilder.Entity<Student_Subjects>()
               .HasKey(b => new { b.TeacherId, b.StudentId, b.SubjectId })
               .HasName("Student_Teacher_Subject");
            base.OnModelCreating(modelBuilder);
        }
    }
}
