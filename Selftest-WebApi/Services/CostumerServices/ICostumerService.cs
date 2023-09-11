using Selftest_WebApi.DTO.CostumerDTO;
using Selftest_WebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Selftest_WebApi.Services.CostumerServices
{
    public interface ICostumerService
    {
        public Task<CostumerServiceResponse<List<CostumerDto>>> GetAllCostumers();

        public Task<CostumerServiceResponse<CostumerDto>> GetCostumersById(int Id);

        public Task<CostumerServiceResponse<List<CostumerDto>>> AddCostumer(AddCostumerDto AddnewCostumer);

        public Task<CostumerServiceResponse<CostumerDto>> UpdateCostumer(UpdateCostumerDto UpdateCostumer);

        public Task<CostumerServiceResponse<List<CostumerDto>>> DeleteCostumerbyID(int CostumerID);


    }
}
