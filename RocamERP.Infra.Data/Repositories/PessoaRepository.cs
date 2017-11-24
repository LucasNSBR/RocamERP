using RocamERP.Domain.Models;
using RocamERP.Domain.RepositoryInterfaces;
using System.Linq;

namespace RocamERP.Infra.Data.Repositories
{
    public class PessoaRepository : BaseRepository<Pessoa>, IPessoaRepository
    {
        public override void Update(Pessoa obj)
        {
            //TODO: REFACTORE THIS
            if (obj.CadastroEstadual != null && obj.CadastroNacional != null)
            {
                var d = dbContext.CadastroEstadual.ToList().Where(p => p.CadastroEstadualId == obj.PessoaId);
                var c = dbContext.CadastroNacional.ToList().Where(p => p.CadastroNacionalId == obj.PessoaId);

                if (d.Any()) { 
                    dbContext.CadastroEstadual.Remove(d.First());
                }

                if (c.Any())
                {
                    dbContext.CadastroNacional.Remove(c.First());
                }
            }

            dbContext.CadastroNacional.Add(obj.CadastroNacional);
            dbContext.CadastroEstadual.Add(obj.CadastroEstadual);
            base.Update(obj);
        }
    }
}
