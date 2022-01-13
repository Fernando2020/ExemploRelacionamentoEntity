using AutoMapper;
using ExemploRelacionamentoEntity.Domain.Domain;
using ExemploRelacionamentoEntity.Service.DTO;

namespace ExemploRelacionamentoEntity.Service.Mapping
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<Endereco, EnderecoDTO>().ReverseMap();
            CreateMap<Especialidade, EspecialidadeMedicoDTO>().ReverseMap();
            CreateMap<Especialidade, EspecialidadeDTO>().ReverseMap();
            CreateMap<Medico, MedicoDTO>().ReverseMap();
            CreateMap<Telefone, TelefoneDTO>().ReverseMap();
        }
    }
}
