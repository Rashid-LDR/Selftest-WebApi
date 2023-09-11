using Microsoft.AspNetCore.Mvc;
using Selftest_WebApi.DTO.TeacherDtos;
using Selftest_WebApi.Models;
using Selftest_WebApi.Services.TeacherServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Selftest_WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeacherController:ControllerBase
    {
        private readonly ITeacherServicecs _teacherservice;

        public TeacherController(ITeacherServicecs teacherservice)
        {
            _teacherservice = teacherservice;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllTeacherRecord()
        {
            return Ok(await _teacherservice.GetAllTeachers());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeacherRecordByID(int id)
        {
            return Ok(await _teacherservice.GetTeacherById(id));
        }
        [HttpPost]
        public async Task<IActionResult> AddNewTeacher(AddNewTeacherDTO newTeacherRecord) {

            
            return Ok(await _teacherservice.AddNewTeacher(newTeacherRecord));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTeacherRecord(UpdateTeacherRecordDTO updatedata)
        {
            return Ok(await _teacherservice.UpdateTeacherById(updatedata));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacherRecord(int id)
        {
            return Ok(await _teacherservice.DeleteTeacherRecordByID(id));
        }


    }
}
