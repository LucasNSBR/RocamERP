using AutoMapper;
using RocamERP.Domain.Models;
using RocamERP.Presentation.Web.ViewModels;

namespace RocamERP.Presentation.Web.Mappers
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Estado, EstadoViewModel>();
            CreateMap<Cidade, CidadeViewModel>();
            CreateMap<Banco, BancoViewModel>();
            CreateMap<Cheque, ChequeViewModel>();
            CreateMap<Endereco, EnderecoViewModel>();
            CreateMap<Contato, ContatoViewModel>();

            CreateMap<Cliente, ClienteViewModel>();
            CreateMap<ClientePessoaFisica, ClientePessoaFisicaViewModel>();
            CreateMap<ClientePessoaJuridica, ClientePessoaJuridicaViewModel>();
        }
    }
}