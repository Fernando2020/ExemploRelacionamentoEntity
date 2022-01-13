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

        private async Task AddEspecialidades(Medico medico)
        {
            var especialidades = new List<Especialidade>();
            foreach (var especialidade in medico.Especialidades)
            {
                var especialidadeConsultada = await _context.Especialidades
                    .FirstOrDefaultAsync(x => x.Id == especialidade.Id);

                if (especialidadeConsultada != null)
                {
                    especialidades.Add(especialidadeConsultada);
                }
            }

            medico.Especialidades = especialidades;
        }

        public async Task<Medico> AddAsync(Medico medico)
        {
            await AddEspecialidades(medico);
            await _context.Medicos.AddAsync(medico);
            await _context.SaveChangesAsync();
            return medico;
        }

        public async Task<IEnumerable<Medico>> GetAllAsync()
        {
            return await _context.Medicos
                .Include(x => x.Especialidades)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Medico> GetByIdAsync(int id)
        {
            return await _context.Medicos
                .Include(x => x.Especialidades)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
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
                .Include(x => x.Especialidades)
                .FirstOrDefaultAsync(x => x.Id == medico.Id);

            if(medicoConsultado == null)
            {
                return null;
            }

            _context.Entry(medicoConsultado).CurrentValues.SetValues(medico);
            await UpdateEspecialidades(medicoConsultado, medico);
            await _context.SaveChangesAsync();
            return medicoConsultado;
        }

        private async Task UpdateEspecialidades(Medico medicoConsultado, Medico medico)
        {
            medicoConsultado.Especialidades.Clear();
            foreach (var especialidade in medico.Especialidades)
            {
                var especialidadeConsultada = await _context.Especialidades
                    .FirstOrDefaultAsync(x => x.Id == especialidade.Id);

                if(especialidadeConsultada != null)
                {
                    medicoConsultado.Especialidades.Add(especialidadeConsultada);
                }
            }
        }
    }
}
