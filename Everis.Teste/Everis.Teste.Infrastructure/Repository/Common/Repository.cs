using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Everis.Teste.Domain.Repository.Interfaces;
using Everis.Teste.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Everis.Teste.Infrastructure.Repository.Common
{
    public class Repository<TEntity> : IRepository<TEntity>
           where TEntity : class
    {
        protected EverisContext dbContext;
        protected DbSet<TEntity> dbSet;

        public Repository(EverisContext context)
        {
            dbContext = context;
            dbSet = dbContext.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            dbSet.Add(entity);
            dbContext.SaveChanges();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return dbSet.Where(predicate).ToList();
        }

        public void Update(TEntity entity)
        {
            try
            {
                dbSet.Update(entity);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
