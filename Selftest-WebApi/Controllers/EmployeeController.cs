using Microsoft.AspNetCore.Mvc;
using Selftest_WebApi.DTO.EmployerDTO;
using Selftest_WebApi.Models;
using Selftest_WebApi.Services.EmployeeServices;
using System;
using System.Threading.Tasks;

namespace Selftest_WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController:ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService empService)
        {
            _employeeService = empService;       
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _employeeService.getvalue());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmp(int id) {
            return Ok(await _employeeService.getSingleEmp(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddNewEmployee(AddEmployeeDTO newemp)
        {
            return Ok(await _employeeService.AddNewEmp(newemp));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(UpdateEmployeeDto updateemp)
        {
            return Ok(await _employeeService.UpdateEmployeeInfo(updateemp));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteemp(int id)
        {
            return Ok(await _employeeService.DeleteEmployeeByID(id));
        }
    }
}
