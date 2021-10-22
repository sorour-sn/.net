using LMS2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LMS2.Entity
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext DatabaseContext;
        //private readonly DatabaseContext databaseContext;
        private readonly DbSet<T> targetDbSet;


        public Repository(DbContext DatabaseContext)
        {
            this.DatabaseContext = DatabaseContext ?? throw new ArgumentNullException(nameof(DatabaseContext));
            this.targetDbSet = DatabaseContext.Set<T>();
            expression = Expression.Constant(this);
            this.Provider = new RepositoryQueryProvider<T>(targetDbSet);
        }
        public Repository(DatabaseContext context)
        {
            this.context = context;
        }

        public async Task CreateAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            context.Add(entity);
            await context.SaveChangesAsync();
        }

        void IRepository<T>.AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        void IRepository<T>.CreateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        void IRepository<T>.DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        IQueryable<T> IRepository<T>.List()
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> FindAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}
