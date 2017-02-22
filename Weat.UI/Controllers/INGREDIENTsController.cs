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
using Weat.Dal.SqlServer.DataModel;
using Weat.Entities.DataModel;

namespace Weat.UI.Controllers
{
    public class IngredientsController : ApiController
    {
        private WeatEntities db = new WeatEntities();

        // GET: api/Ingredients
        public IQueryable<INGREDIENT> GetINGREDIENTs()
        {
            return db.INGREDIENTs;
        }

        // GET: api/Ingredients/5
        [ResponseType(typeof(INGREDIENT))]
        public async Task<IHttpActionResult> GetINGREDIENT(short id)
        {
            INGREDIENT iNGREDIENT = await db.INGREDIENTs.FindAsync(id);
            if (iNGREDIENT == null)
            {
                return NotFound();
            }

            return Ok(iNGREDIENT);
        }

        // PUT: api/Ingredients/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutINGREDIENT(short id, INGREDIENT iNGREDIENT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != iNGREDIENT.IDINGREDIENT)
            {
                return BadRequest();
            }

            db.Entry(iNGREDIENT).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!INGREDIENTExists(id))
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

        // POST: api/Ingredients
        [ResponseType(typeof(INGREDIENT))]
        public async Task<IHttpActionResult> PostINGREDIENT(INGREDIENT iNGREDIENT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.INGREDIENTs.Add(iNGREDIENT);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = iNGREDIENT.IDINGREDIENT }, iNGREDIENT);
        }

        // DELETE: api/Ingredients/5
        [ResponseType(typeof(INGREDIENT))]
        public async Task<IHttpActionResult> DeleteINGREDIENT(short id)
        {
            INGREDIENT iNGREDIENT = await db.INGREDIENTs.FindAsync(id);
            if (iNGREDIENT == null)
            {
                return NotFound();
            }

            db.INGREDIENTs.Remove(iNGREDIENT);
            await db.SaveChangesAsync();

            return Ok(iNGREDIENT);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool INGREDIENTExists(short id)
        {
            return db.INGREDIENTs.Count(e => e.IDINGREDIENT == id) > 0;
        }
    }
}