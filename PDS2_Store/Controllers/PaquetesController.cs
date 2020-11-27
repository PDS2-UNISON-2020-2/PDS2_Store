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
    public class PaquetesController : Controller
    {
        private PaqueteriasContext db = new PaqueteriasContext();

        // GET: Paquetes
        public async Task<ActionResult> Index()
        {
            var paquete = db.Paquete.Include(p => p.Paqueterias);
            return View(await paquete.ToListAsync());
        }

        // GET: Paquetes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paquete paquete = await db.Paquete.FindAsync(id);
            if (paquete == null)
            {
                return HttpNotFound();
            }
            return View(paquete);
        }

        // GET: Paquetes/Create
        public ActionResult Create(int Id)
        {
            ViewBag.PaqueteriasId = new SelectList(db.Paqueterias, "Id", "Nombre");
            return View();
        }

        // POST: Paquetes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Precio,DiasMin,DiasMax,Express,PaqueteriasId")] Paquete paquete)
        {
            if (ModelState.IsValid)
            {
                db.Paquete.Add(paquete);
                await db.SaveChangesAsync();
                return RedirectToAction("Index", "Paqueterias");
            }

            ViewBag.PaqueteriasId = new SelectList(db.Paqueterias, "Id", "Nombre", paquete.PaqueteriasId);
            return View(paquete);
        }

        // GET: Paquetes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paquete paquete = await db.Paquete.FindAsync(id);
            if (paquete == null)
            {
                return HttpNotFound();
            }
            ViewBag.PaqueteriasId = new SelectList(db.Paqueterias, "Id", "Nombre", paquete.PaqueteriasId);
            return View(paquete);
        }

        // POST: Paquetes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Precio,DiasMin,DiasMax,Express,PaqueteriasId")] Paquete paquete)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paquete).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index", "Paqueterias");
            }
            ViewBag.PaqueteriasId = new SelectList(db.Paqueterias, "Id", "Nombre", paquete.PaqueteriasId);
            return View(paquete);
        }

        // GET: Paquetes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paquete paquete = await db.Paquete.FindAsync(id);
            if (paquete == null)
            {
                return HttpNotFound();
            }
            return View(paquete);
        }

        // POST: Paquetes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Paquete paquete = await db.Paquete.FindAsync(id);
            db.Paquete.Remove(paquete);
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
