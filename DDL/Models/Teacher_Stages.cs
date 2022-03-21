using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AssnyDemo.Models
{
    public class Teacher_Stages
    {
        
        [Column(Order = 0), Key, ForeignKey("Teacher")]
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
        [Column(Order = 1), Key, ForeignKey("Levels")]
        public int LevelId { get; set; }
        public virtual Levels Levels { get; set; }
        [Column(Order = 2), Key, ForeignKey("Subject")]
        public int SubjectId { get; set; }
        public virtual Subject subject { get; set; }
        public decimal Price { get; set; }
    }
}
