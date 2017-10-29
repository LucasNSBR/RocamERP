using AutoMapper;
using RocamERP.Domain.Models;
using RocamERP.Presentation.Web.ViewModels;

namespace RocamERP.Presentation.Web.Mappers
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<EstadoViewModel, Estado>();
            CreateMap<CidadeViewModel, Cidade>();
            CreateMap<BancoViewModel, Banco>();
            CreateMap<ChequeViewModel, Cheque>();
            CreateMap<EnderecoViewModel, Endereco>();
            CreateMap<ContatoViewModel, Contato>();

            CreateMap<ClienteViewModel, Cliente>();
            CreateMap<ClientePessoaFisicaViewModel, ClientePessoaFisica>();
            CreateMap<ClientePessoaJuridicaViewModel, ClientePessoaJuridica>();
        }
    }
}