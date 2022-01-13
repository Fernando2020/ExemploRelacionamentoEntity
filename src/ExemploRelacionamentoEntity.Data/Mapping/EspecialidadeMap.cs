using ExemploRelacionamentoEntity.Domain.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExemploRelacionamentoEntity.Data.Mapping
{
    public class EspecialidadeMap : IEntityTypeConfiguration<Especialidade>
    {
        public void Configure(EntityTypeBuilder<Especialidade> builder)
        {

        }
    }
}
