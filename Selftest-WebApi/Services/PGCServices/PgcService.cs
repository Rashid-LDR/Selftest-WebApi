using AutoMapper;
using Selftest_WebApi.DTO.CollegeDTO;
using Selftest_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Selftest_WebApi.Services.PGCServices
{
    public class PgcService : IPGCServices
    {
        private static List<PGCModel> pGCModels = new List<PGCModel> { new PGCModel()};
        private readonly IMapper _mapper;

        public PgcService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<PGCServiceResponse<List<CollegeDto>>> AddNewCollegeDetails(AddnewCollegeDto newCollege)
        {
            
            PGCServiceResponse<List<CollegeDto>> response = new PGCServiceResponse<List<CollegeDto>>();
            try
            {
                PGCModel colg=_mapper.Map<PGCModel>(newCollege);
                colg.id = pGCModels.Max(x => x.id) + 1;
                pGCModels.Add(colg);
                response.Data = (pGCModels.Select(x => _mapper.Map<CollegeDto>(x))).ToList();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<PGCServiceResponse<List<CollegeDto>>> DeleteCollegeDetailByID(int id)
        {
            PGCServiceResponse<List<CollegeDto>> response = new PGCServiceResponse<List<CollegeDto>>();
            try
            {
                PGCModel colg = pGCModels.FirstOrDefault(x => x.id == id);
                pGCModels.Remove(colg);
                response.Data = (pGCModels.Select(x => _mapper.Map<CollegeDto>(x))).ToList();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;

        }

        public async Task<PGCServiceResponse<List<CollegeDto>>> GetAllCollegesDetails()
        {
            PGCServiceResponse<List<CollegeDto>> response= new PGCServiceResponse<List<CollegeDto>>();
            try
            {

                response.Data =(pGCModels.Select(x=> _mapper.Map<CollegeDto>(x))).ToList();
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response; 
        }

        public async Task<PGCServiceResponse<CollegeDto>> GetSingleCollegeDetail(int id)
        {
            PGCServiceResponse<CollegeDto> response = new PGCServiceResponse<CollegeDto>();
            try
            {
                response.Data =_mapper.Map<CollegeDto>( pGCModels.FirstOrDefault(x => x.id == id));
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<PGCServiceResponse<CollegeDto>> UpdateCollegeDetailBy(UpdateCollegeInfoDto pgc)
        {
            PGCServiceResponse<CollegeDto> response = new PGCServiceResponse<CollegeDto>();
            try
            {
                PGCModel colg = pGCModels.First(x => x.id == pgc.id);
                colg.college_Name = pgc.college_Name;
                colg.college_Address= pgc.college_Address;
                colg.college_City= pgc.college_City;
                colg.college_Region= pgc.college_Region;
                colg.college_Country= pgc.college_Country;
                colg.college_PostalCode= pgc.college_PostalCode;

                response.Data = _mapper.Map<CollegeDto>(colg);

            }catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
