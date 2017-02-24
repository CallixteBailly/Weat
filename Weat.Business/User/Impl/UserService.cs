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
        public Task<List<PERSON>> GetAll()
        {
            List<PERSON> persons = Manager.GetAll<PERSON>().ToList();
            return Task.FromResult(persons);
        }
        public async Task<PERSON> GetById(int id)
        {
            PERSON person = await Manager.SingleAsync<PERSON>(p => p.IDUSER == id);

            return await Task.FromResult(person);
        }
        public async Task addUserAsync(PERSON p)
        {
            await Manager.AddAsync<PERSON>(p);
            await Manager.SaveChangesAsync();
        }
        public async Task DeleteByIdAsync(short id)
        {
            Manager.DeleteById(id);
            await Manager.SaveChangesAsync();
        }

        public override Task<List<PERSON>> ReadAsync(BaseCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public override Task SaveAsync(PERSON entity)
        {
            throw new NotImplementedException();
        }

        public async Task UpdatePerson(PERSON pERSON, short id)
        {
            PERSON person = await Manager.SingleAsync<PERSON>(p => p.IDUSER == id);
            person.FIRSTNAME = pERSON.FIRSTNAME;
            person.LASTNAME = pERSON.LASTNAME;
            person.Mail = pERSON.Mail;
            person.PSEUDO = pERSON.PSEUDO;
            await Manager.SaveChangesAsync();
        }
        public async Task<bool> CheckPeople(PERSON p)
        {
            bool statusCheck = false;
            PERSON personDb = await GetById(p.IDUSER);
            if (personDb.PSEUDO == p.PSEUDO && personDb.PASSWORD == p.PASSWORD)
            {
                statusCheck = true ;
            }
            return await Task.FromResult(statusCheck);
        }

        public async void UpdatePasswordPersonAsync(PERSON p)
        {
            PERSON person = await this.GetById(p.IDUSER);
            person.PASSWORD = p.PASSWORD;
            await Manager.SaveChangesAsync();
        }

        public Task<PERSON> GetByName(string userName)
        {
            PERSON person = Manager.Find<PERSON>(p => p.Mail == userName).First();
            return Task.FromResult(person);
        }
    }
}
