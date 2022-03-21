using BLL.StudentServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssessnyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController (IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpGet("GetStudentSubject")]
        public async Task<IActionResult> GetStudentSubjectAsync(int StudentId)
        {
            var res = await _studentService.GetStudentSubjectAsync(StudentId);
            return Ok(res);
        }
        [HttpGet("GetTeacherSubject")]
        public async Task<IActionResult> GetTeacherSubjectAsync(int SubjectId)
        {
            var res = await _studentService.GetTeacherSubjectAsync(SubjectId);
            return Ok(res);
        }
    }
}
