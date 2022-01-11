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

        public async Task<Cliente> Add(Cliente cliente)
        {
            return await _clienteService.Add(cliente);
        }

        public async Task<IEnumerable<Cliente>> GetAll()
        {
            return await _clienteService.GetAll();
        }

        public async Task<Cliente> GetById(int id)
        {
            return await _clienteService.GetById(id);
        }

        public async Task<Cliente> Remove(int id)
        {
            return await _clienteService.Remove(id);
        }

        public async Task<Cliente> Update(Cliente cliente)
        {
            return await _clienteService.Update(cliente);
        }
    }
}
