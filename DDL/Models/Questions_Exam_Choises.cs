using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AssnyDemo.Models
{
    public class Questions_Exam_Choises
    {
        [Key]
        public int QuestionExamChoiseId { get; set; }
        public string Question_Exam_Choise_Content { get; set; }
        [ForeignKey("Questions_Exam")]
        public int? QuestionExamId { get; set; }
        public virtual Questions_Exam Questions_Exam { get; set; }
    }
}
