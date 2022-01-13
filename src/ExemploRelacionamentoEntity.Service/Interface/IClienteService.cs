using ExemploRelacionamentoEntity.Service.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExemploRelacionamentoEntity.Service.Interface
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteDTO>> GetAllAsync();
        Task<ClienteDTO> GetByIdAsync(int id);
        Task<ClienteDTO> AddAsync(ClienteDTO clienteDTO);
        Task<ClienteDTO> UpdateAsync(ClienteDTO clienteDTO);
        Task<ClienteDTO> RemoveAsync(int id);
    }
}
