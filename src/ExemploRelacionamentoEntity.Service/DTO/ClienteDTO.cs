using System;
using System.Collections.Generic;

namespace ExemploRelacionamentoEntity.Service.DTO
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime Nascimento { get; set; }

        public EnderecoDTO Endereco { get; set; }
        public ICollection<TelefoneDTO> Telefones { get; set; }
    }
}
