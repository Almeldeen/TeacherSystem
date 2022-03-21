using AssessnyApp.Container;
using DLL.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repositories
{
    public class StudentRepositorie:IStudentRepositorie
    {
        private readonly ApplicationDbContext _db;

        public StudentRepositorie(ApplicationDbContext db)
        {
            _db = db;
        }
        // public async Task<IList<Teacher_VM>> GetTeachersBySubjectIdAsync(int subjectid)
        //{
        //    return await _db.Teacher_Stages.Where(x => x.SubjectId == subjectid).Select(x => new Teacher_VM { TeacherId = x.TeacherId, TeacherName = x.Teacher.TeacherName }).ToListAsync();
        //}
        public async Task<IList<Subject_VM>> GetStudentSubjectAsync(int StudentId)
        {
            var data = await _db.Students.FindAsync(StudentId);
            return await _db.Subjects.Where(w => w.LevelId == data.levelId).Select(w => new Subject_VM { SubjectId = w.SubjectId, SubjectName = w.SubjectName, LevelId = w.LevelId }).Distinct().ToListAsync();
        }
        public async Task<IList<TeacherSubject_VM>> GetTeacherSubjectAsync(int subjectId)
        {
            return await _db.Teacher_Stages.Where(w => w.SubjectId == subjectId).Select(w => new TeacherSubject_VM { TeacherId = w.TeacherId, LevelId = w.LevelId, SubjectId = w.SubjectId , Price = w.Price}).Distinct().ToListAsync();
        }
    }
}
