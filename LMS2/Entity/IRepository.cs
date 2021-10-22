using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LMS2.Entity
{
    public interface IRepository<T> where T : class
    {
        Task CreateAsync(T entity);
        Task AddAsync(T entity);
        Task DeleteAsync(T entity);
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
    }
}
