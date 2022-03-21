using AssnyDemo.Models;
using BLL.Helper;
using DLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.TeacherServices
{
   public interface ITeacherService
    {
        public Task<ResponseBody<Stage_VM>> GetStagesAsync();
        public Task<ResponseBody<AllData>> GetAllBasicDataAsync(int? TeacherId);
        public Task<ResponseBody<Level_VM>> GetLevelsByStageIdAsync(int stageid);
        public Task<ResponseBody<Subject_VM>> GetSubjectByLevelIdAsync(int levelid);
        public Task<ResponseBody<Teacher_Stages>> AddTeacherSubject_StageASync(List<Teacher_Stages> teacherSubject_Stage_VM);
        public Task<ResponseBody<Teacher_Stages>> EditTeacherSubject_StageAsync(List<Teacher_Stages> teacherSubject_Stage_VM);
        public Task<ResponseBody<Stage_VM>> GetTeacherStagesAsync(int TeacherId);
        public Task<ResponseBody<Level_VM>> GetTeacherlevelsAsync(int TeacherId, int StagelId);
        public Task<ResponseBody<Subject_VM>> GetTeachersubjectAsync(int TeacherId, int LevelId);
        public Task<ResponseBody<Teacher_Notes>> AddTeacherNoteAsync(TeacherNote_VM teacherNote_VM);
        public Task<ResponseBody<Teacher_Videos>> AddTeacherVedioAsync(TeacherVedio_VM teacherVedio_VM);     
        public Task<ResponseBody<Teacher_Exams>> AddTeacherExamAsync(Teacher_Exams teacher_Exams);
        public Task<ResponseBody<Questions_Exam>> AddTeacherQuestions_ExamAsync(Questions_Exam questions_Exam);
        public Task<ResponseBody<Questions_Exam_Choises>> AddTeacherQuestions_Exam_ChoisesAsync(List<Questions_Exam_Choises> choises);

        public Task<ResponseBody<TeacherVedio_VM>> GetTeacherVedioAsync(int TeacherId, int SubjectId);
        public Task<ResponseBody<TeacherNote_VM>> GetTeacherNoteAsync(int TeacherId, int SubjectId);
        public Task<ResponseBody<TeacherExam_VM>> GetTeacherExamAsync(int TeacherID, int SubjectId);

        public Task<ResponseBody<Question_VM>> GetTeacherExamQuestionsAsync(int TeacherExamId);

        public Task<ResponseBody<TeacherVedio_VM>> SearchTeacherVedioAsync(string VedioName);
        public Task<ResponseBody<TeacherNote_VM>> SearchTeacherNoteAsync(string NoteName);
        public Task<ResponseBody<TeacherExam_VM>> SearchTeacherExamAsync(string ExamName);

        

    }
}
