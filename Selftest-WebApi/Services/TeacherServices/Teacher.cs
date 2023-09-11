using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Selftest_WebApi.Data;
using Selftest_WebApi.DTO.TeacherDtos;
using Selftest_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Selftest_WebApi.Services.TeacherServices
{
    public class Teacher : ITeacherServicecs
    {
        private static List<TeacherModel> teachers = new List<TeacherModel>
        {
            new TeacherModel{Id=1, TeacherName="Saad Khalil",TeacherContact="305987632",TeacherSubject="Bi0logy",Sallary="40k"}
        };
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public Teacher(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<TeacherServiceResponse<List<TeacherDTO>>> AddNewTeacher(AddNewTeacherDTO newteacher)
        {
            TeacherServiceResponse<List<TeacherDTO>> teacherserviceresponse = new TeacherServiceResponse<List<TeacherDTO>>();
            try
            {
                TeacherModel teacher=_mapper.Map<TeacherModel>(newteacher);
                //teacher.Id = teachers.Max(x => x.Id) + 1;
                // teachers.Add(teacher);
                await _context.Teachers.AddAsync(teacher);
                await _context.SaveChangesAsync();

                teacherserviceresponse.Data = (_context.Teachers.Select(x => _mapper.Map<TeacherDTO>(x))).ToList();
            }catch(Exception ex)
            {
                teacherserviceresponse.Success = false;
                teacherserviceresponse.Message=ex.Message;
            }

            return teacherserviceresponse;
        }

        public async Task<TeacherServiceResponse<List<TeacherDTO>>> GetAllTeachers()
        {
            TeacherServiceResponse<List<TeacherDTO>> teacherserviceresponse = new TeacherServiceResponse<List<TeacherDTO>>();
            try
            {
                List<TeacherModel> dbcontext = await _context.Teachers.ToListAsync();
                teacherserviceresponse.Data = (dbcontext.Select(x => _mapper.Map<TeacherDTO>(x))).ToList(); ;
            }
            catch (Exception ex)
            {
                teacherserviceresponse.Success = false;
                teacherserviceresponse.Message = ex.Message;
            }

            return teacherserviceresponse;
        }

        public async Task<TeacherServiceResponse<TeacherDTO>> GetTeacherById(int id)
        {
            TeacherServiceResponse<TeacherDTO> teacherserviceresponse = new TeacherServiceResponse<TeacherDTO>();
            try
            {
                TeacherModel dbcontext = await _context.Teachers.FirstOrDefaultAsync(x => x.Id == id);
                teacherserviceresponse.Data=_mapper.Map<TeacherDTO>(dbcontext);

            }
            catch (Exception ex)
            {
                teacherserviceresponse.Success = false;
                teacherserviceresponse.Message = ex.Message;
            }

            return teacherserviceresponse;

        }

        public async Task<TeacherServiceResponse<TeacherDTO>> UpdateTeacherById(UpdateTeacherRecordDTO updateacher)
        {
            TeacherServiceResponse<TeacherDTO> teacherserviceresponse = new TeacherServiceResponse<TeacherDTO>();
            try
            {
                TeacherModel teacher= await _context.Teachers.FirstOrDefaultAsync(x => x.Id == updateacher.Id);
                teacher.TeacherName = updateacher.TeacherName;
                teacher.TeacherSubject=updateacher.TeacherSubject;
                teacher.Sallary = updateacher.Sallary;
                teacher.TeacherContact = updateacher.TeacherContact;

                _context.Teachers.Update(teacher);
                await _context.SaveChangesAsync();

                teacherserviceresponse.Data = _mapper.Map<TeacherDTO>(teacher);
            }
            catch (Exception ex)
            {
                teacherserviceresponse.Success = false;
                teacherserviceresponse.Message = ex.Message;
            }

            return teacherserviceresponse;
        }

        public async Task<TeacherServiceResponse<List<TeacherDTO>>> DeleteTeacherRecordByID(int id)
        {
            TeacherServiceResponse<List<TeacherDTO>> teacherserviceresponse = new TeacherServiceResponse<List<TeacherDTO>>();
            try
            {
                TeacherModel teacher = await _context.Teachers.FirstAsync(x => x.Id == id);
                _context.Teachers.Remove(teacher);
                await _context.SaveChangesAsync();
                teacherserviceresponse.Data = (_context.Teachers.Select(x => _mapper.Map<TeacherDTO>(x))).ToList();
            }
            catch (Exception ex)
            {
                teacherserviceresponse.Success = false;
                teacherserviceresponse.Message = ex.Message;
            }

            return teacherserviceresponse;

        }
    }
}
