using Selftest_WebApi.DTO.ClientDTO;
using Selftest_WebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Selftest_WebApi.Services.ClientServices
{
    public interface IClientServices
    {

        Task<ClientServiceResponse<List<GetClientDTO>>> GetClient();
        Task<ClientServiceResponse<GetClientDTO>> GetClientById(int clientId);
        Task<ClientServiceResponse<List<GetClientDTO>>> AddNewClient(AddClientDTO NewClientAdd);
        Task<ClientServiceResponse<GetClientDTO>> UpdateClient(UpdateClientDTO UpdateClientUpdate);

        Task<ClientServiceResponse<List<GetClientDTO>>> DeleteClient(int clientId);
    }
}
