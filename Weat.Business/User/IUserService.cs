using System.Collections.Generic;
using System.Threading.Tasks;
using Weat.Business.Base;
using Weat.Business.User.Criteria;
using Weat.Entities.DataModel;

namespace Weat.Business.User
{
    public interface IUserService : IBaseService <PERSON,UserCriteria>
    {
        Task<PERSON> GetById(int id);
        Task<List<PERSON>> GetAll();
        Task addUserAsync(PERSON p);
        Task DeleteByIdAsync(short id);
        Task UpdatePerson(PERSON pERSON,short id);
        Task<bool> CheckPeople(PERSON p);
        void UpdatePasswordPersonAsync(PERSON p);
        Task<PERSON> GetByName(string userName);
    }
}
