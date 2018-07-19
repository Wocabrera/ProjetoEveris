using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Everis.Teste.Domain.Validation;

namespace Everis.Teste.Application.Interfaces.Common
{
    public interface IAppService<TEntity> : IWriteOnlyAppService<TEntity>, IDisposable
          where TEntity : class
    {
        ValidationResult validationResult { get; set; }
        TEntity Get(int id);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicateb);
    }
}
