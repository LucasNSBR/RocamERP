using System.Collections.Generic;

namespace RocamERP.Application.Interfaces
{
    public interface IBaseApplicationService<T> where T : class
    {
        void Add(T obj);

        IEnumerable<T> GetAll();
        T Get(int id);

        void Update(T obj);
        void Delete(int id);
    }
}
