using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AssnyDemo.Models
{
    public class Teacher_Notes
    {
        [Key]
        public int TeacherNoteId { get; set; }
        public string NoteAddres { get; set; }
        public string NoteDescription { get; set; }
        public string NotePath { get; set; }
        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }
        [ForeignKey("Subject")]
        public int SubjectId { get; set; }
        public virtual Teacher teacher { get; set; }
        public virtual Subject subject { get; set; }

    }
}
