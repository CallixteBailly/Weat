using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weak.Dal.SqlServer.Manager;
using Weat.Business.Base.Criteria;

namespace Weat.Business.Base.Impl
{
    public abstract class BaseService<TEntity,TCriteria> : IBaseService<TEntity, TCriteria> where TCriteria : BaseCriteria
    {
        [Dependency]
        public IManagerData Manager
        {
            get;
            set;
        }

        public abstract Task DeleteAsync(TEntity entity);
        public abstract Task<List<TEntity>> ReadAsync(BaseCriteria criteria);
        public abstract Task SaveAsync(TEntity entity);
    }
}
