using AssessnyApp.Container;
using AssnyDemo.Models;
using BLL.AuthServices;
using BLL.Models;
using Microsoft.AspNetCore.Authorization;
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
    public class RegisterController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ApplicationDbContext db;
        public RegisterController(IAuthService authService, ApplicationDbContext _db)
        {
            _authService = authService;
            db = _db;
        }
       
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.RegisterAsync(model);

            if (!result.message)
            {
                return Ok(result);
            }
            else
            {
                if (model.Role=="Teacher")
                {
                    Teacher teacher = new Teacher();
                    Teacher_Stages teacher_Stages = new Teacher_Stages();
                    teacher.TeacherName = model.Name;
                    teacher.Password = model.Password;
                    teacher.PhoneNumber = model.PhoneNumber;
                    teacher.DataBirth = model.DataBirth;
                    teacher.Email = model.Email;
                    foreach (var item in result.data)
                    {
                        teacher.UserId = item.UseID;
                    }
                    db.Teachers.Add(teacher);
                   int res= db.SaveChanges();
                    if (res<=0)
                    {
                        return BadRequest();
                    }
                    foreach (var item in result.data)
                    {
                        item.UseID = teacher.TeacherId.ToString();
                    }

                }
                else if (model.Role == "Student")
                {
                    Student student = new Student();
                    student.Email = model.Email;
                    student.levelId = model.levelId;
                    student.Name = model.Name;
                    student.Password = model.Password;
                    student.StageId = model.StageId;
                    student.PhoneNumber = model.PhoneNumber;
                    foreach (var item in result.data)
                    {
                        student.UserId = item.UseID;
                    }
                    db.Students.Add(student);
                    int res = db.SaveChanges();
                    if (res <= 0)
                    {
                        return BadRequest();
                    }
                    foreach (var item in result.data)
                    {
                        item.UseID = student.StudentId.ToString();
                    }
                }
            }
               

            return Ok(result);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> GetTokenAsync([FromBody] TokenRequestModel model)
        {
            if (!ModelState.IsValid)
                return Ok(ModelState);

            var result = await _authService.GetTokenAsync(model);
            return Ok(result);
        }

    }
}
