using Microsoft.AspNetCore.Mvc;
using Selftest_WebApi.DTO.PlantsDTO;
using Selftest_WebApi.Models;
using Selftest_WebApi.Services.PlantsServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Selftest_WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlantsController:ControllerBase
    {
        private readonly IPlantsService _plantsService;

        public PlantsController(IPlantsService plantsService)
        {
           _plantsService = plantsService;
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllPlantsRecord()
        {
            PlantsServiceResponse<List<PlantsDtos>> response = await _plantsService.GetAllPlantsInfo();
            if (response.Data == null)
            {
                return NotFound(response);
            }
            else
            {
                return Ok(response);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSignlePlantRecord(int id) {
            PlantsServiceResponse<PlantsDtos> response = await _plantsService.GetSinglePlantInfo(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            else
            {
                return Ok(response);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddnewPlant(AddPlantsinfoDto newplant) {
            PlantsServiceResponse<List<PlantsDtos>> response = await _plantsService.AddNewPlantsInfo(newplant);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            else
            {
                return Ok(response);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlantInfo(int id)
        {
            PlantsServiceResponse<List<PlantsDtos>> response = await _plantsService.DeletePlantsInfo(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            else
            {
                return Ok(response);
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePlantInfo(UpdatePlandInfoDtos updateplantinfo)
        {
            PlantsServiceResponse<PlantsDtos> response = await _plantsService.UpdatePlantInfo(updateplantinfo);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            else
            {
                return Ok(response);
            }
        }

    }
}
