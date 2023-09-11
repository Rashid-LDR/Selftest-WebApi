  using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Selftest_WebApi.Data;
using Selftest_WebApi.DTO.CharacterDtos;
using Selftest_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Selftest_WebApi.Services.CharacterServices
{
    public class CharacterService : ICharacterServices
    {
        public static List<Character> characters = new List<Character>
        {
            new Character(),
            new Character{ Id=1,Name="Rashid"}
        };

        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public CharacterService(IMapper mapper, DataContext context)
        {
            _mapper=mapper;
            _context = context;
        }
        public async Task<CharacterServiceResponse<List<GetCharacterDTO>>> AddNewCharacter(AddCharacterDTO newcharacter)
        {
            CharacterServiceResponse<List<GetCharacterDTO>> characterservicresponse = new CharacterServiceResponse<List<GetCharacterDTO>>();
            try { 
            Character character=_mapper.Map<Character>(newcharacter);
            //character.Id = characters.Max(c => c.Id) + 1;
            //characters.Add(character)
            await _context.AddAsync(character);
            await _context.SaveChangesAsync();
            characterservicresponse.Data=(_context.Characters.Select(c => _mapper.Map<GetCharacterDTO>(c))).ToList();
            }
            catch (Exception ex)
            {
                characterservicresponse.Success = false;
                characterservicresponse.Message = ex.Message;
            }
            return characterservicresponse;
        }

        public async Task<CharacterServiceResponse<List<GetCharacterDTO>>> DeleteCharacter(int ID)
        {
            CharacterServiceResponse<List<GetCharacterDTO>> characterserviceresponse = new CharacterServiceResponse<List<GetCharacterDTO>>();
            try { 
            Character character =await _context.Characters.FirstAsync(c => c.Id == ID);
            _context.Characters.Remove(character);
                await _context.SaveChangesAsync();
            characterserviceresponse.Data=(_context.Characters.Select(c => _mapper.Map<GetCharacterDTO>(c))).ToList();
            }
            catch (Exception ex) {
                characterserviceresponse.Success = false;
                characterserviceresponse.Message = ex.Message;
            }
            return characterserviceresponse;
        }

        public async Task<CharacterServiceResponse<List<GetCharacterDTO>>> GetCharacters()
        {
            CharacterServiceResponse<List<GetCharacterDTO>> characterservicresponse = new CharacterServiceResponse<List<GetCharacterDTO>>();
            try
            {
                List<Character> dbCharacter = await _context.Characters.ToListAsync();
                characterservicresponse.Data = (dbCharacter.Select(c => _mapper.Map<GetCharacterDTO>(c))).ToList();
            }catch(Exception ex)
            {
                characterservicresponse.Success = false;
                characterservicresponse.Message = ex.Message;
            }
            return characterservicresponse;
        }

        public async Task<CharacterServiceResponse<GetCharacterDTO>> GetSingleCharacter(int id)
        {
            CharacterServiceResponse<GetCharacterDTO> characterservicresponse = new CharacterServiceResponse<GetCharacterDTO>();
            try
            {
            Character dbCharacter= await _context.Characters.FirstOrDefaultAsync(c => c.Id==id);
            characterservicresponse.Data=_mapper.Map<GetCharacterDTO>( dbCharacter);
            }
            catch (Exception ex)
            {
                characterservicresponse.Success = false;
                characterservicresponse.Message = ex.Message;
            }

            return characterservicresponse;
        }

        public async Task<CharacterServiceResponse<GetCharacterDTO>> UpdateCharacter(UpdateCharacterDTO updatecharacter)
        {
            CharacterServiceResponse<GetCharacterDTO> characterrerviceresponse=new CharacterServiceResponse<GetCharacterDTO>();
            try 
            { 
                Character character =await _context.Characters.FirstOrDefaultAsync(c => c.Id == updatecharacter.Id);
                character.Name=updatecharacter.Name;
                character.father=updatecharacter.father;
                character.phone=updatecharacter.phone;  
                character.contact=updatecharacter.contact;

                _context.Characters.Update(character);
                await _context.SaveChangesAsync();

                characterrerviceresponse.Data = _mapper.Map<GetCharacterDTO>(character);
            }
            catch (Exception ex) {
                characterrerviceresponse.Success =false ;
                characterrerviceresponse.Message = ex.Message;
            }

            return characterrerviceresponse;
        }
    }
}
