using System.Collections.Generic;

namespace ExemploRelacionamentoEntity.Domain.Domain
{
    public class Especialidade
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public ICollection<Medico> Medicos { get; set; }
    }
}
