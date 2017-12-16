using RocamERP.Application;
using RocamERP.Application.Interfaces;
using RocamERP.Domain.RepositoryInterfaces;
using RocamERP.Domain.ServiceInterfaces;
using RocamERP.Infra.Data.Repositories;
using RocamERP.Services.Services;
using SimpleInjector;

namespace RocamERP.CrossCutting.IoC
{
    public class StandardContainer
    {
        public static void RegisterServices(Container container)
        {
            container.Register(typeof(IBaseApplicationService<>), typeof(BaseApplicationService<>), Lifestyle.Scoped);
            container.Register<IEstadoApplicationService, EstadoApplicationService>(Lifestyle.Scoped);
            container.Register<ICidadeApplicationService, CidadeApplicationService>(Lifestyle.Scoped);

            container.Register<IBancoApplicationService, BancoApplicationService>(Lifestyle.Scoped);
            container.Register<IContatoApplicationService, ContatoApplicationService>(Lifestyle.Scoped);
            container.Register<IEnderecoApplicationService, EnderecoApplicationService>(Lifestyle.Scoped);
            container.Register<IChequeApplicationService, ChequeApplicationService>(Lifestyle.Scoped);
            container.Register<IPessoaApplicationService, PessoaApplicationService>(Lifestyle.Scoped);


            //SERVICES
            container.Register(typeof(IBaseService<>), typeof(BaseService<>), Lifestyle.Scoped);
            container.Register<IEstadoService, EstadoService>(Lifestyle.Scoped);
            container.Register<ICidadeService, CidadeService>(Lifestyle.Scoped);
            container.Register<IBancoService, BancoService>(Lifestyle.Scoped);
            container.Register<IContatoService, ContatoService>(Lifestyle.Scoped);
            container.Register<IEnderecoService, EnderecoService>(Lifestyle.Scoped);
            container.Register<IChequeService, ChequeService>(Lifestyle.Scoped);
            container.Register<IPessoaService, PessoaService>(Lifestyle.Scoped);


            //REPOSITORIES
            container.Register(typeof(IBaseRepository<>), typeof(BaseRepository<>), Lifestyle.Scoped);
            container.Register<IEstadoRepository, EstadoRepository>(Lifestyle.Scoped);
            container.Register<ICidadeRepository, CidadeRepository>(Lifestyle.Scoped);
            container.Register<IBancoRepository, BancoRepository>(Lifestyle.Scoped);
            container.Register<IContatoRepository, ContatoRepository>(Lifestyle.Scoped);
            container.Register<IEnderecoRepository, EnderecoRepository>(Lifestyle.Scoped);
            container.Register<IChequeRepository, ChequeRepository>(Lifestyle.Scoped);
            container.Register<IPessoaRepository, PessoaRepository>(Lifestyle.Scoped);
        }
    }
}
