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
    public class FRIDGEsController : Controller
    {
        private WeatEntities db = new WeatEntities();

        // GET: FRIDGEs
        public async Task<ActionResult> Index()
        {
            var fRIDGEs = db.FRIDGEs.Include(f => f.PERSON).Include(f => f.TYPEFRIDGE);
            return View(await fRIDGEs.ToListAsync());
        }

        // GET: FRIDGEs/Details/5
        public async Task<ActionResult> Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FRIDGE fRIDGE = await db.FRIDGEs.FindAsync(id);
            if (fRIDGE == null)
            {
                return HttpNotFound();
            }
            return View(fRIDGE);
        }

        // GET: FRIDGEs/Create
        public ActionResult Create()
        {
            ViewBag.IDUSER = new SelectList(db.People, "IDUSER", "FIRSTNAME");
            ViewBag.CODETYPEFRIDGE = new SelectList(db.TYPEFRIDGEs, "CODETYPEFRIDGE", "CAPTION");
            return View();
        }

        // POST: FRIDGEs/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IDFRIDGE,CODETYPEFRIDGE,IDUSER,NAMEFRIDGE")] FRIDGE fRIDGE)
        {
            if (ModelState.IsValid)
            {
                db.FRIDGEs.Add(fRIDGE);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IDUSER = new SelectList(db.People, "IDUSER", "FIRSTNAME", fRIDGE.IDUSER);
            ViewBag.CODETYPEFRIDGE = new SelectList(db.TYPEFRIDGEs, "CODETYPEFRIDGE", "CAPTION", fRIDGE.CODETYPEFRIDGE);
            return View(fRIDGE);
        }

        // GET: FRIDGEs/Edit/5
        public async Task<ActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FRIDGE fRIDGE = await db.FRIDGEs.FindAsync(id);
            if (fRIDGE == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDUSER = new SelectList(db.People, "IDUSER", "FIRSTNAME", fRIDGE.IDUSER);
            ViewBag.CODETYPEFRIDGE = new SelectList(db.TYPEFRIDGEs, "CODETYPEFRIDGE", "CAPTION", fRIDGE.CODETYPEFRIDGE);
            return View(fRIDGE);
        }

        // POST: FRIDGEs/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IDFRIDGE,CODETYPEFRIDGE,IDUSER,NAMEFRIDGE")] FRIDGE fRIDGE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fRIDGE).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IDUSER = new SelectList(db.People, "IDUSER", "FIRSTNAME", fRIDGE.IDUSER);
            ViewBag.CODETYPEFRIDGE = new SelectList(db.TYPEFRIDGEs, "CODETYPEFRIDGE", "CAPTION", fRIDGE.CODETYPEFRIDGE);
            return View(fRIDGE);
        }

        // GET: FRIDGEs/Delete/5
        public async Task<ActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FRIDGE fRIDGE = await db.FRIDGEs.FindAsync(id);
            if (fRIDGE == null)
            {
                return HttpNotFound();
            }
            return View(fRIDGE);
        }

        // POST: FRIDGEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(short id)
        {
            FRIDGE fRIDGE = await db.FRIDGEs.FindAsync(id);
            db.FRIDGEs.Remove(fRIDGE);
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
