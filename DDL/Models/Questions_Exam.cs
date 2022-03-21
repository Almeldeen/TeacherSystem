using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AssnyDemo.Models
{
    public class Questions_Exam
    {
        [Key]
        public int QuestionsExamId { get; set; }
        public string QuestionContent { get; set; }
        public string QuestionType { get; set; }
        public string QuestionAnswer { get; set; }
        public string QuestionMark { get; set; }
        [ForeignKey("Teacher_Exams")]
        public int? TeacherExamId { get; set; }
        public virtual Teacher_Exams Teacher_Exams { get; set; }
        public virtual IList<Questions_Exam_Choises> Questions_Exam_Choises { get; set; }
    }
}
