using AutoMapper;
using ExemploRelacionamentoEntity.Domain.Domain;
using ExemploRelacionamentoEntity.Domain.Interface;
using ExemploRelacionamentoEntity.Service.DTO;
using ExemploRelacionamentoEntity.Service.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExemploRelacionamentoEntity.Service.Service
{
    public class EspecialidadeService : IEspecialidadeService
    {
        private readonly IMapper _mapper;
        private readonly IEspecialidadeRepository _especialidadeRepository;
        public EspecialidadeService(IMapper mapper, IEspecialidadeRepository especialidadeRepository)
        {
            _mapper = mapper;
            _especialidadeRepository = especialidadeRepository;
        }

        public async Task<EspecialidadeDTO> AddAsync(EspecialidadeDTO especialidadeDTO)
        {
            var especialidade = _mapper.Map<Especialidade>(especialidadeDTO);
            return _mapper.Map<EspecialidadeDTO>(await _especialidadeRepository.AddAsync(especialidade));
        }

        public async Task<IEnumerable<EspecialidadeDTO>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<EspecialidadeDTO>>(await _especialidadeRepository.GetAllAsync());
        }

        public async Task<EspecialidadeDTO> GetByIdAsync(int id)
        {
            return _mapper.Map<EspecialidadeDTO>(await _especialidadeRepository.GetByIdAsync(id));
        }

        public async Task<EspecialidadeDTO> RemoveAsync(int id)
        {
            return _mapper.Map<EspecialidadeDTO>(await _especialidadeRepository.RemoveAsync(id));
        }

        public async Task<EspecialidadeDTO> UpdateAsync(EspecialidadeDTO especialidadeDTO)
        {
            var especialidade = _mapper.Map<Especialidade>(especialidadeDTO);
            return _mapper.Map<EspecialidadeDTO>(await _especialidadeRepository.UpdateAsync(especialidade));
        }
    }
}
