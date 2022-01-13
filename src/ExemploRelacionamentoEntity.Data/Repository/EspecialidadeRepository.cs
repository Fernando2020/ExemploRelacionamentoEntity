using ExemploRelacionamentoEntity.Data.Context;
using ExemploRelacionamentoEntity.Domain.Domain;
using ExemploRelacionamentoEntity.Domain.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExemploRelacionamentoEntity.Data.Repository
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        private readonly ExemploContext _context;
        public EspecialidadeRepository(ExemploContext context)
        {
            _context = context;
        }

        public async Task<Especialidade> AddAsync(Especialidade especialidade)
        {
            await _context.AddAsync(especialidade);
            await _context.SaveChangesAsync();
            return especialidade;
        }

        public async Task<IEnumerable<Especialidade>> GetAllAsync()
        {
            return await _context.Especialidades
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Especialidade> GetByIdAsync(int id)
        {
            return await _context.Especialidades
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Especialidade> RemoveAsync(int id)
        {
            var especialidadeConsultada = await _context.Especialidades
                .FirstOrDefaultAsync(x => x.Id == id);

            if(especialidadeConsultada == null)
            {
                return null;
            }

            var especialidadeRemovida = _context.Especialidades.Remove(especialidadeConsultada);
            await _context.SaveChangesAsync();
            return especialidadeRemovida.Entity;
        }

        public async Task<Especialidade> UpdateAsync(Especialidade especialidade)
        {
            var especialidadeConsultado = await _context.Especialidades
                .FirstOrDefaultAsync(x => x.Id == especialidade.Id);

            if(especialidadeConsultado == null)
            {
                return null;
            }

            _context.Entry(especialidadeConsultado).CurrentValues.SetValues(especialidade);
            await _context.SaveChangesAsync();
            return especialidadeConsultado;
        }
    }
}
