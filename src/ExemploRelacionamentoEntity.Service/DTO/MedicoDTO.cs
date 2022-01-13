using System.Collections.Generic;

namespace ExemploRelacionamentoEntity.Service.DTO
{
    public class MedicoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string CRM { get; set; }

        public ICollection<EspecialidadeMedicoDTO> Especialidades { get; set; }
    }
}
