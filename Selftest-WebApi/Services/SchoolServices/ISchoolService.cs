using Selftest_WebApi.DTO.SchoolsDTOs;
using Selftest_WebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Selftest_WebApi.Services.SchoolServices
{
    public interface ISchoolService
    {
        public Task<ServiceResponse<List<SchoolDtos>>> GetallSchollsRecord();

        public Task<ServiceResponse<SchoolDtos>> GetSingleschollsRecordById(int ID);

        public Task<ServiceResponse<List<SchoolDtos>>> AddNewSchoolRecord(AddSchoolDtos Newschool);

        public Task<ServiceResponse<List<SchoolDtos>>> DeleteSchoolRecordByID(int ID);

        public Task<ServiceResponse<SchoolDtos>> UpdateSchoolRecord(UpdateSchoolRecordDto updateschoolRecord);
    }
}
