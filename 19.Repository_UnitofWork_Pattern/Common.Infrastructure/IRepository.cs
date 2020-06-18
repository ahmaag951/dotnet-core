using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Common.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        T Get(params object[] id);
        IEnumerable<T> GetAll(Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        IEnumerable<T> GetPaggedList(Expression<Func<T, bool>> predicate, PagingSortingDto pagingSortingDto, out int count, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        IEnumerable<T> GetPaggedListStringInclude(Expression<Func<T, bool>> predicate, PagingSortingDto pagingSortingDto, out int count, string includeProperties = "");
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, PagingSortingDto pagingSortingDto = null);
        T FirstOrDefault(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        T FirstOrDefaultStringInclude(Expression<Func<T, bool>> predicate, string includeProperties = "");
        T Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        bool IsExist(Expression<Func<T, bool>> predicate);
        int Count(Expression<Func<T, bool>> predicate = null);
    }
}
