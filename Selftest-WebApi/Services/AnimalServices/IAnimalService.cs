using Selftest_WebApi.DTO.AnimalDTO;
using Selftest_WebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Selftest_WebApi.Services.AnimalServices
{
    public interface IAnimalService
    {
        Task<AnimalServiceResponse<List<GetAnimalDTO>>> getAnimals();

        Task<AnimalServiceResponse<GetAnimalDTO>> getAnimalByID(int id);

        Task<AnimalServiceResponse<List<GetAnimalDTO>>> deleteAnimalByID(int id);

        Task<AnimalServiceResponse<GetAnimalDTO>> UpdateAnimal(UpdateAnimalDTO updateAnimalinfo);

        Task<AnimalServiceResponse<List<GetAnimalDTO>>> AddNewAnimal(AddAnimalDTO model);
    }
}
