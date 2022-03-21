using AssessnyApp.Container;
using BLL.Helper;
using DLL.Repositories;
using DLL.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.StudentServices
{
    public class StudentService : IStudentService
    {
        IStudentRepositorie _studentRepositorie;

        public StudentService(IStudentRepositorie studentRepositorie)
        {
            _studentRepositorie = studentRepositorie;
        }
        public async Task<ResponseBody<Subject_VM>> GetStudentSubjectAsync(int StudentId)
        {
            ResponseBody<Subject_VM> response = new ResponseBody<Subject_VM>();
            response.data = await _studentRepositorie.GetStudentSubjectAsync(StudentId);
            response.message = true;
            response.status_code = $"{ StatusCodes.Status200OK}";
            response.error = null;
            return response;
        }
        public async Task<ResponseBody<TeacherSubject_VM>> GetTeacherSubjectAsync(int SubjectId)
        {
            ResponseBody<TeacherSubject_VM> response = new ResponseBody<TeacherSubject_VM>();
            response.data = await _studentRepositorie.GetTeacherSubjectAsync(SubjectId);
            response.message = true;
            response.status_code = $"{ StatusCodes.Status200OK}";
            response.error = null;
            return response;
        }
    }
}
