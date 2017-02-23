using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Weat.Entities.DataModel;

namespace Weak.Dal.SqlServer.Manager
{
    public interface IManagerData
    {
        IQueryable<TEntity> GetQuery<TEntity>() where TEntity : class;

        IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class;
        IEnumerable<TEntity> Find<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
        IQueryable<TEntity> FindQueryable<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
        IEnumerable<TEntity> Where<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
        ///<remarks>This method is using only for unit tests</remarks> 
        int ExecuteQuery(List<string> queryList);
        ///<remarks>This method is using only for unit tests</remarks> 
        TEntity Single<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
        TEntity First<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
        void Add<TEntity>(TEntity entity) where TEntity : class;
        void Delete<TEntity>(TEntity entity) where TEntity : class;
        void SaveChanges();

        #region async
        IEnumerable<TEntity> WhereAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
        void DeleteById(short id);
        Task<TEntity> SingleAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
        Task<TEntity> SingleOrDefaultAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
        Task<TEntity> FirstAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
        Task AddAsync<TEntity>(TEntity entity) where TEntity : class;

        Task<int> CountAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
        Task SaveChangesAsync();
        Task<bool> AnyAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
        #endregion async
    }
}
