using System.Collections.Generic;
using RocamERP.Infra.Data.Repositories;
using RocamERP.Domain.ServiceInterfaces;

namespace RocamERP.Services.Services
{
    public class BaseService<TRepository> : IBaseService<TRepository> where TRepository : class
    {
        private BaseRepository<TRepository> _repository = new BaseRepository<TRepository>();
        
        public void Add(TRepository obj)
        {
            _repository.Add(obj);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<TRepository> Get()
        {
            return _repository.Get();
        }

        public TRepository Get(int id)
        {
            return _repository.Get(id);
        }

        public TRepository Get(string id)
        {
            return _repository.Get(id);
        }

        public void Update(TRepository obj)
        {
            _repository.Update(obj);
        }
    }
}
