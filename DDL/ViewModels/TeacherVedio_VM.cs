using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.ViewModels
{
   public class TeacherVedio_VM
    {
        public int Teacher_VideoId { get; set; }
        public string VideoAddres { get; set; }
        public string VideoDescription { get; set; }
        public IFormFile VideoImage { get; set; }
        public string VedioPath { get; set; }
        public int TeacherId { get; set; }
        public int SubjectId { get; set; }
        public string VideoImageString { get; set; }
        public string VedioPathString { get; set; }
    }
}
