using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Weat.Entities.DataModel;
using System.Threading.Tasks;
using Weat.UI.Models;
using Weat.Business.User;
using Weat.Business;
using Weat.UI.Models.Transverse;

namespace Weat.UI.Identity
{
    public class WeatUserStore :
         IUserStore<WeatUser, int>,
         IUserPasswordStore<WeatUser, int>,
         IUserLockoutStore<WeatUser, int>,
         IUserTwoFactorStore<WeatUser, int>,
         IDisposable
    {
        public IUserService UserService => UnityConfig.Resolve<IUserService>();

        public Task CreateAsync(WeatUser user)
        {
            PERSON person = new PERSON()
            {
                FIRSTNAME = user.FirstName,
                LASTNAME = user.LastName,
                PASSWORD = user.Password,
                PSEUDO = user.UserName,
                Mail = user.Mail
            };
            var userId = UserService.addUserAsync(person);
            return Task.FromResult(0);
        }

        public Task DeleteAsync(WeatUser user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }

        public async Task<WeatUser> FindByIdAsync(int userId)
        {
            PERSON user = await UserService.GetById(userId);
            if (user == null)
            {
                return null;
            }
            WeatUser application = new WeatUser()
            {
                Id = user.IDUSER,
                FirstName = user.FIRSTNAME,
                LastName = user.LASTNAME,
                Mail = user.Mail,
                UserName = user.PSEUDO,
                Password = user.PASSWORD
            };
            return await Task.FromResult(application);
        }

        public async Task<WeatUser> FindByNameAsync(string userName)
        {
            PERSON user = await UserService.GetByName(userName);
            if (user == null)
            {
                return null;
            }
            WeatUser application = new WeatUser()
            {
                Id = user.IDUSER,
                FirstName = user.FIRSTNAME,
                LastName = user.LASTNAME,
                Mail = user.Mail,
                UserName = user.PSEUDO,
                Password = user.PASSWORD,
            };
            return await Task.FromResult(application);

        }

        public Task<int> GetAccessFailedCountAsync(WeatUser user)
        {
            return Task.FromResult(0);
        }

        public Task<bool> GetLockoutEnabledAsync(WeatUser user)
        {
            return Task.FromResult(true);
        }

        public Task<DateTimeOffset> GetLockoutEndDateAsync(WeatUser user)
        {
            return Task.FromResult(new DateTimeOffset());
        }

        public Task<string> GetPasswordHashAsync(WeatUser user)
        {
            return Task.FromResult(user.Password);
        }

        public Task<bool> GetTwoFactorEnabledAsync(WeatUser user)
        {
            return Task.FromResult(false);
        }

        public Task<bool> HasPasswordAsync(WeatUser user)
        {
            throw new NotImplementedException();
        }

        public Task<int> IncrementAccessFailedCountAsync(WeatUser user)
        {
            throw new NotImplementedException();
        }

        public Task ResetAccessFailedCountAsync(WeatUser user)
        {
            throw new NotImplementedException();
        }

        public Task SetLockoutEnabledAsync(WeatUser user, bool enabled)
        {
            throw new NotImplementedException();
        }

        public Task SetLockoutEndDateAsync(WeatUser user, DateTimeOffset lockoutEnd)
        {
            throw new NotImplementedException();
        }

        public Task SetPasswordHashAsync(WeatUser user, string passwordHash)
        {
            if (user.Id != 0)
            {
                PERSON p = new PERSON()
                {
                    PASSWORD = passwordHash,
                };
                //UserCriteria criteria = new UserCriteria()
                //{
                //    Id = user.Id,
                //    Person = p
                //};
                UserService.UpdatePasswordPersonAsync(p);
            }
            user.Password = passwordHash;
            return Task.FromResult(0);
        }

        public Task SetTwoFactorEnabledAsync(WeatUser user, bool enabled)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(WeatUser user)
        {
            throw new NotImplementedException();
        }
    }

}