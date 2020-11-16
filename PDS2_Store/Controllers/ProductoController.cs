using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages.Html;
using PDS2_Store.Models;
using PDS2_Store.RepositorioDapper;

namespace PDS2_Store.Controllers
{
    public class ProductoController : Controller
    {
        private ProductContext db = new ProductContext();

        // GET: Productoes
        public ActionResult Index()
        {
            var productos = db.Productos.Include(p => p.Vendedor);      
            return View(productos.ToList());
        }

        //Lista de categorias con EF
        public ActionResult Categorias()
        {
            var categ = db.Categorias.ToList();
            return View(categ);
        }
        //Lista de subcategorias con EF
        public ActionResult SubCategoria(string categoria)
        {
            //categoria = "Ropa, Zapatos y Accesorios";
            var categ = db.CatProductos.Where(c => c.Categoria.CategoryName == categoria);
            return View(categ.ToList());
        }


        // GET: Categorias
        // Esta para la vista de los productos por categorias
        // No sirve asi como esta, mejor voy a crear una vista para mandarla a llamar o si conoces una forma de hacerlo aqui mejor
        public ActionResult CategoriaView(string categoria)
        {
            //este se debe quitar cuando se lige la vista con la principal por el momento es para que muestre una categoria
            categoria = "Ropa Mujeres";
            //
            // Regresa la categoria con sus productos
            var categ = db.Productos.Include(p => p.Vendedor).Where(c => c.CatProducto.CatNombre == categoria);
            return View(categ.ToList());
        }

        //Lista de categorias con dapper
        public ActionResult CategoriasDapper()
        {
            RepoDapper EmpRepo = new RepoDapper();
            var categ = EmpRepo.GetCategorias();
            return View(categ);
        }
        //Lista de subcategorias con dapper
        public ActionResult SubCategoriaDapper(string categoria)
        {
            //categoria = "Ropa, Zapatos y Accesorios";
            RepoDapper EmpRepo = new RepoDapper();
            var categ = EmpRepo.GetSubCategorias(categoria);
            return View(categ);
        }
        //Lista de productos con dapper
        public ActionResult ProductosDapper(string categ)
        {
            //categ = "Ropa Mujeres";
            RepoDapper EmpRepo = new RepoDapper();
            var prod = EmpRepo.GetSubCategorias(categ);
            return View(prod);
        }


        // GET: Productoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Productos.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // GET: Productoes/Create
        public ActionResult Create()
        {
            ViewBag.CatProductoId = new SelectList(db.CatProductos, "CatProductoId", "CatNombre");
            ViewBag.VendedorID = new SelectList(db.Vendedores, "VendedorId", "UserId");
            return View();
        }

        // POST: Productoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductoID,ProductName,Description, Imagen,UnitPrice,Cantidad,CatProductoId,VendedorID")] Producto producto, HttpPostedFileBase foto)
        {
            if (ModelState.IsValid)
            {
                byte[] image = new byte[foto.ContentLength];
                foto.InputStream.Read(image, 0, Convert.ToInt32(foto.ContentLength));
                producto.Imagen = image;

                db.Productos.Add(producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CatProductoId = new SelectList(db.CatProductos, "CatProductoId", "CatNombre");
            ViewBag.VendedorID = new SelectList(db.Vendedores, "VendedorId", "UserId", producto.VendedorID);
            return View(producto);
        }

        // GET: Productoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Productos.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.CatProductoId = new SelectList(db.CatProductos, "CatProductoId", "CatNombre");
            ViewBag.VendedorID = new SelectList(db.Vendedores, "VendedorId", "UserId", producto.VendedorID);
            return View(producto);
        }

        // POST: Productoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductoID,ProductName,Description,Imagen,UnitPrice,Cantidad,CatProductoId,VendedorID")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CatProductoId = new SelectList(db.CatProductos, "CatProductoId", "CatNombre");
            ViewBag.VendedorID = new SelectList(db.Vendedores, "VendedorId", "UserId", producto.VendedorID);
            return View(producto);
        }

        // GET: Productoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Productos.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Productoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Producto producto = db.Productos.Find(id);
            db.Productos.Remove(producto);
            db.SaveChanges();
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
