using Microsoft.AspNetCore.Mvc;
using Selftest_WebApi.DTO.ClientDTO;
using Selftest_WebApi.Models;
using Selftest_WebApi.Services.ClientServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Selftest_WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController:ControllerBase
    {
        private readonly IClientServices _clientServices;

        public ClientController(IClientServices clientservice)
        {
            _clientServices = clientservice;    
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> getClients()
        {
            return Ok(await _clientServices.GetClient());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getClients(int id)
        {
            return Ok(await _clientServices.GetClientById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddNewClient(AddClientDTO newClient) {
            
            return Ok(await _clientServices.AddNewClient(newClient));
        
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientInfo(int id)
        {
            ClientServiceResponse<List<GetClientDTO>> response = await _clientServices.DeleteClient(id);
            if(response.Data==null)
                return NotFound(response);
            else
                return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateClientInfo(UpdateClientDTO UpdateClient)
        {

            return Ok(await _clientServices.UpdateClient(UpdateClient));

        }
    }
}
