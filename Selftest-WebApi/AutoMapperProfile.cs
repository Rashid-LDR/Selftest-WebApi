using AutoMapper;
using Selftest_WebApi.DTO;
using Selftest_WebApi.DTO.AnimalDTO;
using Selftest_WebApi.DTO.BookDTO;
using Selftest_WebApi.DTO.CharacterDtos;
using Selftest_WebApi.DTO.ClientDTO;
using Selftest_WebApi.DTO.CollegeDTO;
using Selftest_WebApi.DTO.CostumerDTO;
using Selftest_WebApi.DTO.EmployerDTO;
using Selftest_WebApi.DTO.PlantsDTO;
using Selftest_WebApi.DTO.SchoolsDTOs;
using Selftest_WebApi.DTO.Student;
using Selftest_WebApi.DTO.TeacherDtos;
using Selftest_WebApi.Models;

namespace Selftest_WebApi
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<EmployeeModel, GetEmployeeDTO>();
            CreateMap<AddEmployeeDTO, EmployeeModel>();

            CreateMap<UserModel,GetUserDTO>();
            CreateMap<AddUserDTO, UserModel>();


            CreateMap<ClientModel, GetClientDTO>();
            CreateMap<AddClientDTO, ClientModel>();

            CreateMap<Character, GetCharacterDTO>();
            CreateMap<AddCharacterDTO, Character>();

            CreateMap<BookModel, GetBookDTO>();
            CreateMap<AddBookDTO, BookModel>();

            CreateMap<AnimalModel, GetAnimalDTO>();
            CreateMap<AddAnimalDTO, AnimalModel>();

            CreateMap<StudentModel, StudentDTO>();
            CreateMap<AddStudentDTO, StudentModel>();

            CreateMap<TeacherModel, TeacherDTO>();
            CreateMap<AddNewTeacherDTO, TeacherModel>();

            CreateMap<PlantsModel, PlantsDtos>();
            CreateMap<AddPlantsinfoDto, PlantsModel>();

            CreateMap<SchoolModel, SchoolDtos>();
            CreateMap<AddSchoolDtos, SchoolModel>();

            CreateMap<CostumerModel, CostumerDto>();
            CreateMap<AddCostumerDto,CostumerModel>();

            CreateMap<PGCModel, CollegeDto>();
            CreateMap<AddnewCollegeDto, PGCModel>();
        }
    }
}
