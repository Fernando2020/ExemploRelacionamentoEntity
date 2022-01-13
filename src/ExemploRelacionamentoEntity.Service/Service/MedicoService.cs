using ExemploRelacionamentoEntity.Domain.Domain;
using ExemploRelacionamentoEntity.Domain.Interface;
using ExemploRelacionamentoEntity.Service.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExemploRelacionamentoEntity.Service.Service
{
    public class MedicoService : IMedicoService
    {
        private readonly IMedicoRepository _medicoRepository;
        public MedicoService(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }

        public async Task<Medico> AddAsync(Medico medico)
        {
            return await _medicoRepository.AddAsync(medico);
        }

        public async Task<IEnumerable<Medico>> GetAllAsync()
        {
            return await _medicoRepository.GetAllAsync();
        }

        public async Task<Medico> GetByIdAsync(int id)
        {
            return await _medicoRepository.GetByIdAsync(id);
        }

        public async Task<Medico> RemoveAsync(int id)
        {
            return await _medicoRepository.RemoveAsync(id);
        }

        public async Task<Medico> UpdateAsync(Medico medico)
        {
            return await _medicoRepository.UpdateAsync(medico);
        }
    }
}
