using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Selftest_WebApi.Data;
using Selftest_WebApi.DTO;
using Selftest_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Selftest_WebApi.Services.UserServices
{
    public class User : IUserServices
    {
        private static List<UserModel> user = new List<UserModel>
        {
            new UserModel(),
            new UserModel
            {
                id=1,
                name="Rashid"
            }
        };
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public User(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<UserServiceResponse<List<GetUserDTO>>> Adduser(AddUserDTO newuser)
        {
            UserServiceResponse<List<GetUserDTO>> userserviceresponse = new UserServiceResponse<List<GetUserDTO>>();
            try
            {
                UserModel u = _mapper.Map<UserModel>(newuser);
                //u.id = user.Max(c => c.id) + 1;
                //user.Add(u);
                await _context.Users.AddAsync(u);
                await _context.SaveChangesAsync();
                userserviceresponse.Data = (_context.Users.Select(c => _mapper.Map<GetUserDTO>(c))).ToList();
            }
            catch(Exception ex)
            {
                userserviceresponse.Success = false;
                userserviceresponse.Message = ex.Message;
            }
            return userserviceresponse;
        }

        public async Task<UserServiceResponse<List<GetUserDTO>>> GetUser()
        {
            UserServiceResponse<List<GetUserDTO>> userserviceresponse = new UserServiceResponse<List<GetUserDTO>>();
            try
            {
                List<UserModel> dbUser = await _context.Users.ToListAsync();
                userserviceresponse.Data = (dbUser.Select(c => _mapper.Map<GetUserDTO>(c))).ToList();
            }
            catch (Exception ex)
            {
                userserviceresponse.Success = false;
                userserviceresponse.Message = ex.Message;
            }

            return userserviceresponse;
        }

        public async Task<UserServiceResponse<GetUserDTO>> GetUserById(int id)
        {
            UserServiceResponse<GetUserDTO> userserviceResponse = new UserServiceResponse<GetUserDTO>();
            try
            {
                UserModel dbUser = await _context.Users.FirstOrDefaultAsync(cid => cid.id == id);
                userserviceResponse.Data =_mapper.Map<GetUserDTO>(dbUser);
            }
            catch (Exception ex)
            {
                userserviceResponse.Success = false;
                userserviceResponse.Message = ex.Message;
            }


            return (userserviceResponse);
        }

        
    }
}
