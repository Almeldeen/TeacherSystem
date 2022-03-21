using AssnyDemo.Models;
using BLL.Helper;
using DLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.StudentServices
{
   public interface IStudentService
    {
        public Task<ResponseBody<Subject_VM>> GetStudentSubjectAsync(int StudentId);
        public Task<ResponseBody<TeacherSubject_VM>> GetTeacherSubjectAsync(int SubjectId);
    }
}
