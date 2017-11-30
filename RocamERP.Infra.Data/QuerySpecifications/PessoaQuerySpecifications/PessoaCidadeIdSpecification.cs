using RocamERP.Domain.Models;
using System;
using System.Linq.Expressions;
using System.Linq;

namespace RocamERP.Infra.Data.QuerySpecifications.PessoaQuerySpecifications
{
    public class PessoaCidadeIdSpecification : BaseSpecification<Pessoa>
    {
        private readonly int? _cidadeId;

        public PessoaCidadeIdSpecification(int? cidadeId)
        {
            _cidadeId = cidadeId;
        }

        public override Expression<Func<Pessoa, bool>> ToExpression()
        {
            if(_cidadeId != null) 
                return pessoa => pessoa.Enderecos.Any(e => e.CidadeId == _cidadeId);

            return pessoa => true;
        }
    }
}
