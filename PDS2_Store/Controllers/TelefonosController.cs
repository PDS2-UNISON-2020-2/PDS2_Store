using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PDS2_Store.Models;

namespace PDS2_Store.Controllers
{
    public class TelefonosController : Controller
    {
        private PaqueteriasContext db = new PaqueteriasContext();

        // GET: Telefonos
        public async Task<ActionResult> Index()
        {
            var telefonos = db.Telefonos.Include(t => t.Paqueterias);
            return View(await telefonos.ToListAsync());
        }

        // GET: Telefonos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Telefonos telefonos = await db.Telefonos.FindAsync(id);
            if (telefonos == null)
            {
                return HttpNotFound();
            }
            return View(telefonos);
        }

        // GET: Telefonos/Create
        public ActionResult Create(int Id)
        {
            ViewBag.PaqueteriasId = new SelectList(db.Paqueterias, "Id", "Nombre");
            return View();
        }

        // POST: Telefonos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,PaqueteriasId,telefono")] Telefonos telefonos)
        {
            if (ModelState.IsValid)
            {
                db.Telefonos.Add(telefonos);
                await db.SaveChangesAsync();
                return RedirectToAction("Index", "Paqueterias");
            }

            ViewBag.PaqueteriasId = new SelectList(db.Paqueterias, "Id", "Nombre", telefonos.PaqueteriasId);
            return View(telefonos);
        }

        // GET: Telefonos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Telefonos telefonos = await db.Telefonos.FindAsync(id);
            if (telefonos == null)
            {
                return HttpNotFound();
            }
            ViewBag.PaqueteriasId = new SelectList(db.Paqueterias, "Id", "Nombre", telefonos.PaqueteriasId);
            return View(telefonos);
        }

        // POST: Telefonos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,PaqueteriasId,telefono")] Telefonos telefonos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(telefonos).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index", "Paqueterias");
            }
            ViewBag.PaqueteriasId = new SelectList(db.Paqueterias, "Id", "Nombre", telefonos.PaqueteriasId);
            return View(telefonos);
        }

        // GET: Telefonos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Telefonos telefonos = await db.Telefonos.FindAsync(id);
            if (telefonos == null)
            {
                return HttpNotFound();
            }
            return View(telefonos);
        }

        // POST: Telefonos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Telefonos telefonos = await db.Telefonos.FindAsync(id);
            db.Telefonos.Remove(telefonos);
            await db.SaveChangesAsync();
            return RedirectToAction("Index", "Paqueterias");
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
