﻿namespace ExemploRelacionamentoEntity.Domain.Domain
{
    public class Endereco
    {
        public int ClienteId { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }

        public Cliente Cliente { get; set; }
    }
}
