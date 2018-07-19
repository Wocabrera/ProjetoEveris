using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Everis.Teste.Domain.Repository.Interfaces;
using Everis.Teste.Domain.Service.Interfaces;
using Everis.Teste.Domain.Validation;

namespace Everis.Teste.Domain.Service.Common
{
    public class Service<TEntity> : IService<TEntity>
        where TEntity : class
    {
        public Service(IRepository<TEntity> repository)
        {
            Repository = repository;
            ValidationResult = new ValidationResult();
        }

        protected IRepository<TEntity> Repository { get; }
        protected ValidationResult ValidationResult { get; }
        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Repository.Find(predicate);
        }
        public virtual ValidationResult Add(TEntity entity)
        {
            if (!ValidationResult.IsValid)
                return ValidationResult;

            Repository.Add(entity);
            return ValidationResult;
        }
        public virtual ValidationResult Update(TEntity entity)
        {
            if (!ValidationResult.IsValid)
                return ValidationResult;

            Repository.Update(entity);
            return ValidationResult;
        }
    }
}
