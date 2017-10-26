using System.Collections.Generic;

namespace RocamERP.Application.Interfaces
{
    public interface IBaseApplicationService<T> where T : class
    {
        void Add(T obj);

        IEnumerable<T> Get();
        T Get(int id);
        T Get(string id);

        void Update(T obj);
        void Delete(int id);
    }
}
