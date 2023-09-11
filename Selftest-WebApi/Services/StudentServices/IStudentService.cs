using Selftest_WebApi.DTO.Student;
using Selftest_WebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Selftest_WebApi.Services.StudentServices
{
    public interface IStudentService
    {
        public Task<StudentServiceResponse<List<StudentDTO>>> GetAllStudents();

        public Task<StudentServiceResponse<StudentDTO>> GetStudentById(int id);

        public Task<StudentServiceResponse<List<StudentDTO>>> AddNewStudent(AddStudentDTO student);

        public Task<StudentServiceResponse<StudentDTO>> UpdateStudentData(UpdataStudentDTO updatestudent);

        public Task<StudentServiceResponse<List<StudentDTO>>> DeleteStudentData(int id);

    }
}
