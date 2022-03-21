using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AssnyDemo.Models
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        [ForeignKey("Levels")]
        public int LevelId { get; set; }
        public virtual Levels Levels { get; set; }
        public virtual IList<Teacher_Notes> Teacher_Notes { get; set; }
        public virtual IList<Teacher_Exams> Teacher_Exams { get; set; }
        public virtual IList<Teacher_Videos> Teacher_Videos { get; set; }
        
    }
}
