using AutoMapper;
using RocamERP.Domain.Models;
using RocamERP.Presentation.Web.ViewModels;
using RocamERP.Presentation.Web.ViewModels.CidadeViewModels;

namespace RocamERP.Presentation.Web.Mappers
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Estado, EstadoViewModel>();
            CreateMap<Banco, BancoViewModel>();
            CreateMap<Cheque, ChequeViewModel>();
            CreateMap<Endereco, EnderecoViewModel>();

            CreateMap<Contato, ContatoViewModel>();
            CreateMap<Cidade, CidadeViewModel>().PreserveReferences();
            CreateMap<Pessoa, PessoaViewModel>().PreserveReferences();

            CreateMap<CadastroNacional, CadastroNacionalViewModel>();
            CreateMap<CadastroEstadual, CadastroEstadualViewModel>();
        }
    }
}