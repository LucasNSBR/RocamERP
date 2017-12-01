using System.Collections.Generic;
using RocamERP.Domain.ServiceInterfaces;
using RocamERP.Domain.RepositoryInterfaces;
using RocamERP.Domain.QuerySpecificationInterfaces;
using System;

namespace RocamERP.Services.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        public readonly IBaseRepository<TEntity> _repository; 

        public BaseService(IBaseRepository<TEntity> repository)
        {
            _repository = repository;
        }        

        public void Add(TEntity obj)
        {
            _repository.Add(obj);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<TEntity> GetAll(ISpecification<TEntity> specification)
        {
            return _repository.GetAll(specification);
        }

        public TEntity Get(int id)
        {
            return _repository.Get(id);
        }

        public void Update(TEntity obj)
        {
            _repository.Update(obj);
        }
    }
}
