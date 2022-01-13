using System.Collections.Generic;

namespace ExemploRelacionamentoEntity.Domain.Domain
{
    public class Medico
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string CRM { get; set; }
        
        public ICollection<Especialidade> Especialidades{ get; set; }
    }
}
