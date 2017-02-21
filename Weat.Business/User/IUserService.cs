using System.Threading.Tasks;
using Weat.Business.Base;
using Weat.Business.User.Criteria;
using Weat.Entities.DataModel;

namespace Weat.Business.User
{
    public interface IUserService 
    {
        Task<PERSON> GetById(int id);
    }
}
