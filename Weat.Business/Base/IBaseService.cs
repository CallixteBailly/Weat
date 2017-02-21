using System.Collections.Generic;
using System.Threading.Tasks;
using Weat.Business.Base.Criteria;

namespace Weat.Business.Base
{
    public interface IBaseService<TEntity, TCriteria> where TCriteria : BaseCriteria
    {
        Task SaveAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<List<TEntity>> ReadAsync(BaseCriteria criteria);
    }
}
