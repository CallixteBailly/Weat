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
    public class FridgesController : ApiController
    {
        private IUserService UserService => UnityConfig.Resolve<IUserService>();
        private WeatEntities db = new WeatEntities();

        // GET: api/Fridges

        public List<FRIDGE> GetFRIDGEs()
        {
            return db.FRIDGEs.ToList();
        }

        // GET: api/Fridges/5
        [ResponseType(typeof(FRIDGE))]
        public async Task<IHttpActionResult> GetFRIDGE(short id)
        {
            FRIDGE fRIDGE = await db.FRIDGEs.FindAsync(id);
            if (fRIDGE == null)
            {
                return NotFound();
            }

            return Ok(fRIDGE);
        }

        // PUT: api/Fridges/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFRIDGE(short id, FRIDGE fRIDGE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fRIDGE.IDFRIDGE)
            {
                return BadRequest();
            }

            db.Entry(fRIDGE).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FRIDGEExists(id))
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

        // POST: api/Fridges
        [ResponseType(typeof(FRIDGE))]
        public async Task<IHttpActionResult> PostFRIDGE(FRIDGE fRIDGE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FRIDGEs.Add(fRIDGE);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = fRIDGE.IDFRIDGE }, fRIDGE);
        }

        // DELETE: api/Fridges/5
        [ResponseType(typeof(FRIDGE))]
        public async Task<IHttpActionResult> DeleteFRIDGE(short id)
        {
            FRIDGE fRIDGE = await db.FRIDGEs.FindAsync(id);
            if (fRIDGE == null)
            {
                return NotFound();
            }

            db.FRIDGEs.Remove(fRIDGE);
            await db.SaveChangesAsync();

            return Ok(fRIDGE);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FRIDGEExists(short id)
        {
            return db.FRIDGEs.Count(e => e.IDFRIDGE == id) > 0;
        }
    }
}