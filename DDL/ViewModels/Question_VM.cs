using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.ViewModels
{
   public class Question_VM
    {
        public int QuestionsExamId { get; set; }
        public string QuestionContent { get; set; }
        public string QuestionType { get; set; }
        public string QuestionAnswer { get; set; }
        public string QuestionMark { get; set; }
        public List<Choises> choises { get; set; }
        public int? TeacherExamId { get; set; }
    }
    public class Choises
    {
        public int QuestionExamChoiseId { get; set; }
        public string Question_Exam_Choise_Content { get; set; }
      
        public int? QuestionExamId { get; set; }
    }
}
