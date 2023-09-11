using Selftest_WebApi.DTO.CharacterDtos;
using Selftest_WebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Selftest_WebApi.Services.CharacterServices
{
    public interface ICharacterServices
    {
        Task<CharacterServiceResponse<List<GetCharacterDTO>>> GetCharacters();
        Task<CharacterServiceResponse<GetCharacterDTO>> GetSingleCharacter(int id);

        Task<CharacterServiceResponse<List<GetCharacterDTO>>> AddNewCharacter(AddCharacterDTO newcharacter);
        Task<CharacterServiceResponse<GetCharacterDTO>> UpdateCharacter(UpdateCharacterDTO updatecharacter);

        Task<CharacterServiceResponse<List<GetCharacterDTO>>> DeleteCharacter(int ID);
    }
}
