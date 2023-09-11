using Selftest_WebApi.DTO.PlantsDTO;
using Selftest_WebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Selftest_WebApi.Services.PlantsServices
{
    public interface IPlantsService
    {

        public Task<PlantsServiceResponse<List<PlantsDtos>>> GetAllPlantsInfo();

        public Task<PlantsServiceResponse<List<PlantsDtos>>> AddNewPlantsInfo(AddPlantsinfoDto newPlantInfo);

        public Task<PlantsServiceResponse<List<PlantsDtos>>> DeletePlantsInfo(int id);

        public Task<PlantsServiceResponse<PlantsDtos>> GetSinglePlantInfo(int id);

        public Task<PlantsServiceResponse<PlantsDtos>> UpdatePlantInfo(UpdatePlandInfoDtos updateplantinfo);

    }
}
