using AutoMapper;
using RocamERP.Domain.Models;
using RocamERP.Presentation.Web.ViewModels;
using RocamERP.Presentation.Web.ViewModels.CidadeViewModels;

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

            CreateMap<PessoaViewModel, Pessoa>();
            CreateMap<CadastroNacionalViewModel, CadastroNacional>();
            CreateMap<CadastroEstadualViewModel, CadastroEstadual>();
        }
    }
}