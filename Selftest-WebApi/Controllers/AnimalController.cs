using Microsoft.AspNetCore.Mvc;
using Selftest_WebApi.Data;
using Selftest_WebApi.DTO.AnimalDTO;
using Selftest_WebApi.Models;
using Selftest_WebApi.Services.AnimalServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Selftest_WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnimalController:ControllerBase
    {
        private readonly IAnimalService _animalservice;
        

        public AnimalController(IAnimalService animalservice)
        {
            _animalservice = animalservice;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            AnimalServiceResponse<List<GetAnimalDTO>> resp= await _animalservice.getAnimals();
            if (resp.Data == null)
                return NotFound(resp);
            else
                return Ok(resp);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleAnimal(int id)
        {
            AnimalServiceResponse<GetAnimalDTO> resp = await _animalservice.getAnimalByID(id);
            if (resp.Data == null)
                return NotFound(resp);
            else
                return Ok(resp);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewAnimal(AddAnimalDTO newAnimal)
        {
            AnimalServiceResponse<List<GetAnimalDTO>> resp = await _animalservice.AddNewAnimal(newAnimal);
            if (resp.Data == null)
                return NotFound(resp);
            else
                return Ok(resp);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAnimal(UpdateAnimalDTO updateinfoAnimal)
        {
            AnimalServiceResponse<GetAnimalDTO> resp= await _animalservice.UpdateAnimal(updateinfoAnimal);
            if(resp.Data == null)
            {
                return NotFound(resp);
            }
            else
            {
                return Ok(resp);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteAnimal(int id)
        {
            AnimalServiceResponse<List<GetAnimalDTO>> resp = await _animalservice.deleteAnimalByID(id);
            if (resp.Data == null)
                return NotFound(resp);
            else
                return Ok(resp);
        }
    }
}
