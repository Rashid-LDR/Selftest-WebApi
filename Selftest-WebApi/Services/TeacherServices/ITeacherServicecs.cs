using Selftest_WebApi.DTO.TeacherDtos;
using Selftest_WebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Selftest_WebApi.Services.TeacherServices
{
    public interface ITeacherServicecs
    {
        public Task<TeacherServiceResponse<List<TeacherDTO>>> GetAllTeachers();

        public Task<TeacherServiceResponse<List<TeacherDTO>>> DeleteTeacherRecordByID(int id);

        public Task<TeacherServiceResponse<List<TeacherDTO>>> AddNewTeacher(AddNewTeacherDTO newteacher);

        public Task<TeacherServiceResponse<TeacherDTO>> GetTeacherById(int id);

        public Task<TeacherServiceResponse<TeacherDTO>> UpdateTeacherById(UpdateTeacherRecordDTO updateacher);
    }
}
