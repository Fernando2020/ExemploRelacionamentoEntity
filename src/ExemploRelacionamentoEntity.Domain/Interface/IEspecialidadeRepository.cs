using ExemploRelacionamentoEntity.Domain.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExemploRelacionamentoEntity.Domain.Interface
{
    public interface IEspecialidadeRepository
    {
        Task<IEnumerable<Especialidade>> GetAllAsync();
        Task<Especialidade> GetByIdAsync(int id);
        Task<Especialidade> AddAsync(Especialidade especialidade);
        Task<Especialidade> UpdateAsync(Especialidade especialidade);
        Task<Especialidade> RemoveAsync(int id);
    }
}
