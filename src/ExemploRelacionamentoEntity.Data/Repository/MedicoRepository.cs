using ExemploRelacionamentoEntity.Data.Context;
using ExemploRelacionamentoEntity.Domain.Domain;
using ExemploRelacionamentoEntity.Domain.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExemploRelacionamentoEntity.Data.Repository
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly ExemploContext _context;
        public MedicoRepository(ExemploContext context)
        {
            _context = context;
        }

        public async Task<Medico> AddAsync(Medico medico)
        {
            await _context.Medicos.AddAsync(medico);
            await _context.SaveChangesAsync();
            return medico;
        }

        public async Task<IEnumerable<Medico>> GetAllAsync()
        {
            var medicos = await _context.Medicos
                .Include(x => x.Especialidades)
                .AsNoTracking()
                .ToListAsync();

            return medicos;
        }

        public async Task<Medico> GetByIdAsync(int id)
        {
            var medico = await _context.Medicos
                .Include(x => x.Especialidades)
                .FirstOrDefaultAsync(x => x.Id == id);

            return medico;
        }

        public async Task<Medico> RemoveAsync(int id)
        {
            var medicoConsultado = await _context.Medicos
                .FirstOrDefaultAsync(x => x.Id == id);

            if(medicoConsultado == null)
            {
                return null;
            }

            var clienteRemovido = _context.Medicos.Remove(medicoConsultado);
            await _context.SaveChangesAsync();
            return clienteRemovido.Entity;
        }

        public async Task<Medico> UpdateAsync(Medico medico)
        {
            var medicoConsultado = await _context.Medicos
                .FirstOrDefaultAsync(x => x.Id == medico.Id);

            if(medicoConsultado == null)
            {
                return null;
            }

            _context.Entry(medicoConsultado).CurrentValues.SetValues(medico);
            AddEspecialidades(medicoConsultado, medico);
            await _context.SaveChangesAsync();
            return medicoConsultado;
        }

        private void AddEspecialidades(Medico medicoConsultado, Medico medico)
        {
            medicoConsultado.Especialidades.Clear();
            foreach (var especialidade in medico.Especialidades)
            {
                medicoConsultado.Especialidades.Add(especialidade);
            }
        }
    }
}
