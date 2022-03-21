using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.ViewModels
{
    public class TeacherNote_VM
    {
        public int TeacherNoteId { get; set; }
        public string NoteAddres { get; set; }
        public string NoteDescription { get; set; }
        public IFormFile NotePath { get; set; }
        public int TeacherId { get; set; }
        public int SubjectId { get; set; }
        public string NotePathString { get; set; }
    }
}
