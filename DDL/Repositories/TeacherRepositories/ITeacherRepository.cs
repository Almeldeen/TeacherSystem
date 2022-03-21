using AssnyDemo.Models;
using DLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repositories
{
   public interface ITeacherRepository
    {
        public Task<IList<Stage_VM>> GetStagesAsync();
        public Task<IList<Level_VM>> GetLevelsByStageIdAsync(int stageid);
        public Task<IList<Subject_VM>> GetSubjectByLevelIdAsync(int levelid);
        public Task<bool> AddTeacherSubject_StageASync(List<Teacher_Stages> teacherSubject_Stage_VM);
        public Task<bool> EditTeacherSubject_StageAsync(List<Teacher_Stages> teacherSubject_Stage_VM);
        public Task<IList<Stage_VM>> GetTeacherStagesAsync(int TeacherId);
        public Task<IList<Level_VM>> GetTeacherlevelsAsync(int TeacherId, int StagelId);
        public Task<IList<Subject_VM>> GetTeachersubjectAsync(int TeacherId,int LevelId);
        public Task<bool> AddTeacherNoteAsync(Teacher_Notes teacher_Notes);
        public Task<bool> AddTeacherVedioAsync(Teacher_Videos teacher_Videos);
        
        public  Task<bool> AddTeacherExamAsync(Teacher_Exams teacher_Exams);
        public  Task<bool> AddTeacherQuestions_ExamAsync(Questions_Exam questions_Exam);
        public Task<bool> AddTeacherQuestions_Exam_ChoisesAsync(List<Questions_Exam_Choises> choises);

        public Task<IList<TeacherVedio_VM>> GetTeacherVedioAsync(int TeacherId, int SubjectId);
        public Task<IList<TeacherNote_VM>> GetTeacherNoteAsync(int TeacherId, int SubjectId);
        public Task<IList<TeacherExam_VM>> GetTeacherExamAsync(int TeacherID, int SubjectId);

        public Task<IList<Question_VM>> GetTeacherExamQuestionsAsync(int TeacherExamId);

        public Task<IList<TeacherVedio_VM>> SearchTeacherVedioAsync(string VedioName);
        public Task<IList<TeacherNote_VM>> SearchTeacherNoteAsync(string NoteName);
        public Task<IList<TeacherExam_VM>> SearchTeacherExamAsync(string ExamName);

        
    }
}
