using AutoMapper;
using ExemploRelacionamentoEntity.Domain.Domain;
using ExemploRelacionamentoEntity.Domain.Interface;
using ExemploRelacionamentoEntity.Service.DTO;
using ExemploRelacionamentoEntity.Service.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExemploRelacionamentoEntity.Service.Service
{
    public class ClienteService : IClienteService
    {
        private readonly IMapper _mapper;
        private readonly IClienteRepository _clientRepository;
        public ClienteService(IMapper mapper, IClienteRepository clientRepository)
        {
            _mapper = mapper;
            _clientRepository = clientRepository;
        }

        public async Task<ClienteDTO> AddAsync(ClienteDTO clienteDTO)
        {
            var cliente = _mapper.Map<Cliente>(clienteDTO);
            return _mapper.Map<ClienteDTO>(await _clientRepository.AddAsync(cliente));
        }

        public async Task<IEnumerable<ClienteDTO>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<ClienteDTO>>(await _clientRepository.GetAllAsync());
        }

        public async Task<ClienteDTO> GetByIdAsync(int id)
        {
            return _mapper.Map<ClienteDTO>(await _clientRepository.GetByIdAsync(id));
        }

        public async Task<ClienteDTO> RemoveAsync(int id)
        {
            return _mapper.Map<ClienteDTO>(await _clientRepository.RemoveAsync(id));
        }

        public async Task<ClienteDTO> UpdateAsync(ClienteDTO clienteDTO)
        {
            var cliente = _mapper.Map<Cliente>(clienteDTO);
            return _mapper.Map<ClienteDTO>(await _clientRepository.UpdateAsync(cliente));
        }
    }
}
