using Microsoft.AspNetCore.Mvc;
using Selftest_WebApi.DTO.CostumerDTO;
using Selftest_WebApi.Models;
using Selftest_WebApi.Services.CostumerServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Selftest_WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CostumerController:ControllerBase
    {
        
        
        private readonly ICostumerService _costumer;

        public CostumerController(ICostumerService costumer)
        {
            _costumer = costumer;
        }
        [Route("GetAll")]
        public async Task<IActionResult> GetAllCostumer()
        {
            CostumerServiceResponse<List<CostumerDto>> response = await _costumer.GetAllCostumers();
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
        public async Task<IActionResult> GetCostumerById(int id)
        {
            CostumerServiceResponse<CostumerDto> response = await _costumer.GetCostumersById(id);
            if (response.Data == null)
            {
                return NotFound(response);

            }
            else
            {
                return Ok(response);
            }

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddnewCostumer(AddCostumerDto newCostumer) 
        {
            CostumerServiceResponse<List<CostumerDto>> response = await _costumer.AddCostumer(newCostumer);
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
        public async Task<IActionResult> UpdateCostumer(UpdateCostumerDto updatecostumer)
        {
            CostumerServiceResponse<CostumerDto> response = await _costumer.UpdateCostumer(updatecostumer);
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
        public async Task<IActionResult> DeleteCostumerById(int id)
        {
            CostumerServiceResponse<List<CostumerDto>> response = await _costumer.DeleteCostumerbyID(id);
            if(response.Data==null)
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
