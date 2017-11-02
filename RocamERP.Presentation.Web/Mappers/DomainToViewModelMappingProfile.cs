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
            CreateMap<Cheque, ChequeViewModel>().PreserveReferences();
            CreateMap<Endereco, EnderecoViewModel>();
            CreateMap<Contato, ContatoViewModel>();

            CreateMap<Cliente, ClienteViewModel>()
                .Include<ClientePessoaFisica, ClientePessoaFisicaViewModel>().PreserveReferences()
                .Include<ClientePessoaJuridica, ClientePessoaJuridicaViewModel>().PreserveReferences();

            //CreateMap<Cliente, ClienteViewModel>()
            //    .Include<ClientePessoaFisica, ClientePessoaFisicaViewModel>()
            //    .ForMember(d => d.CPF, m => m.MapFrom(s => s.GetRegistroFederal()));
            //CreateMap<Cliente, ClienteViewModel>()
            //    .Include<ClientePessoaFisica, ClientePessoaFisicaViewModel>()
            //    .ForMember(d => d.CPF, m => m.MapFrom(s => s.GetRegistroFederal()));


            CreateMap<ClientePessoaFisica, ClientePessoaFisicaViewModel>();
            CreateMap<ClientePessoaJuridica, ClientePessoaJuridicaViewModel>();
        }
    }
}