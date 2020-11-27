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
    public class CorreosController : Controller
    {
        private PaqueteriasContext db = new PaqueteriasContext();

        // GET: Correos
        public async Task<ActionResult> Index()
        {
            var correos = db.Correos.Include(c => c.Paqueterias);
            return View(await correos.ToListAsync());
        }

        // GET: Correos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Correos correos = await db.Correos.FindAsync(id);
            if (correos == null)
            {
                return HttpNotFound();
            }
            return View(correos);
        }

        // GET: Correos/Create
        public ActionResult Create(int Id)
        {
            ViewBag.PaqueteriasId = new SelectList(db.Paqueterias, "Id", "Nombre");
            return View();
        }

        // POST: Correos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,PaqueteriasId,correo")] Correos correos)
        {
            if (ModelState.IsValid)
            {
                db.Correos.Add(correos);
                await db.SaveChangesAsync();
                return RedirectToAction("Index", "Paqueterias");
            }

            ViewBag.PaqueteriasId = new SelectList(db.Paqueterias, "Id", "Nombre", correos.PaqueteriasId);
            return View(correos);
        }

        // GET: Correos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Correos correos = await db.Correos.FindAsync(id);
            if (correos == null)
            {
                return HttpNotFound();
            }
            ViewBag.PaqueteriasId = new SelectList(db.Paqueterias, "Id", "Nombre", correos.PaqueteriasId);
            return View(correos);
        }

        // POST: Correos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,PaqueteriasId,correo")] Correos correos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(correos).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index", "Paqueterias");
            }
            ViewBag.PaqueteriasId = new SelectList(db.Paqueterias, "Id", "Nombre", correos.PaqueteriasId);
            return View(correos);
        }

        // GET: Correos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Correos correos = await db.Correos.FindAsync(id);
            if (correos == null)
            {
                return HttpNotFound();
            }
            return View(correos);
        }

        // POST: Correos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Correos correos = await db.Correos.FindAsync(id);
            db.Correos.Remove(correos);
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
