using Microsoft.AspNetCore.Mvc;
using Selftest_WebApi.DTO.CharacterDtos;
using Selftest_WebApi.Models;
using Selftest_WebApi.Services.CharacterServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Selftest_WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
            
        private readonly ICharacterServices _characterServices;
        public CharacterController(ICharacterServices characterservice)
        {
            _characterServices = characterservice;  
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            CharacterServiceResponse<List<GetCharacterDTO>> response = await _characterServices.GetCharacters();
            if(response.Data== null)
                return NotFound(response);
            else
                return Ok(response);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetSignleChar(int id) {
            CharacterServiceResponse<GetCharacterDTO> response = await _characterServices.GetSingleCharacter(id);
            if (response.Data == null)
                return NotFound(response);
            else
                return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Addcharacter(AddCharacterDTO newCharacter)
        {
            CharacterServiceResponse<List<GetCharacterDTO>> response = await _characterServices.AddNewCharacter(newCharacter);
            if(response.Data==null)
                return NotFound(response);
            else
                return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Updatecharacter(UpdateCharacterDTO updateCharacter)
        {
            CharacterServiceResponse<GetCharacterDTO> response = await _characterServices.UpdateCharacter(updateCharacter);

            if(response.Data ==null)
                return NotFound(response);
            else
                return Ok(response);
            
        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteCharacter(int id)
        {
            CharacterServiceResponse<List<GetCharacterDTO>> response = await _characterServices.DeleteCharacter(id);
             if(response.Data ==null)
                return NotFound(response);
            else
                return Ok(response); 
        }















    }
}
