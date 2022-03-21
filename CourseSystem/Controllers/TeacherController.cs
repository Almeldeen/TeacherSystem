using AssnyDemo.Models;
using BLL.Helper;
using BLL.TeacherServices;
using DLL.ViewModels;
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
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }
        [HttpGet("GetAllBasicData")]
        public async Task<IActionResult> GetAllBasicDataAsync(int? TeacherId)
        {
            var stages = await _teacherService.GetAllBasicDataAsync(TeacherId);

            return Ok(stages);
        }

        [HttpGet("GetStages")]
        public async Task<IActionResult> GetStagesAsync()
        {
            var stages = await _teacherService.GetStagesAsync();

            return Ok(stages);
        }
        [HttpGet("GetLevelsByStageId")]
        public async Task<IActionResult> GetLevelsByStageIdAsync(int stageid)
        {
            var levels = await _teacherService.GetLevelsByStageIdAsync(stageid);
            return Ok(levels);
        }
        [HttpGet("GetSubjectByLevelId")]
        public async Task<IActionResult> GetSubjectByLevelIdAsync(int levelid)
        {
            var levels = await _teacherService.GetSubjectByLevelIdAsync(levelid);
            return Ok(levels);
        }
        [HttpPost("AddTeacherSubject_Stage")]
        public async Task<IActionResult> AddTeacherSubject_StageAsync([FromBody] List<Teacher_Stages> teacherSubject_Stage_VM)
        {
            var res = await _teacherService.AddTeacherSubject_StageASync(teacherSubject_Stage_VM);

            return Ok(res);
        }
        [HttpPost("EditTeacherSubject_Stage")]
        public async Task<IActionResult> EditTeacherSubject_StageAsync([FromBody] List<Teacher_Stages> teacherSubject_Stage_VM)
        {
            var res = await _teacherService.EditTeacherSubject_StageAsync(teacherSubject_Stage_VM);

            return Ok(res);
        }

        [HttpGet("GetTeacherStages")]
        public async Task<IActionResult> GetTeacherStagesAsync(int TeacherId)
        {
            var stages = await _teacherService.GetTeacherStagesAsync(TeacherId);

            return Ok(stages);
        }
        [HttpGet("GetTeacherlevels")]
        public async Task<IActionResult> GetTeacherlevelsAsync(int TeacherId, int StagelId)
        {
            var stages = await _teacherService.GetTeacherlevelsAsync(TeacherId, StagelId);

            return Ok(stages);
        }
        [HttpGet("GetTeachersubject")]
        public async Task<IActionResult> GetTeachersubjectAsync(int TeacherId, int LevelId)
        {
            var stages = await _teacherService.GetTeachersubjectAsync(TeacherId, LevelId);

            return Ok(stages);
        }
        [HttpPost("AddTeacherNote")]
        public async Task<IActionResult> AddTeacherNoteAsync([FromForm] TeacherNote_VM teacherNote_VM)
        {
            var res = await _teacherService.AddTeacherNoteAsync(teacherNote_VM);
            return Ok(res);
        }
        [HttpPost("AddTeacherVedio")]
        public async Task<IActionResult> AddTeacherVedioAsync([FromForm] TeacherVedio_VM teacherVedio_VM)
        {
            var res = await _teacherService.AddTeacherVedioAsync(teacherVedio_VM);
            return Ok(res);
        }
        [HttpPost("AddTeacherExam")]
        public async Task<IActionResult> AddTeacherExamAsync([FromBody] Teacher_Exams teacher_Exams)
        {
            var res = await _teacherService.AddTeacherExamAsync(teacher_Exams);
            return Ok(res);
        }
        [HttpPost("AddTeacherQuestions_Exam")]
        public async Task<IActionResult> AddTeacherQuestions_ExamAsync([FromBody] Questions_Exam questions_Exam)
        {
            var res = await _teacherService.AddTeacherQuestions_ExamAsync(questions_Exam);
            return Ok(res);
        }
        [HttpPost("AddTeacherQuestions_Exam_Choises")]
        public async Task<IActionResult> AddTeacherQuestions_Exam_ChoisesAsync([FromBody] List<Questions_Exam_Choises> choises)
        {
            var res = await _teacherService.AddTeacherQuestions_Exam_ChoisesAsync(choises);
            return Ok(res);
        }
        [HttpGet("GetTeacherVedio")]
        public async Task<IActionResult> GetTeacherVedioAsync(int TeacherId, int SubjctlId)
        {
            var vedio = await _teacherService.GetTeacherVedioAsync(TeacherId, SubjctlId);

            return Ok(vedio);
        }
        [HttpGet("GetTeacherNote")]
        public async Task<IActionResult> GetTeacherNoteAsync(int TeacherId, int SubjectId)
        {
            var note = await _teacherService.GetTeacherNoteAsync(TeacherId, SubjectId);

            return Ok(note);
        }
        [HttpGet("GetTeacherExam")]
        public async Task<IActionResult> GetTeacherExamAsync(int TeacherID, int SubjectId)
        {
            var exam = await _teacherService.GetTeacherExamAsync(TeacherID, SubjectId);

            return Ok(exam);
        }
        [HttpGet("GetTeacherExamQuestions")]
        public async Task<IActionResult> GetTeacherExamQuestionsAsync(int TeacherExamId)
        {
            var exam = await _teacherService.GetTeacherExamQuestionsAsync(TeacherExamId);

            return Ok(exam);
        }

        [HttpGet("SearchTeacherVedio")]
        public async Task<IActionResult> SearchTeacherVedioAsync(string VedioName)
        {
            var res = await _teacherService.SearchTeacherVedioAsync(VedioName);
            return Ok(res);
        }
        [HttpGet("SearchTeacherNote")]
        public async Task<IActionResult> SearchTeacherNoteAsync(string NoteName)
        {
            var res = await _teacherService.SearchTeacherNoteAsync(NoteName);
            return Ok(res);
        }
        [HttpGet("SearchTeacherExam")]
        public async Task<IActionResult> SearchTeacherExamAsync( string ExamName)
        {
            var res = await _teacherService.SearchTeacherExamAsync(ExamName);
            return Ok(res);
        }
        
    }
}
