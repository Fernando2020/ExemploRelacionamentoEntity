using AutoMapper;
using ExemploRelacionamentoEntity.Domain.Domain;
using ExemploRelacionamentoEntity.Domain.Interface;
using ExemploRelacionamentoEntity.Service.DTO;
using ExemploRelacionamentoEntity.Service.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExemploRelacionamentoEntity.Service.Service
{
    public class MedicoService : IMedicoService
    {
        private readonly IMapper _mapper;
        private readonly IMedicoRepository _medicoRepository;
        public MedicoService(IMapper mapper, IMedicoRepository medicoRepository)
        {
            _mapper = mapper;
            _medicoRepository = medicoRepository;
        }

        public async Task<MedicoDTO> AddAsync(MedicoDTO medicoDTO)
        {
            var medico = _mapper.Map<Medico>(medicoDTO);
            return _mapper.Map<MedicoDTO>(await _medicoRepository.AddAsync(medico));
        }

        public async Task<IEnumerable<MedicoDTO>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<MedicoDTO>>(await _medicoRepository.GetAllAsync());
        }

        public async Task<MedicoDTO> GetByIdAsync(int id)
        {
            return _mapper.Map<MedicoDTO>(await _medicoRepository.GetByIdAsync(id));
        }

        public async Task<MedicoDTO> RemoveAsync(int id)
        {
            return _mapper.Map<MedicoDTO>(await _medicoRepository.RemoveAsync(id));
        }

        public async Task<MedicoDTO> UpdateAsync(MedicoDTO medicoDTO)
        {
            var medico = _mapper.Map<Medico>(medicoDTO);
            return _mapper.Map<MedicoDTO>(await _medicoRepository.UpdateAsync(medico));
        }
    }
}
