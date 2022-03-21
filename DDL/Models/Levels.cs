using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AssnyDemo.Models
{
    public class Levels
    {
        [Key]
        public int LevelsId { get; set; }
        public string Levels_Name { get; set; }
        [ForeignKey("Stage")]
        public int? StageId { get; set; }
        public virtual Stage Stage { get; set; }
        public virtual IList<Student> Students { get; set; }
    }
}
