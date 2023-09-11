using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Selftest_WebApi.Data;
using Selftest_WebApi.DTO.PlantsDTO;
using Selftest_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Selftest_WebApi.Services.PlantsServices
{
    public class PlantsService : IPlantsService
    {
        private static List<PlantsModel> plants = new List<PlantsModel>
        {
            new PlantsModel()
        };
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public PlantsService(IMapper mapper,DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<PlantsServiceResponse<List<PlantsDtos>>> AddNewPlantsInfo(AddPlantsinfoDto newPlantInfo)
        {
            PlantsServiceResponse<List<PlantsDtos>> serviceresponse = new PlantsServiceResponse<List<PlantsDtos>>();
            try
            {
                PlantsModel plant = _mapper.Map<PlantsModel>(newPlantInfo);
                //plant.id = plants.Max(x => x.id) + 1;
                //plants.Add(plant);

                await _context.Plants.AddAsync(plant);
                await _context.SaveChangesAsync();
                serviceresponse.Data = (_context.Plants.Select(x => _mapper.Map<PlantsDtos>(x))).ToList();
            }
            catch (Exception ex)
            {
                serviceresponse.Success = false;
                serviceresponse.Message = ex.Message;
            }
            return serviceresponse;
        }

        public async Task<PlantsServiceResponse<List<PlantsDtos>>> DeletePlantsInfo(int id)
        {
            PlantsServiceResponse<List<PlantsDtos>> serviceresponse = new PlantsServiceResponse<List<PlantsDtos>>();
            try
            {
                PlantsModel plant =await _context.Plants.FirstOrDefaultAsync(x => x.id == id);
                _context.Plants.Remove(plant);
                await _context.SaveChangesAsync();
                serviceresponse.Data = (_context.Plants.Select(x => _mapper.Map<PlantsDtos>(x))).ToList();
            }
            catch (Exception ex)
            {
                serviceresponse.Success = false;
                serviceresponse.Message = ex.Message;
            }
            return serviceresponse;
        }

        public async Task<PlantsServiceResponse<List<PlantsDtos>>> GetAllPlantsInfo()
        {

            PlantsServiceResponse<List<PlantsDtos>> serviceresponse = new PlantsServiceResponse<List<PlantsDtos>>();
            try
            {
                List<PlantsModel> dbcotextplant = await _context.Plants.ToListAsync();
                serviceresponse.Data = (dbcotextplant.Select(x => _mapper.Map<PlantsDtos>(x))).ToList();
            }
            catch (Exception ex)
            {
                serviceresponse.Success = false;
                serviceresponse.Message = ex.Message;
            }
            return serviceresponse;
        }

        public async Task<PlantsServiceResponse<PlantsDtos>> GetSinglePlantInfo(int id)
        {
            PlantsServiceResponse<PlantsDtos> serviceresponse = new PlantsServiceResponse<PlantsDtos>();
            try
            {
                PlantsModel dbcontextplant=await _context.Plants.FirstOrDefaultAsync(x => x.id == id);
                serviceresponse.Data = _mapper.Map<PlantsDtos>(dbcontextplant);
            }
            catch (Exception ex)
            {
                serviceresponse.Success = false;
                serviceresponse.Message = ex.Message;
            }
            return serviceresponse;
        }

        public async Task<PlantsServiceResponse<PlantsDtos>> UpdatePlantInfo(UpdatePlandInfoDtos updateplantinfo)
        {
            PlantsServiceResponse<PlantsDtos> serviceresponse = new PlantsServiceResponse<PlantsDtos>();
            try
            {
                PlantsModel plant =await _context.Plants.FirstAsync(x => x.id == updateplantinfo.id);
                plant.name = updateplantinfo.name;
                plant.height = updateplantinfo.height;
                _context.Plants.Update(plant);
                await _context.SaveChangesAsync();
                serviceresponse.Data=_mapper.Map<PlantsDtos>(plant);            
            }
            catch (Exception ex)
            {
                serviceresponse.Success = false;
                serviceresponse.Message = ex.Message;
            }
            return serviceresponse;

        }
    }
}
