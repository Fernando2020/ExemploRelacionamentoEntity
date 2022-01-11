using ExemploRelacionamentoEntity.Data.Mapping;
using ExemploRelacionamentoEntity.Domain.Domain;
using Microsoft.EntityFrameworkCore;

namespace ExemploRelacionamentoEntity.Data.Context
{
    public class ExemploContext : DbContext
    {
        public ExemploContext(DbContextOptions<ExemploContext> options) : base(options)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Telefone> Telefones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>(new ClienteMap().Configure);
        }
    }
}
