using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Weat.Dal.SqlServer.DataModel;
using Weat.Entities.DataModel;

namespace Weat.UI.Controllers
{
    public class PeopleController : Controller
    {
        private WeatEntities db = new WeatEntities();

        // GET: People
        public async Task<ActionResult> Index()
        {
            return View(await db.People.ToListAsync());
        }

        // GET: People/Details/5
        public async Task<ActionResult> Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERSON pERSON = await db.People.FindAsync(id);
            if (pERSON == null)
            {
                return HttpNotFound();
            }
            return View(pERSON);
        }

        // GET: People/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: People/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IDUSER,FIRSTNAME,LASTNAME,PSEUDO,PASSWORD")] PERSON pERSON)
        {
            if (ModelState.IsValid)
            {
                db.People.Add(pERSON);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(pERSON);
        }

        // GET: People/Edit/5
        public async Task<ActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERSON pERSON = await db.People.FindAsync(id);
            if (pERSON == null)
            {
                return HttpNotFound();
            }
            return View(pERSON);
        }

        // POST: People/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IDUSER,FIRSTNAME,LASTNAME,PSEUDO,PASSWORD")] PERSON pERSON)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pERSON).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(pERSON);
        }

        // GET: People/Delete/5
        public async Task<ActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERSON pERSON = await db.People.FindAsync(id);
            if (pERSON == null)
            {
                return HttpNotFound();
            }
            return View(pERSON);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(short id)
        {
            PERSON pERSON = await db.People.FindAsync(id);
            db.People.Remove(pERSON);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
