using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.ViewModels
{
  public  class Teacher_Exams_VM
    {
        public int TeacherExamId { get; set; }
        public string ExamName { get; set; }
        public string ExamMark { get; set; }
       
        public int TeacherId { get; set; }
        public int SubjectId { get; set; }
    }
}
