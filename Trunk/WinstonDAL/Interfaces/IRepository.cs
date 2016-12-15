using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Winston.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T Get(long id);

        IEnumerable<T> GetAll();

        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        void Add(T entity);

        void AddRange(List<T> entities);

        void Remove(T entity);

        void RemoveRange(List<T> entities);
    }
}
