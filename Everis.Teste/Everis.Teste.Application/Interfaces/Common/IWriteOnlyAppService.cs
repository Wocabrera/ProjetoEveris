using System;
using System.Collections.Generic;
using System.Text;
using Everis.Teste.Domain.Validation;

namespace Everis.Teste.Application.Interfaces.Common
{
    public interface IWriteOnlyAppService<in TEntity>
    where TEntity : class
    {
        ValidationResult Create(TEntity entity);
        ValidationResult Update(TEntity entity);
    }
}
