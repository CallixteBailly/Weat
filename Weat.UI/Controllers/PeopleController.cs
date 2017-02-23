using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Weat.Business;
using Weat.Business.User;
using Weat.Dal.SqlServer.DataModel;
using Weat.Entities.DataModel;

namespace Weat.UI.Controllers
{
    public class PeopleController : ApiController
    {
        private IUserService UserService => UnityConfig.Resolve<IUserService>();
        private WeatEntities db = new WeatEntities();

        // GET: api/People
        public async Task<List<PERSON>> GetPeople() //GET ALL PERSON
        {
            List<PERSON> p = await UserService.GetAll();

            return  await Task.FromResult(p);
        }
        // GET: api/People
        public async Task<IHttpActionResult> CheckPeople(PERSON p) //Check PERSON For Account
        {
            bool check = await UserService.CheckPeople(p);
            if (!check)
            {
                return NotFound();
            }
            return Ok(p);
        }

        // GET: api/People/5
        [ResponseType(typeof(PERSON))]
        public async Task<IHttpActionResult> GetPERSON(short id) //GET PERSON BY ID
        {
            PERSON p = await UserService.GetById(id);

            if (p== null)
            {
                return NotFound();
            }
            return Ok(p);
        }

        // PUT: api/People/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPERSON(short id, PERSON pERSON) //UPDATE PERSON
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pERSON.IDUSER)
            {
                return BadRequest();
            }

            await UserService.UpdatePerson(pERSON, id);


            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PERSONExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }
        // POST: api/People
        [ResponseType(typeof(PERSON))]
        public async Task<IHttpActionResult> PostPERSON(PERSON pERSON) //ADD PERSON
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await UserService.addUserAsync(pERSON);

            return CreatedAtRoute("DefaultApi", new { id = pERSON.IDUSER }, pERSON);
        }

        // DELETE: api/People/5
        [ResponseType(typeof(PERSON))]
        public async Task<IHttpActionResult> DeletePERSON(short id) //DELETE PERSON
        {
            if (id == 0)
            {
                return NotFound();
            }

            await UserService.DeleteByIdAsync(id);

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PERSONExists(short id)
        {
            return db.People.Count(e => e.IDUSER == id) > 0;
        }
    }
}