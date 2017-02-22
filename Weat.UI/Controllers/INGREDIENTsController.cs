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
    public class INGREDIENTsController : Controller
    {
        private WeatEntities db = new WeatEntities();

        // GET: INGREDIENTs
        public async Task<ActionResult> Index()
        {
            var iNGREDIENTs = db.INGREDIENTs.Include(i => i.TYPEINGREDIENT);
            return View(await iNGREDIENTs.ToListAsync());
        }

        // GET: INGREDIENTs/Details/5
        public async Task<ActionResult> Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INGREDIENT iNGREDIENT = await db.INGREDIENTs.FindAsync(id);
            if (iNGREDIENT == null)
            {
                return HttpNotFound();
            }
            return View(iNGREDIENT);
        }

        // GET: INGREDIENTs/Create
        public ActionResult Create()
        {
            ViewBag.CODETYPEINGREDIENT = new SelectList(db.TYPEINGREDIENTs, "CODETYPEINGREDIENT", "CAPTION");
            return View();
        }

        // POST: INGREDIENTs/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IDINGREDIENT,CODETYPEINGREDIENT,URLIMAGE,NAMEINGREDIENT")] INGREDIENT iNGREDIENT)
        {
            if (ModelState.IsValid)
            {
                db.INGREDIENTs.Add(iNGREDIENT);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CODETYPEINGREDIENT = new SelectList(db.TYPEINGREDIENTs, "CODETYPEINGREDIENT", "CAPTION", iNGREDIENT.CODETYPEINGREDIENT);
            return View(iNGREDIENT);
        }

        // GET: INGREDIENTs/Edit/5
        public async Task<ActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INGREDIENT iNGREDIENT = await db.INGREDIENTs.FindAsync(id);
            if (iNGREDIENT == null)
            {
                return HttpNotFound();
            }
            ViewBag.CODETYPEINGREDIENT = new SelectList(db.TYPEINGREDIENTs, "CODETYPEINGREDIENT", "CAPTION", iNGREDIENT.CODETYPEINGREDIENT);
            return View(iNGREDIENT);
        }

        // POST: INGREDIENTs/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IDINGREDIENT,CODETYPEINGREDIENT,URLIMAGE,NAMEINGREDIENT")] INGREDIENT iNGREDIENT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iNGREDIENT).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CODETYPEINGREDIENT = new SelectList(db.TYPEINGREDIENTs, "CODETYPEINGREDIENT", "CAPTION", iNGREDIENT.CODETYPEINGREDIENT);
            return View(iNGREDIENT);
        }

        // GET: INGREDIENTs/Delete/5
        public async Task<ActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INGREDIENT iNGREDIENT = await db.INGREDIENTs.FindAsync(id);
            if (iNGREDIENT == null)
            {
                return HttpNotFound();
            }
            return View(iNGREDIENT);
        }

        // POST: INGREDIENTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(short id)
        {
            INGREDIENT iNGREDIENT = await db.INGREDIENTs.FindAsync(id);
            db.INGREDIENTs.Remove(iNGREDIENT);
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
