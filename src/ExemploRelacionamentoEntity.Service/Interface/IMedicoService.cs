using ExemploRelacionamentoEntity.Service.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExemploRelacionamentoEntity.Service.Interface
{
    public interface IMedicoService
    {
        Task<IEnumerable<MedicoDTO>> GetAllAsync();
        Task<MedicoDTO> GetByIdAsync(int id);
        Task<MedicoDTO> AddAsync(MedicoDTO medicoDTO);
        Task<MedicoDTO> UpdateAsync(MedicoDTO medicoDTO);
        Task<MedicoDTO> RemoveAsync(int id);
    }
}
