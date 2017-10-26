using System.Collections.Generic;

namespace RocamERP.Domain.ServiceInterfaces
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        void Add(TEntity obj);

        IEnumerable<TEntity> Get();
        TEntity Get(int id);
        TEntity Get(string id);

        void Update(TEntity obj);
        void Delete(int id);
    }
}
