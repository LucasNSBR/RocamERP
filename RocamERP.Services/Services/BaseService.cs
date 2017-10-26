using System.Collections.Generic;
using RocamERP.Infra.Data.Repositories;
using RocamERP.Domain.ServiceInterfaces;

namespace RocamERP.Services.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        private BaseRepository<TEntity> _repository = new BaseRepository<TEntity>();
        
        public void Add(TEntity obj)
        {
            _repository.Add(obj);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<TEntity> Get()
        {
            return _repository.Get();
        }

        public TEntity Get(int id)
        {
            return _repository.Get(id);
        }

        public TEntity Get(string id)
        {
            return _repository.Get(id);
        }

        public void Update(TEntity obj)
        {
            _repository.Update(obj);
        }
    }
}
