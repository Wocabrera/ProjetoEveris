using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Everis.Teste.Domain.Validation;

namespace Everis.Teste.Domain.Service.Interfaces
{
    public interface IService<TEntity>
           where TEntity : class
    {
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        ValidationResult Add(TEntity entity);
        ValidationResult Update(TEntity entity);
    }
}
