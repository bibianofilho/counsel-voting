using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CounselVoting.Infrastructure.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T GetById(object id, params string[] collectionLoads);
        IEnumerable<T> GetByFilter(Expression<Func<T, bool>> filter = null,
              Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
               params string[] includes);
        void Insert(T entity);
        void Delete(T entity);
        void Update(T entity);
        void Save();
        IEnumerable<T> FromSql(string sql);
    }
}
