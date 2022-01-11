using ExemploRelacionamentoEntity.Domain.Domain;
using ExemploRelacionamentoEntity.Service.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExemploRelacionamentoEntity.Service.Service
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteService _clienteService;
        public ClienteService(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public async Task<Cliente> AddAsync(Cliente cliente)
        {
            return await _clienteService.AddAsync(cliente);
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await _clienteService.GetAllAsync();
        }

        public async Task<Cliente> GetByIdAsync(int id)
        {
            return await _clienteService.GetByIdAsync(id);
        }

        public async Task<Cliente> RemoveAsync(int id)
        {
            return await _clienteService.RemoveAsync(id);
        }

        public async Task<Cliente> UpdateAsync(Cliente cliente)
        {
            return await _clienteService.UpdateAsync(cliente);
        }
    }
}
