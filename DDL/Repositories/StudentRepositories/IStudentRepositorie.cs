using DLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repositories
{
   public interface IStudentRepositorie
    {
        public Task<IList<Subject_VM>> GetStudentSubjectAsync(int StudentId);
        public Task<IList<TeacherSubject_VM>> GetTeacherSubjectAsync(int SubjectId);
    }
}
