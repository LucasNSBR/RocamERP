using System.Collections.Generic;
using RocamERP.Application.Interfaces;
using RocamERP.Services.Services;

namespace RocamERP.Application
{
    public class BaseApplicationService<TService> : IBaseApplicationService<TService> where TService : class
    {
        private BaseService<TService> _baseService; 

        public void Add(TService obj)
        {
            _baseService.Add(obj);
        }

        public void Delete(int id)
        {
            _baseService.Delete(id);
        }

        public IEnumerable<TService> Get()
        {
            return _baseService.Get();
        }

        public TService Get(int id)
        {
            return _baseService.Get(id);
        }

        public TService Get(string id)
        {
            return _baseService.Get(id);
        }

        public void Update(TService obj)
        {
            _baseService.Update(obj);
        }
    }
}
