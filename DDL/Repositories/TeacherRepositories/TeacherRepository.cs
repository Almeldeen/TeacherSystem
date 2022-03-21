using AssessnyApp.Container;
using AssnyDemo.Models;
using DLL.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly ApplicationDbContext _db;

        public TeacherRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IList<Stage_VM>> GetStagesAsync()
        {

            return await _db.Stages.Select(x => new Stage_VM { StageID = x.StageID, StageName = x.StageName }).ToListAsync();
        }
        public async Task<IList<Level_VM>> GetLevelsByStageIdAsync(int stageid)
        {
            return await _db.Levels.Where(x => x.StageId == stageid).Select(x => new Level_VM { LevelId = x.LevelsId, Level_Name = x.Levels_Name }).ToListAsync();
        }
        public async Task<IList<Subject_VM>> GetSubjectByLevelIdAsync(int levelid)
        {
            return await _db.Subjects.Where(x => x.LevelId == levelid).Select(x => new Subject_VM { SubjectId = x.SubjectId, SubjectName = x.SubjectName, LevelId = x.LevelId }).ToListAsync();
        }
        public async Task<bool> AddTeacherSubject_StageASync(List<Teacher_Stages> teacherSubject_Stage_VM)
        {
            try
            {
                await _db.Teacher_Stages.AddRangeAsync(teacherSubject_Stage_VM);
                int res = await _db.SaveChangesAsync();
                if (res <= 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {

                return false;
            }

        }
        public async Task<bool> EditTeacherSubject_StageAsync(List<Teacher_Stages> teacherSubject_Stage_VM)
        {
            try
            {
                var data =await _db.Teacher_Stages.Where(y=> y.TeacherId==teacherSubject_Stage_VM.Select(x => x.TeacherId).FirstOrDefault()&&y.LevelId== teacherSubject_Stage_VM.Select(x => x.LevelId).FirstOrDefault()).ToListAsync();
                _db.Teacher_Stages.RemoveRange(data);
                await _db.Teacher_Stages.AddRangeAsync(teacherSubject_Stage_VM);
                int res = await _db.SaveChangesAsync();
                if (res <= 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {

                return false;
            }

        }

        public async Task<IList<Stage_VM>> GetTeacherStagesAsync(int TeacherId)
        {
            return await _db.Teacher_Stages.Where(w => w.TeacherId == TeacherId).Select(w => new Stage_VM { StageID = w.Levels.Stage.StageID, StageName = w.Levels.Stage.StageName }).Distinct().ToListAsync();
        }

        public async Task<IList<Level_VM>> GetTeacherlevelsAsync(int TeacherId, int StagelId)
        {
            return await _db.Teacher_Stages.Where(w => w.TeacherId == TeacherId && w.Levels.StageId == StagelId).Select(w => new Level_VM { LevelId = w.Levels.LevelsId, Level_Name = w.Levels.Levels_Name }).Distinct().ToListAsync();
        }

        public async Task<IList<Subject_VM>> GetTeachersubjectAsync(int TeacherId, int LevelId)
        {
            return await _db.Teacher_Stages.Where(w => w.TeacherId == TeacherId && w.Levels.LevelsId == LevelId).Select(w => new Subject_VM { SubjectId = w.SubjectId, SubjectName = w.subject.SubjectName }).Distinct().ToListAsync();
        }
        public async Task<bool> AddTeacherNoteAsync(Teacher_Notes teacher_Notes)
        {
            try
            {
                await _db.Teacher_Notes.AddAsync(teacher_Notes);
                int res = await _db.SaveChangesAsync();
                if (res <= 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {

                return false;
            }

        }
        public async Task<bool> AddTeacherVedioAsync(Teacher_Videos teacher_Videos)
        {
            try
            {
                await _db.Teacher_Videos.AddAsync(teacher_Videos);
                int res = await _db.SaveChangesAsync();
                if (res <= 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {

                return false;
            }

        }
        public async Task<bool> AddTeacherExamAsync(Teacher_Exams teacher_Exams)
        {
            try
            {
                await _db.Teacher_Exams.AddAsync(teacher_Exams);
                int res = await _db.SaveChangesAsync();
                if (res <= 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public async Task<bool> AddTeacherQuestions_ExamAsync(Questions_Exam questions_Exam)
        {
            try
            {
                await _db.Questions_Exams.AddAsync(questions_Exam);
                int res = await _db.SaveChangesAsync();
                if (res <= 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public async Task<bool> AddTeacherQuestions_Exam_ChoisesAsync(List<Questions_Exam_Choises> choises)
        {
            try
            {
                await _db.Questions_Exam_Choises.AddRangeAsync(choises);
                int res = await _db.SaveChangesAsync();
                if (res <= 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async Task<IList<TeacherVedio_VM>> GetTeacherVedioAsync(int TeacherId, int SubjectId)
        {
            return await _db.Teacher_Videos.Where(w => w.TeacherId == TeacherId && w.SubjectId == SubjectId)
                .Select(w => new TeacherVedio_VM { VideoAddres = w.VideoAddres, VideoDescription = w.VideoDescription, VideoImageString = w.VideoImage, VedioPathString = w.VideoPath, Teacher_VideoId = w.Teacher_VideoId, TeacherId = w.TeacherId, SubjectId = w.SubjectId }).Distinct().ToListAsync();
        }

        public async Task<IList<TeacherNote_VM>> GetTeacherNoteAsync(int TeacherId, int SubjectId)
        {
            return await _db.Teacher_Notes.Where(w => w.TeacherId == TeacherId && w.SubjectId == SubjectId)
               .Select(w => new TeacherNote_VM { TeacherNoteId = w.TeacherNoteId, NoteAddres = w.NoteAddres, NoteDescription = w.NoteDescription, NotePathString = w.NotePath, TeacherId = w.TeacherId, SubjectId = w.SubjectId }).Distinct().ToListAsync();

        }

        public async Task<IList<TeacherExam_VM>> GetTeacherExamAsync(int TeacherID, int SubjectId)
        {
            return await _db.Teacher_Exams.Where(w => w.TeacherId == TeacherID && w.SubjectId == SubjectId)
                .Select(w => new TeacherExam_VM { TeacherExamId = w.TeacherExamId, ExamName = w.ExamName, ExamMark = w.ExamMark, TeacherId = w.TeacherId }).Distinct().ToListAsync();
        }

        public async Task<IList<Question_VM>> GetTeacherExamQuestionsAsync(int TeacherExamId)
        {
            return await _db.Questions_Exams.Where(w => w.TeacherExamId == TeacherExamId).Select(x => new Question_VM
            {
                QuestionContent = x.QuestionContent,
                QuestionAnswer = x.QuestionAnswer,
                QuestionMark = x.QuestionMark,
                QuestionType = x.QuestionType,
                QuestionsExamId = x.QuestionsExamId,
                TeacherExamId = x.TeacherExamId,
                choises = _db.Questions_Exam_Choises.Where(q => q.Questions_Exam.QuestionType == "Chiose" && q.QuestionExamId == x.QuestionsExamId).Select(c => new Choises { QuestionExamChoiseId = c.QuestionExamChoiseId, Question_Exam_Choise_Content = c.Question_Exam_Choise_Content }).ToList()
            }).ToListAsync();
        }

        public async Task<IList<TeacherVedio_VM>> SearchTeacherVedioAsync(string VedioName)
        {
            return await _db.Teacher_Videos.Where(w => w.VideoAddres.Contains(VedioName)).Select(w => new TeacherVedio_VM { VideoAddres = w.VideoAddres, VideoDescription = w.VideoDescription, VideoImageString = w.VideoImage, VedioPathString = w.VideoPath, Teacher_VideoId = w.Teacher_VideoId, TeacherId = w.TeacherId, SubjectId = w.SubjectId }).Distinct().ToListAsync();
        }

        public async Task<IList<TeacherNote_VM>> SearchTeacherNoteAsync(string NoteName)
        {
            return await _db.Teacher_Notes.Where(w => w.NoteAddres.Contains(NoteName)).Select(w => new TeacherNote_VM { TeacherNoteId = w.TeacherNoteId, NoteAddres = w.NoteAddres, NoteDescription = w.NoteDescription, NotePathString = w.NotePath, TeacherId = w.TeacherId, SubjectId = w.SubjectId }).Distinct().ToListAsync();

        }

        public async Task<IList<TeacherExam_VM>> SearchTeacherExamAsync(string ExamName)
        {
            return await _db.Teacher_Exams.Where(w => w.ExamName.Contains(ExamName)).Select(w => new TeacherExam_VM { TeacherExamId = w.TeacherExamId, ExamName = w.ExamName, ExamMark = w.ExamMark, TeacherId = w.TeacherId }).Distinct().ToListAsync();

        }
        
    }
}
