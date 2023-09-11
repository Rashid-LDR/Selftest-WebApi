using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Selftest_WebApi.Data;
using Selftest_WebApi.DTO.ClientDTO;
using Selftest_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Selftest_WebApi.Services.ClientServices
{
    public class ClientServices : IClientServices
    {
        private List<ClientModel> clients = new List<ClientModel>
        {
            new ClientModel ()
        };

        private readonly IMapper _map;
        private readonly DataContext _context;

        public ClientServices(IMapper map,DataContext context)
        {
            _map=map;
            _context = context;
        }

        public async Task<ClientServiceResponse<List<GetClientDTO>>> AddNewClient(AddClientDTO NewClientAdd)
        {
            ClientServiceResponse<List<GetClientDTO>> clientserviceresponse = new ClientServiceResponse<List<GetClientDTO>>();
            try
            {
                ClientModel nClient = _map.Map<ClientModel>(NewClientAdd);
                //nClient.id = clients.Max(c => c.id) + 1;
                //clients.Add(nClient);
                await _context.Clients.AddAsync(nClient);
                await _context.SaveChangesAsync();

                clientserviceresponse.Data = (_context.Clients.Select(c => _map.Map<GetClientDTO>(c))).ToList();
            } 
            catch(Exception e)
            {
                clientserviceresponse.Success = false;
                clientserviceresponse.Message = e.Message;
            }
            return clientserviceresponse;
        }

        public async Task<ClientServiceResponse<List<GetClientDTO>>> GetClient()
        {
            ClientServiceResponse<List<GetClientDTO>> clientserviceresponse = new ClientServiceResponse<List<GetClientDTO>>();
            try
            {
                List<ClientModel> dbcontext = await _context.Clients.ToListAsync();
                clientserviceresponse.Data = (dbcontext.Select(c => _map.Map<GetClientDTO>(c))).ToList(); 

            }
            catch(Exception e)
            {
                clientserviceresponse.Success = false;
                clientserviceresponse.Message = e.Message;
            }
            return clientserviceresponse;
        }

        public async Task<ClientServiceResponse<GetClientDTO>> GetClientById(int clientId)
        {
            ClientServiceResponse<GetClientDTO> clientserviceresponse = new ClientServiceResponse<GetClientDTO>();
            try
            {
                ClientModel client = await _context.Clients.FirstOrDefaultAsync(c => c.id == clientId);
                clientserviceresponse.Data=_map.Map<GetClientDTO>(client);
            }
            catch(Exception e)
            {
                clientserviceresponse.Success = false;
                clientserviceresponse.Message = e.Message;
            }
            return clientserviceresponse;
        }

        public async Task<ClientServiceResponse<GetClientDTO>> UpdateClient(UpdateClientDTO UpdateClientUpdate)
        {
            ClientServiceResponse<GetClientDTO> clientServiceResponse = new ClientServiceResponse<GetClientDTO>();
            try
            {
                ClientModel client =await _context.Clients.FirstAsync(c => c.id == UpdateClientUpdate.id);
                client.name = UpdateClientUpdate.name;
                client.email = UpdateClientUpdate.email;
                client.phone = UpdateClientUpdate.phone;
                client.fax = UpdateClientUpdate.fax;

                _context.Clients.Update(client);
                await _context.SaveChangesAsync();

                clientServiceResponse.Data = _map.Map<GetClientDTO>(client);
            }
            catch (Exception ex)
            {
                clientServiceResponse.Success = false;
                clientServiceResponse.Message = ex.Message;
            }
            return clientServiceResponse;
        }

        public async Task<ClientServiceResponse<List<GetClientDTO>>> DeleteClient(int clientId)
        {
           ClientServiceResponse<List<GetClientDTO>> clientServiceResponse = new ClientServiceResponse<List<GetClientDTO>>();
            try
            {
                ClientModel client =await _context.Clients.FirstAsync(x => x.id == clientId);
                _context.Clients.Remove(client);
                await _context.SaveChangesAsync();

                clientServiceResponse.Data =(_context.Clients.Select(x => _map.Map<GetClientDTO>(x))).ToList();
            }
            catch(Exception e)
            {
                clientServiceResponse.Success = false;
                clientServiceResponse.Message = e.Message;
            }
            return clientServiceResponse;
        }
    }
}
