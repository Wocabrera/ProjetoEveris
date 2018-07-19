using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Everis.Teste.Domain.Repository.Interfaces
{
    public interface IRepository<TEntity>
            where TEntity : class
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    }
}
