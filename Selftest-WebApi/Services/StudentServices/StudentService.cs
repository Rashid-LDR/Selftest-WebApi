using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Selftest_WebApi.Data;
using Selftest_WebApi.DTO.Student;
using Selftest_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Selftest_WebApi.Services.StudentServices
{
    public class StudentService : IStudentService
    {
        private static List<StudentModel> students = new List<StudentModel>
        {
            new StudentModel(),
            new StudentModel{ID= 1,Name="Rashid",FatherName="Sajid" }
        };
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public StudentService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<StudentServiceResponse<List<StudentDTO>>> AddNewStudent(AddStudentDTO student)
        {
            StudentServiceResponse<List<StudentDTO>> Studentserviceresponse = new StudentServiceResponse<List<StudentDTO>>();
            try
            {
                StudentModel std=_mapper.Map<StudentModel>(student);

                await _context.Students.AddAsync(std);
                await _context.SaveChangesAsync();

                Studentserviceresponse.Data = (_context.Students.Select(x => _mapper.Map<StudentDTO>(x))).ToList();
            }
            catch(Exception ex)
            {
                Studentserviceresponse.Success = false;
                Studentserviceresponse.Message = ex.Message;
            }


                return Studentserviceresponse;
        }

        public async Task<StudentServiceResponse<StudentDTO>> GetStudentById(int id)
        {
            StudentServiceResponse<StudentDTO> Studentserviceresponse = new StudentServiceResponse<StudentDTO>();
            try
            {
                StudentModel student = await _context.Students.FirstAsync(x => x.ID == id);
              Studentserviceresponse.Data =_mapper.Map<StudentDTO>(student);
            }
            catch (Exception ex)
            {
                Studentserviceresponse.Success = false;
                Studentserviceresponse.Message = ex.Message;
            }
            return Studentserviceresponse;
        }

        public async Task<StudentServiceResponse<List<StudentDTO>>> GetAllStudents()
        {
            StudentServiceResponse<List<StudentDTO>> Studentserviceresponse = new StudentServiceResponse<List<StudentDTO>>();
            try
            {
                List<StudentModel> std = await _context.Students.ToListAsync();
                Studentserviceresponse.Data = (std.Select(x => _mapper.Map<StudentDTO>(x))).ToList();
            }
            catch (Exception ex)
            {
                Studentserviceresponse.Success = false;
                Studentserviceresponse.Message = ex.Message;
            }
            return Studentserviceresponse;
        }

        public async Task<StudentServiceResponse<StudentDTO>> UpdateStudentData(UpdataStudentDTO updatestudent)
        {
            StudentServiceResponse<StudentDTO> Studentserviceresponse = new StudentServiceResponse<StudentDTO>();
            try
            {
                StudentModel student =await _context.Students.FirstOrDefaultAsync(x => x.ID == updatestudent.ID);
                student.Name = updatestudent.Name;
                student.FatherName = updatestudent.FatherName;
                student.Email = updatestudent.Email;
                student.Address = updatestudent.Address;
                student.Phone = updatestudent.Phone;
                student.City = updatestudent.City;
                student.Gender = updatestudent.Gender;

                _context.Students.Update(student);
                await _context.SaveChangesAsync();

                Studentserviceresponse.Data = _mapper.Map<StudentDTO>(student);

            }
            catch (Exception ex)
            {
                Studentserviceresponse.Success = false;
                Studentserviceresponse.Message = ex.Message;
            }
            return Studentserviceresponse;
        }

        public async Task<StudentServiceResponse<List<StudentDTO>>> DeleteStudentData(int id)
        {
            StudentServiceResponse<List<StudentDTO>> Studentserviceresponse = new StudentServiceResponse<List<StudentDTO>>();
            try
            {
                StudentModel student=await _context.Students.FirstAsync(x => x.ID==id);
                
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();

                Studentserviceresponse.Data = (_context.Students.Select(x => _mapper.Map<StudentDTO>(x))).ToList();
            }
            catch (Exception ex)
            {
                Studentserviceresponse.Success = false;
                Studentserviceresponse.Message = ex.Message;
            }
            return Studentserviceresponse;
        
        }
    }
}
