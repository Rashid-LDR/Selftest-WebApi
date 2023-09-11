using Microsoft.AspNetCore.Mvc;
using Selftest_WebApi.DTO.Student;
using Selftest_WebApi.Models;
using Selftest_WebApi.Services.StudentServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Selftest_WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController:ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        
        [Route("GetAll")]
        public async Task<IActionResult> GetAllStudentsData() {
            return Ok(await _studentService.GetAllStudents());
        }
        [Route("{id}")]
        public async Task<IActionResult> GetSingleStudentdata(int id) {
            return Ok(await _studentService.GetStudentById(id));
        }
        [HttpPost]
        public async Task<IActionResult> AddNewStudent(AddStudentDTO student)
        {
            return Ok(await _studentService.AddNewStudent(student));   
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStudentRecord(UpdataStudentDTO UpdateStudent)
        {
            return Ok(await _studentService.UpdateStudentData(UpdateStudent));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            return Ok(_studentService.DeleteStudentData(id));
        }
    }
}
