using ExemploRelacionamentoEntity.Data.Context;
using ExemploRelacionamentoEntity.Domain.Domain;
using ExemploRelacionamentoEntity.Domain.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExemploRelacionamentoEntity.Data.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ExemploContext _context;
        public ClienteRepository(ExemploContext context)
        {
            _context = context;
        }

        public async Task<Cliente> Add(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<IEnumerable<Cliente>> GetAll()
        {
            return await _context.Clientes
                .Include(x => x.Endereco)
                .Include(x => x.Telefones)
                .AsNoTracking().ToListAsync();
        }

        public async Task<Cliente> GetById(int id)
        {
            return await _context.Clientes
                .Include(x => x.Endereco)
                .Include(x => x.Telefones)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Cliente> Remove(int id)
        {
            var clienteConsultado = await _context.Clientes.FindAsync(id);
            if(clienteConsultado == null)
            {
                return null;
            }

            var clienteRemovido = _context.Clientes.Remove(clienteConsultado);
            await _context.SaveChangesAsync();
            return clienteRemovido.Entity;
        }

        public async Task<Cliente> Update(Cliente cliente)
        {
            var clienteConsultado = await _context.Clientes
                .Include(x => x.Endereco)
                .Include(x => x.Telefones)
                .SingleOrDefaultAsync(x => x.Id == cliente.Id);

            if(clienteConsultado == null)
            {
                return null;
            }

            _context.Entry(clienteConsultado).CurrentValues.SetValues(cliente);
            clienteConsultado.Endereco = cliente.Endereco;
            clienteConsultado.Telefones.Clear();
            foreach (var telefone in cliente.Telefones)
            {
                clienteConsultado.Telefones.Add(telefone);
            }

            await _context.SaveChangesAsync();
            return cliente;
        }
    }
}
