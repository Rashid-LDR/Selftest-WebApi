using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Selftest_WebApi.Data;
using Selftest_WebApi.DTO.CostumerDTO;
using Selftest_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Selftest_WebApi.Services.CostumerServices
{
    public class CostumerService : ICostumerService
    {
        private static List<CostumerModel> costumers = new List<CostumerModel> { new CostumerModel()};
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public CostumerService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<CostumerServiceResponse<List<CostumerDto>>> AddCostumer(AddCostumerDto AddnewCostumer)
        {
            CostumerServiceResponse<List<CostumerDto>> costumerresponse= new CostumerServiceResponse<List<CostumerDto>>(); 
            try
            {
                CostumerModel costumer = _mapper.Map<CostumerModel>(AddnewCostumer);
                //costumer.id = costumers.Max(x => x.id) + 1;
                //costumers.Add(costumer);
                await _context.Costumers.AddAsync(costumer);
                await _context.SaveChangesAsync();

                costumerresponse.Data = (_context.Costumers.Select(x => _mapper.Map<CostumerDto>(x))).ToList(); 
            }
            catch(Exception ex)
            {
                costumerresponse.Success = false;
                costumerresponse.Message = ex.Message;
            }
            return costumerresponse;

        }

        public async Task<CostumerServiceResponse<List<CostumerDto>>> DeleteCostumerbyID(int CostumerID)
        {
            CostumerServiceResponse<List<CostumerDto>> costumerresponse = new CostumerServiceResponse<List<CostumerDto>>();
            try
            {
                CostumerModel costumer=await _context.Costumers.FirstAsync(x => x.id==CostumerID);
                _context.Costumers.Remove(costumer);
                await _context.SaveChangesAsync();
                costumerresponse.Data = (_context.Costumers.Select(x => _mapper.Map<CostumerDto>(x))).ToList();

            }
            catch (Exception ex)
            {
                costumerresponse.Success = false;
                costumerresponse.Message = ex.Message;
            }
            return costumerresponse;

        }

        public async Task<CostumerServiceResponse<List<CostumerDto>>> GetAllCostumers()
        {
            CostumerServiceResponse<List<CostumerDto>> costumerresponse = new CostumerServiceResponse<List<CostumerDto>>();
            try
            {
                List<CostumerModel> dbcontext = await _context.Costumers.ToListAsync();
                costumerresponse.Data = (dbcontext.Select(x => _mapper.Map<CostumerDto>(x))).ToList();
                
            }
            catch (Exception ex)
            {
                costumerresponse.Success = false;
                costumerresponse.Message = ex.Message;
            }
            return costumerresponse;
        }

        public async Task<CostumerServiceResponse<CostumerDto>> GetCostumersById(int Id)
        {
            CostumerServiceResponse<CostumerDto> costumerresponse = new CostumerServiceResponse<CostumerDto>();
            try
            {
                CostumerModel dbcontex=await _context.Costumers.FirstOrDefaultAsync(x => x.id == Id);
                costumerresponse.Data =_mapper.Map<CostumerDto>(dbcontex);
            }
            catch (Exception ex)
            {
                costumerresponse.Success = false;
                costumerresponse.Message = ex.Message;
            }
            return costumerresponse;
        }

        public async Task<CostumerServiceResponse<CostumerDto>> UpdateCostumer(UpdateCostumerDto UpdateCostumer)
        {
            CostumerServiceResponse<CostumerDto> costumerresponse = new CostumerServiceResponse<CostumerDto>();
            try
            {
                CostumerModel costumer = await _context.Costumers.FirstOrDefaultAsync(x => x.id == UpdateCostumer.id);
                costumer.name=UpdateCostumer.name;
                costumer.costumerContect = UpdateCostumer.costumerContect;
                costumer.costumerAddress = UpdateCostumer.costumerAddress;
                costumer.costumerEmail = UpdateCostumer.costumerEmail;

                _context.Costumers.Update(costumer);
                await _context.SaveChangesAsync();
                

                costumerresponse.Data = _mapper.Map<CostumerDto>(costumer);
            }
            catch (Exception ex)
            {
                costumerresponse.Success = false;
                costumerresponse.Message = ex.Message;
            }
            return costumerresponse;
        }
    }
}
