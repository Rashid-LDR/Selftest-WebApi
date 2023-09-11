using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Selftest_WebApi.Data;
using Selftest_WebApi.DTO.SchoolsDTOs;
using Selftest_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Selftest_WebApi.Services.SchoolServices
{
    public class SchoolService : ISchoolService
    {
        private static List<SchoolModel> Schools = new List<SchoolModel> { 
            new SchoolModel()
        };
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public SchoolService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public DataContext Context { get; }

        public async Task<ServiceResponse<List<SchoolDtos>>> AddNewSchoolRecord(AddSchoolDtos Newschool)
        {
            
            ServiceResponse<List<SchoolDtos>> response = new ServiceResponse<List<SchoolDtos>>();
            try
            {
                SchoolModel school = _mapper.Map<SchoolModel>(Newschool);
                //school.Id = Schools.Max(x => x.Id) + 1;
                //Schools.Add(school);
                await _context.Schools.AddAsync(school);
                await _context.SaveChangesAsync();
                response.Data = (_context.Schools.Select(x => _mapper.Map<SchoolDtos>(x))).ToList();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<SchoolDtos>>> DeleteSchoolRecordByID(int ID)
        {
            ServiceResponse<List<SchoolDtos>> response = new ServiceResponse<List<SchoolDtos>>();
            try
            {
                SchoolModel school = Schools.First(x => x.Id == ID);
                Schools.Remove(school);
                response.Data = (Schools.Select(x => _mapper.Map<SchoolDtos>(x))).ToList();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;

        }

        public async Task<ServiceResponse<List<SchoolDtos>>> GetallSchollsRecord()
        {
            ServiceResponse<List<SchoolDtos>> response= new ServiceResponse<List<SchoolDtos>>();
            try
            {
                List<SchoolModel> dbcontext = await _context.Schools.ToListAsync();
                response.Data = (dbcontext.Select(x => _mapper.Map<SchoolDtos>(x))).ToList();

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<SchoolDtos>> GetSingleschollsRecordById(int ID)
        {
            ServiceResponse<SchoolDtos> response = new ServiceResponse<SchoolDtos>();
            try
            {
                SchoolModel dbcontext = await _context.Schools.FirstOrDefaultAsync(x => x.Id == ID);
                response.Data = _mapper.Map<SchoolDtos>(dbcontext);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
            
        }

        public async Task<ServiceResponse<SchoolDtos>> UpdateSchoolRecord(UpdateSchoolRecordDto updateschoolRecord)
        {
            ServiceResponse<SchoolDtos> response = new ServiceResponse<SchoolDtos>();
            try
            {
                SchoolModel school =await _context.Schools.FirstOrDefaultAsync( x => x.Id == updateschoolRecord.Id);
                school.SchoolName = updateschoolRecord.SchoolName;
                school.SchoolType = updateschoolRecord.SchoolType;
                school.SchoolLocation= updateschoolRecord.SchoolLocation;
                school.SchoolStright= updateschoolRecord.SchoolStright;

                _context.Schools.Update(school);
                await _context.SaveChangesAsync();
                response.Data=_mapper.Map<SchoolDtos>(school);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
