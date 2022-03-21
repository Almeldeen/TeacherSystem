using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AssnyDemo.Models
{
    public class Stage
    {
        [Key]
        public int StageID { get; set; }
        public string StageName { get; set; }
        public virtual IList<Levels> Levels { get; set; }
        public virtual IList<Student> Students { get; set; }
    }
}
