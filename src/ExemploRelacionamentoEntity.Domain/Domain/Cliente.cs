using System;
using System.Collections.Generic;

namespace ExemploRelacionamentoEntity.Domain.Domain
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime Nascimento { get; set; }

        public Endereco Endereco { get; set; }
        public ICollection<Telefone> Telefones { get; set; }
    }
}
