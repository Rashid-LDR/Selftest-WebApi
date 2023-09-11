using Selftest_WebApi.DTO.EmployerDTO;
using Selftest_WebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Selftest_WebApi.Services.EmployeeServices
{
    public interface IEmployeeService
    {
        Task<EmployeeServiceResponse<List<GetEmployeeDTO>>> getvalue();


         Task<EmployeeServiceResponse<GetEmployeeDTO>> getSingleEmp(int id);

        Task<EmployeeServiceResponse<List<GetEmployeeDTO>>> AddNewEmp(AddEmployeeDTO newEmp);

        Task<EmployeeServiceResponse<List<GetEmployeeDTO>>> DeleteEmployeeByID(int id);

        Task<EmployeeServiceResponse<GetEmployeeDTO>> UpdateEmployeeInfo(UpdateEmployeeDto updateEmployee);


    }
}
