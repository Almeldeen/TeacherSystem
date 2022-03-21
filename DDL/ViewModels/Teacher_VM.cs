using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.ViewModels
{
   public class Teacher_VM
    {
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public DateTime DataBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
