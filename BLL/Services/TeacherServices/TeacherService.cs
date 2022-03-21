using AssnyDemo.Models;
using BLL.Helper;
using DLL.Repositories;
using DLL.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.TeacherServices
{
    public class TeacherService : ITeacherService
    {
        ITeacherRepository _teacherRepository;
        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }
        public async Task<ResponseBody<AllData>> GetAllBasicDataAsync(int? TeacherId)
        {
            AllData allDatas = new AllData();


            allDatas.AllStage = _teacherRepository.GetStagesAsync().Result.Select(x => new AllStage
            {
                StageID = x.StageID,
                StageName = x.StageName,
                Check = _teacherRepository.GetTeacherStagesAsync((int)TeacherId).Result.Where(s => s.StageID == x.StageID).Any(),
                AllLevels = _teacherRepository.GetLevelsByStageIdAsync(x.StageID).Result.Select(l => new AllLevels
                {
                    LevelId = l.LevelId,
                    Level_Name = l.Level_Name,
                    Check = _teacherRepository.GetTeacherlevelsAsync((int)TeacherId, x.StageID).Result.Where(s => s.LevelId == l.LevelId).Any(),
                    AllSup = _teacherRepository.GetSubjectByLevelIdAsync(l.LevelId).Result.Select(Su => new AllSup
                    {
                        SubjectId = Su.SubjectId,
                        SubjectName = Su.SubjectName,
                        LevelId=l.LevelId,
                        Check = _teacherRepository.GetTeachersubjectAsync((int)TeacherId, l.LevelId).Result.Where(s => s.SubjectId == Su.SubjectId).Any(),

                    }).ToList()

                }).ToList()
            }).ToList();
            ResponseBody<AllData> response = new ResponseBody<AllData>();
            response.data = new List<AllData> { allDatas };
            response.message = true;
            response.status_code = $"{ StatusCodes.Status200OK}";
            response.error = null;
            return response;
        }
        public async Task<ResponseBody<Stage_VM>> GetStagesAsync()
        {

            ResponseBody<Stage_VM> response = new ResponseBody<Stage_VM>();
            response.data = await _teacherRepository.GetStagesAsync();
            response.message = true;
            response.status_code = $"{ StatusCodes.Status200OK}";
            response.error = null;
            return response;
        }
        public async Task<ResponseBody<Level_VM>> GetLevelsByStageIdAsync(int stageid)
        {
            ResponseBody<Level_VM> response = new ResponseBody<Level_VM>();
            response.data = await _teacherRepository.GetLevelsByStageIdAsync(stageid);
            response.message = true;
            response.status_code = $"{ StatusCodes.Status200OK}";
            response.error = null;
            return response;

        }
        public async Task<ResponseBody<Subject_VM>> GetSubjectByLevelIdAsync(int levelid)
        {
            ResponseBody<Subject_VM> response = new ResponseBody<Subject_VM>();
            response.data = await _teacherRepository.GetSubjectByLevelIdAsync(levelid);
            response.message = true;
            response.status_code = $"{ StatusCodes.Status200OK}";
            response.error = null;
            return response;

        }
        public async Task<ResponseBody<Teacher_Stages>> AddTeacherSubject_StageASync(List<Teacher_Stages> teacherSubject_Stage_VM)
        {
            ResponseBody<Teacher_Stages> response = new ResponseBody<Teacher_Stages>();
            var res = await _teacherRepository.AddTeacherSubject_StageASync(teacherSubject_Stage_VM);
            if (!res)
            {
                response.data = null;
                response.message = false;
                response.status_code = $"{ StatusCodes.Status400BadRequest}";
                response.error = null;
            }
            else
            {
                response.data = teacherSubject_Stage_VM;
                response.message = true;
                response.status_code = $"{ StatusCodes.Status200OK}";
                response.error = null;
            }
            return response;

        }  public async Task<ResponseBody<Teacher_Stages>> EditTeacherSubject_StageAsync(List<Teacher_Stages> teacherSubject_Stage_VM)
        {
            ResponseBody<Teacher_Stages> response = new ResponseBody<Teacher_Stages>();
            var res = await _teacherRepository.EditTeacherSubject_StageAsync(teacherSubject_Stage_VM);
            if (!res)
            {
                response.data = null;
                response.message = false;
                response.status_code = $"{ StatusCodes.Status400BadRequest}";
                response.error = null;
            }
            else
            {
                response.data = teacherSubject_Stage_VM;
                response.message = true;
                response.status_code = $"{ StatusCodes.Status200OK}";
                response.error = null;
            }
            return response;

        }
        public async Task<ResponseBody<Stage_VM>> GetTeacherStagesAsync(int TeacherId)
        {

            ResponseBody<Stage_VM> response = new ResponseBody<Stage_VM>();
            response.data = await _teacherRepository.GetTeacherStagesAsync(TeacherId);
            response.message = true;
            response.status_code = $"{ StatusCodes.Status200OK}";
            response.error = null;
            return response;
        }

        public async Task<ResponseBody<Level_VM>> GetTeacherlevelsAsync(int TeacherId, int StagelId)
        {
            ResponseBody<Level_VM> response = new ResponseBody<Level_VM>();
            response.data = await _teacherRepository.GetTeacherlevelsAsync(TeacherId, StagelId);
            response.message = true;
            response.status_code = $"{ StatusCodes.Status200OK}";
            response.error = null;
            return response;
        }

        public async Task<ResponseBody<Subject_VM>> GetTeachersubjectAsync(int TeacherId, int LevelId)
        {
            ResponseBody<Subject_VM> response = new ResponseBody<Subject_VM>();
            response.data = await _teacherRepository.GetTeachersubjectAsync(TeacherId, LevelId);
            response.message = true;
            response.status_code = $"{ StatusCodes.Status200OK}";
            response.error = null;
            return response;
        }



        public async Task<ResponseBody<Teacher_Notes>> AddTeacherNoteAsync(TeacherNote_VM teacherNote_VM)
        {
            // Get Directory
            string FilePath = Directory.GetCurrentDirectory() + "/TeacherNotes/" /*FolderPath*/;

            // Get File Name
            string FileName = Guid.NewGuid() + Path.GetFileName(teacherNote_VM.NotePath.FileName);

            // Merge The Directory With File Name
            string FinalPath = Path.Combine(FilePath, FileName);


            // Save Your File As Stream "Data Overtime"
            using (var Stream = new FileStream(FinalPath, FileMode.Create)) // save like 0 1 
            {
                teacherNote_VM.NotePath.CopyTo(Stream);
            }
            Teacher_Notes teacher_Notes = new Teacher_Notes();
            teacher_Notes.NoteAddres = teacherNote_VM.NoteAddres;
            teacher_Notes.NoteDescription = teacherNote_VM.NoteDescription;
            teacher_Notes.NotePath = FinalPath;
            teacher_Notes.SubjectId = teacherNote_VM.SubjectId;
            teacher_Notes.TeacherId = teacherNote_VM.TeacherId;
            bool res = await _teacherRepository.AddTeacherNoteAsync(teacher_Notes);
            ResponseBody<Teacher_Notes> response = new ResponseBody<Teacher_Notes>();
            if (!res)
            {
                response.data = null;
                response.message = false;
                response.status_code = $"{ StatusCodes.Status400BadRequest}";
                response.error = null;
            }
            else
            {
                response.data = new List<Teacher_Notes> { teacher_Notes };
                response.message = true;
                response.status_code = $"{ StatusCodes.Status200OK}";
                response.error = null;
            }


            return response;
        }
        public async Task<ResponseBody<Teacher_Videos>> AddTeacherVedioAsync(TeacherVedio_VM teacherVedio_VM)
        {
            // Get Directory
            string FilePath = Directory.GetCurrentDirectory() + "/TeacherVedios/" /*FolderPath*/;

            // Get File Name
            //string FileNameVedio = Guid.NewGuid() + Path.GetFileName(teacherVedio_VM.VedioPath.FileName);
            string FileNameImage = Guid.NewGuid() + Path.GetFileName(teacherVedio_VM.VideoImage.FileName);


            // Merge The Directory With File Name
            //string FinalPathVedio = Path.Combine(FilePath, FileNameVedio);
            string FinalPathImage = Path.Combine(FilePath, FileNameImage);


            // Save Your File As Stream "Data Overtime"
            //using (var Stream = new FileStream(FinalPathVedio, FileMode.Create)) // save like 0 1 
            //{
            //    teacherVedio_VM.VedioPath.CopyTo(Stream);
            //}
            using (var Stream = new FileStream(FinalPathImage, FileMode.Create)) // save like 0 1 
            {
                teacherVedio_VM.VideoImage.CopyTo(Stream);
            }
            Teacher_Videos teacher_Videos = new Teacher_Videos();
            teacher_Videos.VideoDescription = teacherVedio_VM.VideoDescription;
            teacher_Videos.VideoPath = teacherVedio_VM.VedioPath;
            teacher_Videos.VideoAddres = teacherVedio_VM.VideoAddres;
            teacher_Videos.VideoImage = FinalPathImage;
            teacher_Videos.SubjectId = teacherVedio_VM.SubjectId;
            teacher_Videos.TeacherId = teacherVedio_VM.TeacherId;
            bool res = await _teacherRepository.AddTeacherVedioAsync(teacher_Videos);
            ResponseBody<Teacher_Videos> response = new ResponseBody<Teacher_Videos>();
            if (!res)
            {
                response.data = null;
                response.message = false;
                response.status_code = $"{ StatusCodes.Status400BadRequest}";
                response.error = null;
            }
            else
            {
                response.data = new List<Teacher_Videos> { teacher_Videos };
                response.message = true;
                response.status_code = $"{ StatusCodes.Status200OK}";
                response.error = null;
            }


            return response;
        }
        public async Task<ResponseBody<Teacher_Exams>> AddTeacherExamAsync(Teacher_Exams teacher_Exams)
        {

            ResponseBody<Teacher_Exams> response = new ResponseBody<Teacher_Exams>();
            var res = await _teacherRepository.AddTeacherExamAsync(teacher_Exams);
            if (!res)
            {
                response.data = null;
                response.message = false;
                response.status_code = $"{ StatusCodes.Status400BadRequest}";
                response.error = null;
            }
            else
            {
                response.data = new List<Teacher_Exams> { teacher_Exams };
                response.message = true;
                response.status_code = $"{ StatusCodes.Status200OK}";
                response.error = null;
            }
            return response;
        }
        public async Task<ResponseBody<Questions_Exam>> AddTeacherQuestions_ExamAsync(Questions_Exam questions_Exam)
        {
            ResponseBody<Questions_Exam> response = new ResponseBody<Questions_Exam>();
            var res = await _teacherRepository.AddTeacherQuestions_ExamAsync(questions_Exam);
            if (!res)
            {
                response.data = null;
                response.message = false;
                response.status_code = $"{ StatusCodes.Status400BadRequest}";
                response.error = null;
            }
            else
            {
                response.data = new List<Questions_Exam> { questions_Exam };
                response.message = true;
                response.status_code = $"{ StatusCodes.Status200OK}";
                response.error = null;
            }
            return response;
        }
        public async Task<ResponseBody<Questions_Exam_Choises>> AddTeacherQuestions_Exam_ChoisesAsync(List<Questions_Exam_Choises> choises)
        {
            ResponseBody<Questions_Exam_Choises> response = new ResponseBody<Questions_Exam_Choises>();
            var res = await _teacherRepository.AddTeacherQuestions_Exam_ChoisesAsync(choises);
            if (!res)
            {
                response.data = null;
                response.message = false;
                response.status_code = $"{ StatusCodes.Status400BadRequest}";
                response.error = null;
            }
            else
            {
                response.data = choises;
                response.message = true;
                response.status_code = $"{ StatusCodes.Status200OK}";
                response.error = null;
            }
            return response;
        }

        public async Task<ResponseBody<TeacherVedio_VM>> GetTeacherVedioAsync(int TeacherId, int SubjectId)
        {
            ResponseBody<TeacherVedio_VM> response = new ResponseBody<TeacherVedio_VM>();
            response.data = await _teacherRepository.GetTeacherVedioAsync(TeacherId, SubjectId);
            response.message = true;
            response.status_code = $"{ StatusCodes.Status200OK}";
            response.error = null;
            return response;
        }

        public async Task<ResponseBody<TeacherNote_VM>> GetTeacherNoteAsync(int TeacherId, int SubjectId)
        {
            ResponseBody<TeacherNote_VM> response = new ResponseBody<TeacherNote_VM>();
            response.data = await _teacherRepository.GetTeacherNoteAsync(TeacherId, SubjectId);
            response.message = true;
            response.status_code = $"{ StatusCodes.Status200OK}";
            response.error = null;
            return response;
        }

        public async Task<ResponseBody<TeacherExam_VM>> GetTeacherExamAsync(int TeacherID, int SubjectId)
        {
            ResponseBody<TeacherExam_VM> response = new ResponseBody<TeacherExam_VM>();
            response.data = await _teacherRepository.GetTeacherExamAsync(TeacherID, SubjectId);
            response.message = true;
            response.status_code = $"{ StatusCodes.Status200OK}";
            response.error = null;
            return response;
        }

        public async Task<ResponseBody<Question_VM>> GetTeacherExamQuestionsAsync(int TeacherExamId)
        {
            ResponseBody<Question_VM> response = new ResponseBody<Question_VM>();
            response.data = await _teacherRepository.GetTeacherExamQuestionsAsync(TeacherExamId);
            response.message = true;
            response.status_code = $"{ StatusCodes.Status200OK}";
            response.error = null;
            return response;
        }

        public async Task<ResponseBody<TeacherVedio_VM>> SearchTeacherVedioAsync(string VedioName)
        {
            ResponseBody<TeacherVedio_VM> response = new ResponseBody<TeacherVedio_VM>();
            response.data = await _teacherRepository.SearchTeacherVedioAsync(VedioName);
            response.message = true;
            response.status_code = $"{ StatusCodes.Status200OK}";
            response.error = null;
            return response;
        }

        public async Task<ResponseBody<TeacherNote_VM>> SearchTeacherNoteAsync(string NoteName)
        {
            ResponseBody<TeacherNote_VM> response = new ResponseBody<TeacherNote_VM>();
            response.data = await _teacherRepository.SearchTeacherNoteAsync(NoteName);
            response.message = true;
            response.status_code = $"{ StatusCodes.Status200OK}";
            response.error = null;
            return response;
        }

        public async Task<ResponseBody<TeacherExam_VM>> SearchTeacherExamAsync(string ExamName)
        {
            ResponseBody<TeacherExam_VM> response = new ResponseBody<TeacherExam_VM>();
            response.data = await _teacherRepository.SearchTeacherExamAsync(ExamName);
            response.message = true;
            response.status_code = $"{ StatusCodes.Status200OK}";
            response.error = null;
            return response;
        }


    }
}
