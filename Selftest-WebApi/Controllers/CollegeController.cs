using Microsoft.AspNetCore.Mvc;
using Selftest_WebApi.Services.PGCServices;
using System.Threading.Tasks;
using System.Collections.Generic;
using Selftest_WebApi.Models;
using AutoMapper;
using Selftest_WebApi.DTO.CollegeDTO;

namespace Selftest_WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CollegeController:ControllerBase
    {
        
        private readonly IPGCServices _pgcservices;

        public CollegeController(IMapper mapper,IPGCServices pgcservices)
        {
            
            _pgcservices = pgcservices;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllCollegeInfo()
        {
            return Ok(await _pgcservices.GetAllCollegesDetails());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleCollegeInfo(int ID)
        {
            return Ok(await _pgcservices.GetSingleCollegeDetail(ID));
        }

        [HttpPost]
        public async Task<IActionResult> AddNewCollege(AddnewCollegeDto newCollegeInfo)
        {
            return Ok(await _pgcservices.AddNewCollegeDetails(newCollegeInfo));
        }
        [HttpPut]
        public async Task<IActionResult> updateCollegeInformation(UpdateCollegeInfoDto updatecolgInfo)
        {
            return Ok(await _pgcservices.UpdateCollegeDetailBy(updatecolgInfo));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> deletecolgInfoById(int id)
        {
            return Ok(await _pgcservices.DeleteCollegeDetailByID(id));
        }
    }
}
