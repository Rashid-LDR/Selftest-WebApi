  using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Selftest_WebApi.Data;
using Selftest_WebApi.DTO.AnimalDTO;
using Selftest_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Selftest_WebApi.Services.AnimalServices
{
    public class AnimalService : IAnimalService
    {
       /* private static List<AnimalModel> animals = new List<AnimalModel>
        {
            new AnimalModel(),
            new AnimalModel{ID=1,Name="Cat",height=1.5,Color="White"}
        };*/

        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public AnimalService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<AnimalServiceResponse<List<GetAnimalDTO>>> AddNewAnimal(AddAnimalDTO model)
        {
            AnimalServiceResponse<List<GetAnimalDTO>> response = new AnimalServiceResponse<List<GetAnimalDTO>>();
            try
            {
                AnimalModel animal=_mapper.Map<AnimalModel>(model);
                //animal.ID = animals.Max(a => a.ID) + 1;
                //animals.Add(animal);
                await _context.Animals.AddAsync(animal);
                await _context.SaveChangesAsync();


                response.Data = (_context.Animals.Select(c => _mapper.Map<GetAnimalDTO>(c))).ToList();
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message=ex.Message;    
            }
            return response;
        }

        public async Task<AnimalServiceResponse<List<GetAnimalDTO>>> deleteAnimalByID(int id)
        {
            AnimalServiceResponse<List<GetAnimalDTO>> response = new AnimalServiceResponse<List<GetAnimalDTO>>();
            try
            {
                AnimalModel animal = await _context.Animals.FirstAsync(c => c.ID == id);

                _context.Animals.Remove(animal);
                await _context.SaveChangesAsync();

                response.Data = (_context.Animals.Select(x => _mapper.Map<GetAnimalDTO>(x))).ToList();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<AnimalServiceResponse<GetAnimalDTO>> getAnimalByID(int id)
        {
            AnimalServiceResponse<GetAnimalDTO> response = new AnimalServiceResponse<GetAnimalDTO>();
            try
            { 
                AnimalModel dbcontext=await _context.Animals.FirstOrDefaultAsync(x => x.ID == id);
                response.Data =_mapper.Map<GetAnimalDTO>(dbcontext);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<AnimalServiceResponse<List<GetAnimalDTO>>> getAnimals()
        {
            AnimalServiceResponse<List<GetAnimalDTO>> response=new AnimalServiceResponse<List<GetAnimalDTO>>();
            try
            {
                List<AnimalModel> dbcontextanimal = await _context.Animals.ToListAsync();
                response.Data = (dbcontextanimal.Select(x => _mapper.Map<GetAnimalDTO>(x))).ToList();
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
        public async Task<AnimalServiceResponse<GetAnimalDTO>> UpdateAnimal(UpdateAnimalDTO updateAnimalinfo)
        {
            AnimalServiceResponse<GetAnimalDTO> response = new AnimalServiceResponse<GetAnimalDTO>();
            try
            {
                AnimalModel animal = await _context.Animals.FirstOrDefaultAsync(x => x.ID == updateAnimalinfo.ID);
                animal.Name = updateAnimalinfo.Name;
                animal.Color = updateAnimalinfo.Color;
                animal.height = updateAnimalinfo.height;

                _context.Animals.Update(animal);
                await _context.SaveChangesAsync();

                response.Data = _mapper.Map<GetAnimalDTO>(animal);
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
