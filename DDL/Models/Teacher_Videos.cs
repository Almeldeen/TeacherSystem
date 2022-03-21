using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AssnyDemo.Models
{
    public class Teacher_Videos
    {
        [Key]
        public int Teacher_VideoId { get; set; }
        public string VideoAddres { get; set; }
        public string VideoDescription { get; set; }
        public string VideoPath { get; set; }
        public string VideoImage { get; set; }
        [ForeignKey("TeacherId")]
        public int TeacherId { get; set; }
        [ForeignKey("SubjectId")]
        public int SubjectId { get; set; }
        public virtual Teacher teacher { get; set; }
        public virtual Subject subject { get; set; }
    }
}
