using RocamERP.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using RocamERP.Domain.QuerySpecificationInterfaces;

namespace RocamERP.Infra.Data.Repositories
{
    public class BaseRepository<TEntity> : IDisposable, IBaseRepository<TEntity> where TEntity : class
    {
        protected RocamDbContext dbContext = new RocamDbContext();

        public void Add(TEntity obj)
        {
            dbContext.Set<TEntity>().Add(obj);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var obj = dbContext.Set<TEntity>().Find(id);
            dbContext.Set<TEntity>().Remove(obj);
            dbContext.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbContext.Set<TEntity>().ToList().AsReadOnly();
        }

        public IEnumerable<TEntity> GetAll(ISpecification<TEntity> specification)
        {
            return dbContext.Set<TEntity>().Where(specification.ToExpression());
        }

        public TEntity Get(int id)
        {
            return dbContext.Set<TEntity>().Find(id);
        }

        public void Update(TEntity obj)
        {
            dbContext.Entry(obj).State = EntityState.Modified;
            dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
