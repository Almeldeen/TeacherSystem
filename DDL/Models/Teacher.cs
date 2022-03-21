using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AssnyDemo.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public DateTime DataBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual IdentityUser User { get; set; }
        //public virtual IList<Teacher_Notes> Teacher_Notes { get; set; }
        //public virtual IList<Teacher_Exams> Teacher_Exams { get; set; }
        //public virtual IList<Teacher_Videos> Teacher_Videos { get; set; }
        //public virtual IList<Teacher_Stages> Teacher_Stages { get; set; }

    }
}
