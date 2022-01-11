using ExemploRelacionamentoEntity.Domain.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExemploRelacionamentoEntity.Domain.Interface
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetAll();
        Task<Cliente> GetById(int id);
        Task<Cliente> Add(Cliente cliente);
        Task<Cliente> Update(Cliente cliente);
        Task<Cliente> Remove(int id);
    }
}
