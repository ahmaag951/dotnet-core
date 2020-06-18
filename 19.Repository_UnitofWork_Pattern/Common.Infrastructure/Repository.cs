using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Common.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext Context;
        protected readonly DbSet<T> dbSet;

        public Repository(DbContext context)
        {
            Context = context;
            dbSet = Context.Set<T>();
        }

        public virtual T Add(T entity)
        {
            return dbSet.Add(entity).Entity;
        }
        public virtual void AddRange(IEnumerable<T> entities)
        {
            dbSet.AddRange(entities);
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, PagingSortingDto pagingSortingDto = null)
        {
            IQueryable<T> query = dbSet;
            query = query.AsNoTracking();
            query = query.Where(predicate);
            if (pagingSortingDto != null)
            {
                query.OrderByWithDirection(pagingSortingDto.SortDirection, pagingSortingDto.SortField);
            }
            if (include != null)
            {
                query = include(query);
            }
            return query.ToList();
        }
        public virtual T FirstOrDefault(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = dbSet;
            query = query.AsNoTracking();
            if (include != null)
            {
                query = include(query);
            }
            return query.FirstOrDefault(predicate);
        }
        public virtual T FirstOrDefaultStringInclude(Expression<Func<T, bool>> predicate, string includeProperties = "")
        {
            IQueryable<T> query = dbSet;
            query = query.AsNoTracking();
            if (!string.IsNullOrEmpty(includeProperties))
            {
                var splitedList = includeProperties.Split(',');
                foreach (var includeProperty in splitedList)
                {
                    query = query.Include(includeProperty);
                }
            }
            return query.FirstOrDefault(predicate);
        }
        public virtual T Get(params object[] id)
        {
            return dbSet.Find(id);
        }

        public virtual IEnumerable<T> GetAll(Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = dbSet;

            //query = query.AsNoTracking();
            if (include != null)
            {
                query = include(query);
            }
            return query.ToList();
        }

        public virtual IEnumerable<T> GetPaggedList(Expression<Func<T, bool>> predicate, PagingSortingDto pagingSortingDto, out int count, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = dbSet;

            query = query.AsNoTracking();

            query = query.Where(predicate);

            if (include != null)
            {
                query = include(query);
            }
            count = query.Count();
            if (pagingSortingDto.Limit == 1)
            {
                return query.ToList();
            }
            return query.GetPaggedList(pagingSortingDto.Offset, pagingSortingDto.Limit.Value).ToList();
        }
        public virtual IEnumerable<T> GetPaggedListStringInclude(Expression<Func<T, bool>> predicate, PagingSortingDto pagingSortingDto, out int count, string includeProperties = "")
        {
            IQueryable<T> query = dbSet;

            query = query.AsNoTracking();
            query = query.Where(predicate);

            if (!string.IsNullOrEmpty(includeProperties))
            {
                var splitedList = includeProperties.Split(',');
                foreach (var includeProperty in splitedList)
                {
                    query = query.Include(includeProperty);
                }
            }
            count = query.Count();
            if (pagingSortingDto.Limit == 1)
            {
                return query.ToList();
            }
            return query.GetPaggedList(pagingSortingDto.Offset, pagingSortingDto.Limit.Value).ToList();
        }

        public virtual bool IsExist(Expression<Func<T, bool>> predicate) => dbSet.Any(predicate);
        public virtual int Count(Expression<Func<T, bool>> predicate = null) => predicate == null ? dbSet.Count() : dbSet.Count(predicate);

        public virtual void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }
    }
}
