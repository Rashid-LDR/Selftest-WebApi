using Selftest_WebApi.DTO.CollegeDTO;
using Selftest_WebApi.Models;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;

namespace Selftest_WebApi.Services.PGCServices
{
    public interface IPGCServices
    {

        public Task<PGCServiceResponse<List<CollegeDto>>> GetAllCollegesDetails();
        
        public Task<PGCServiceResponse<CollegeDto>> GetSingleCollegeDetail(int id);

        public Task<PGCServiceResponse<List<CollegeDto>>> DeleteCollegeDetailByID(int id);

        public Task<PGCServiceResponse<List<CollegeDto>>> AddNewCollegeDetails(AddnewCollegeDto newCollege);

        public Task<PGCServiceResponse<CollegeDto>> UpdateCollegeDetailBy(UpdateCollegeInfoDto pgc);
    }
}
