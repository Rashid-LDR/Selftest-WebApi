using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Selftest_WebApi.DTO.SchoolsDTOs;
using Selftest_WebApi.DTO.Student;
using Selftest_WebApi.Models;
using Selftest_WebApi.Services.SchoolServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Selftest_WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SchoolController : ControllerBase
    {
        private readonly ISchoolService _schoolservice;

        public SchoolController(ISchoolService schoolservice)
        {
            _schoolservice = schoolservice;
        }



        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllSchoolRecords()
        {
            return Ok(await _schoolservice.GetallSchollsRecord());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSchoolRecordById(int id)
        {
            return Ok(await _schoolservice.GetSingleschollsRecordById(id));
        }
        [HttpPost]
        public async Task<IActionResult> AddNewSchoolRecord(AddSchoolDtos newschoolRecord)
        {
            
            return Ok(await _schoolservice.AddNewSchoolRecord(newschoolRecord));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchoolRecordById(int id)
        {
            return Ok(await _schoolservice.DeleteSchoolRecordByID(id));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSchoolRecord(UpdateSchoolRecordDto updateschool)
        {
            return Ok(await _schoolservice.UpdateSchoolRecord(updateschool));
        }
    }
}
