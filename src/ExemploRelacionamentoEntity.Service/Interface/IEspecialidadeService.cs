using ExemploRelacionamentoEntity.Service.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExemploRelacionamentoEntity.Service.Interface
{
    public interface IEspecialidadeService
    {
        Task<IEnumerable<EspecialidadeDTO>> GetAllAsync();
        Task<EspecialidadeDTO> GetByIdAsync(int id);
        Task<EspecialidadeDTO> AddAsync(EspecialidadeDTO especialidadeDTO);
        Task<EspecialidadeDTO> UpdateAsync(EspecialidadeDTO especialidadeDTO);
        Task<EspecialidadeDTO> RemoveAsync(int id);
    }
}
