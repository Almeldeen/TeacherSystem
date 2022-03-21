using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AssnyDemo.Models
{
    public class Teacher_Exams
    {
        [Key]
        public int TeacherExamId { get; set; }
        public string ExamName { get; set; }
        public string ExamMark { get; set; }
        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }
        [ForeignKey("Subject")]
        public int SubjectId { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual IList<Questions_Exam> Questions_Exams { get; set; }
        public virtual Subject Subjects { get; set; }
    }
}
