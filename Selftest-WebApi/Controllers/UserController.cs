using Microsoft.AspNetCore.Mvc;
using Selftest_WebApi.DTO;
using Selftest_WebApi.Models;
using Selftest_WebApi.Services.UserServices;
using System.Threading.Tasks;

namespace Selftest_WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController:ControllerBase
    {
        private  readonly IUserServices _userservices;
        public UserController(IUserServices userServices)
        {
            _userservices = userServices;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            return Ok(await  _userservices.GetUser());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleValue(int id)
        {     
            return Ok(await _userservices.GetUserById(id));
        }     
              
        [HttpPost]
        public async Task<IActionResult> AddnewUser(AddUserDTO Newuser)
        {
            return Ok( await _userservices.Adduser(Newuser));
        }
    }
}
