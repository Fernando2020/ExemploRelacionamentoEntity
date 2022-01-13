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

        public async Task<Cliente> AddAsync(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await _context.Clientes
                .Include(x => x.Endereco)
                .Include(x => x.Telefones)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Cliente> GetByIdAsync(int id)
        {
            return await _context.Clientes
                .Include(x => x.Endereco)
                .Include(x => x.Telefones)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Cliente> RemoveAsync(int id)
        {
            var clienteConsultado = await _context.Clientes
                .FirstOrDefaultAsync(x => x.Id == id);

            if (clienteConsultado == null)
            {
                return null;
            }

            var clienteRemovido = _context.Clientes.Remove(clienteConsultado);
            await _context.SaveChangesAsync();
            return clienteRemovido.Entity;
        }

        public async Task<Cliente> UpdateAsync(Cliente cliente)
        {
            var clienteConsultado = await _context.Clientes
                .Include(x => x.Endereco)
                .Include(x => x.Telefones)
                .FirstOrDefaultAsync(x => x.Id == cliente.Id);

            if (clienteConsultado == null)
            {
                return null;
            }

            _context.Entry(clienteConsultado).CurrentValues.SetValues(cliente);
            clienteConsultado.Endereco = cliente.Endereco;
            UpdateTelefones(clienteConsultado, cliente);

            await _context.SaveChangesAsync();
            return cliente;
        }

        private void UpdateTelefones(Cliente clienteConsultado, Cliente cliente)
        {
            clienteConsultado.Telefones.Clear();
            foreach (var telefone in cliente.Telefones)
            {
                clienteConsultado.Telefones.Add(telefone);
            }
        }
    }
}
