using Selftest_WebApi.DTO;
using Selftest_WebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Selftest_WebApi.Services.UserServices
{
    public interface IUserServices
    {

        public Task<UserServiceResponse<List<GetUserDTO>>> GetUser();

        public Task<UserServiceResponse<GetUserDTO>> GetUserById(int id);

        public Task<UserServiceResponse<List<GetUserDTO>>> Adduser(AddUserDTO newuser);

    }
}
