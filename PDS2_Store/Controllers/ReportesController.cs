using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PDS2_Store.Models;
using PDS2_Store.RepositorioDapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PDS2_Store.Controllers
{
    public class ReportesController : Controller
    {
        private ProductContext db = new ProductContext();
        // GET: Reportes
        public ActionResult Index()
        {
            return View();
        }

        // GET: ReportesEstados
        public ActionResult ReporteEstado()
        {
            return View();
        }

        public ActionResult Estado(string estado)
        {
            ViewBag.message = estado;
            RepoDapper Repo = new RepoDapper();
            var est = Repo.ReporteEstado(estado);
            return View(est);
        }

        public ActionResult ReporteCategoria()
        {
            var categ = db.Categorias.ToList();
            return View(categ);
        }

        public ActionResult Categoria(string categoria)
        {
            ViewBag.message = categoria;
            RepoDapper Repo = new RepoDapper();
            var est = Repo.ReporteCategoria(categoria);
            return View(est);
        }

        public ActionResult ReporteProducto()
        {
            var prod = db.CatProductos.ToList();
            return View(prod);
        }

        public ActionResult Producto(string producto)
        {
            ViewBag.message = producto;
            RepoDapper Repo = new RepoDapper();
            var est = Repo.ReporteProducto(producto);
            return View(est);
        }

        public ActionResult ReporteCliente()
        {
            var context = new IdentityDbContext();
            var usersWithRoles = (from user in context.Users
                                  select new 
                                  {
                                      UserId = user.Id,
                                      Username = user.UserName,
                                      RoleNames = (from userRole in user.Roles
                                                   join role in context.Roles on userRole.RoleId
                                                   equals role.Id
                                                   select role.Name ).ToList()
                                  }).ToList().Select(p => new UsersViewModel()

                                  {
                                      Userid = p.UserId,
                                      UserName = p.Username,
                                      Role = string.Join(",", p.RoleNames)
                                  }); 

            return View(usersWithRoles);
        
        }
           
    

        public ActionResult Cliente(string cliente)
        {
            RepoDapper Repo = new RepoDapper();
            var est = Repo.ReporteCliente(cliente);
            return View(est);
        }

        public ActionResult ReporteVendedor()
        {
            var ven = db.Vendedores.ToList();
            return View(ven);
        }

        public ActionResult Vendedor(string vendedor)
        {
            ViewBag.vendor = vendedor;
            RepoDapper Repo = new RepoDapper();
            var est = Repo.ReporteVendedor(vendedor);
            return View(est);
        }
    }
}