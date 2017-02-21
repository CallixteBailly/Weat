using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weak.Dal.SqlServer.Manager;
using Weat.Business.Base.Criteria;
using Weat.Business.Base.Impl;
using Weat.Business.User.Criteria;
using Weat.Dal.SqlServer.DataModel;
using Weat.Entities.DataModel;

namespace Weat.Business.User.Impl
{
    public class UserService : BaseService<PERSON, UserCriteria>, IUserService
    {
        public override Task DeleteAsync(PERSON entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Entities.DataModel.PERSON> GetById(int id)
        {
            Entities.DataModel.PERSON person = await Manager.SingleAsync<Entities.DataModel.PERSON>(p => p.IDUSER == id);
            return await Task.FromResult(person);
        }

        public override Task<List<PERSON>> ReadAsync(BaseCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public override Task SaveAsync(PERSON entity)
        {
            throw new NotImplementedException();
        }
    }
}
