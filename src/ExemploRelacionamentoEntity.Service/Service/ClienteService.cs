using ExemploRelacionamentoEntity.Domain.Domain;
using ExemploRelacionamentoEntity.Domain.Interface;
using ExemploRelacionamentoEntity.Service.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExemploRelacionamentoEntity.Service.Service
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clientRepository;
        public ClienteService(IClienteRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Cliente> AddAsync(Cliente cliente)
        {
            return await _clientRepository.AddAsync(cliente);
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await _clientRepository.GetAllAsync();
        }

        public async Task<Cliente> GetByIdAsync(int id)
        {
            return await _clientRepository.GetByIdAsync(id);
        }

        public async Task<Cliente> RemoveAsync(int id)
        {
            return await _clientRepository.RemoveAsync(id);
        }

        public async Task<Cliente> UpdateAsync(Cliente cliente)
        {
            return await _clientRepository.UpdateAsync(cliente);
        }
    }
}
