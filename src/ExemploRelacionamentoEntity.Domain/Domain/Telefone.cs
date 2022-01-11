namespace ExemploRelacionamentoEntity.Domain.Domain
{
    public class Telefone
    {
        public int ClienteId { get; set; }
        public string Numero { get; set; }

        public Cliente Cliente { get; set; }
    }
}
