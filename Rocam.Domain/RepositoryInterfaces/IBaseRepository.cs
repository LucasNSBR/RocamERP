using System.Collections.Generic;
using System.Threading.Tasks;

namespace RocamERP.Domain.RepositoryInterfaces
{
    public interface IBaseRepository<T> 
    {
        void Add(T obj);

        IEnumerable<T> Get();
        T Get(int id);
        T Get(string id);

        void Update(T obj);
        void Delete(int id);
    }
}
