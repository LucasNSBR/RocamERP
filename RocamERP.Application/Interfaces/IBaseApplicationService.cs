﻿using RocamERP.Domain.QuerySpecificationInterfaces;
using System.Collections.Generic;

namespace RocamERP.Application.Interfaces
{
    public interface IBaseApplicationService<TEntity> where TEntity : class
    {
        void Add(TEntity obj);

        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAll(ISpecification<TEntity> specification);

        TEntity Get(int id);

        void Update(TEntity obj);
        void Delete(int id);
    }
}
