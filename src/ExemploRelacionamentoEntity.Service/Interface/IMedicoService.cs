using ExemploRelacionamentoEntity.Domain.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExemploRelacionamentoEntity.Service.Interface
{
    public interface IMedicoService
    {
        Task<IEnumerable<Medico>> GetAllAsync();
        Task<Medico> GetByIdAsync(int id);
        Task<Medico> AddAsync(Medico medico);
        Task<Medico> UpdateAsync(Medico medico);
        Task<Medico> RemoveAsync(int id);
    }
}
