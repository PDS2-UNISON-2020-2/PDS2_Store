﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using Microsoft.AspNet.Identity;
using PDS2_Store.Models;
using PDS2_Store.RepositorioDapper;
using System.Data.Entity;


namespace PDS2_Store.Controllers
{
    [Authorize(Roles = "cliente")]
    public class CarritoComprasController : Controller
    {
        ProductContext carroDB = new ProductContext();

        // GET: CarritoCompras
        public ActionResult Index()
        {
            var cart = CarritoCompras.GetCart(HttpContext);

            // Set up our ViewModel
            var viewModel = new CarritoComprasViewModels
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };
            // Return the view
            return View(viewModel);
        }

        // GET: /Store/AddToCart/5
        public ActionResult AddToCart(int id)
        {
            // Retrieve the album from the database
            var addedItem = carroDB.Productos
                .Single(Producto => Producto.ProductoID == id);

            // Add it to the shopping cart
            var cart = CarritoCompras.GetCart(HttpContext);

            cart.AddToCart(addedItem);

            // Go back to the main store page for more shopping
            return RedirectToAction("Index");
        }
        
        //Update porque no entendi como usar el otro metodo (el metodo de abajo es el original)
        // GET: /Store/AddToCart/5
        public ActionResult RemoveFromCartItem(int id)
        {
            // Get the cart
            var cart = CarritoCompras.GetCart(HttpContext);
            cart.RemoveFromCart(id);
            // Go back to the main store page for more shopping
            return RedirectToAction("Index");
        }
        //Eliminar todos los productos del carrito
        public ActionResult VaciarCarrito()
        {
            // Get the cart
            var cart = CarritoCompras.GetCart(HttpContext);
            cart.EmptyCart();
            // Go back to the main store page for more shopping
            return RedirectToAction("Index");
        }
        //Eliminar producto del carrito
        public ActionResult RemoveFromCartProducto(int id)
        {
            // Get the cart
            var cart = CarritoCompras.GetCart(HttpContext);
            cart.RemoveFromCartProducto(id);
            // Go back to the main store page for more shopping
            return RedirectToAction("Index");
        }


        /*/ AJAX: /ShoppingCart/RemoveFromCart/5
        //Este metodo usa AJAX Updates con JQuery
        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            // Remove the item from the cart
            var cart = CarritoCompras.GetCart(HttpContext);

            // Get the name of the album to display confirmation
            string productName = carroDB.Carts
                .Single(item => item.ItemId == id).Product.ProductName;

            // Remove from cart
            int itemCount = cart.RemoveFromCart(id);

            // Display the confirmation message
            var results = new CarritoComprasRemoveViewModel
            {
                Message = Server.HtmlEncode(productName) +
                    " ha sido removido de tu carrito de compra.",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };
            return RedirectToAction("Index");
        }*/

        // GET: /ShoppingCart/CartSummary
        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = CarritoCompras.GetCart(HttpContext);

            ViewData["CartCount"] = cart.GetCount();
            return PartialView("_CartSummary");
        }


        //
        // GET: /CarritoCompras/Compra
        public ActionResult Compra()
        {
            var userid = User.Identity.GetUserId();

            RepoDapper EmpRepo = new RepoDapper();
            //ViewBag.TarjetaId = new SelectList(EmpRepo.GetTarjetas(userid), "id", "Numero");
            ViewBag.DireccionID = new SelectList(EmpRepo.GetDirecciones(userid), "id", "Direccion");
            ViewBag.DireccionID2 = EmpRepo.GetDirecciones(userid);
            ViewBag.TarjetaId2 = EmpRepo.GetTarjetas(userid);
            //ViewBag.PaqueteriaID = new SelectList(EmpRepo.GetEnvios(), "id", "Nombre");

            PaqueteriasContext paqueteriasDB = new PaqueteriasContext();
            List<Paqueterias> p = paqueteriasDB.Paqueterias.Include(x => x.pqt).Where(t => t.Activo == true).ToList();
            ViewBag.PaqueteriaId = p;

            var cart = CarritoCompras.GetCart(this.HttpContext);
            ViewBag.Total = cart.GetTotal();

            List<Cart> carrito = cart.GetCartItems();
            ViewBag.Carrito = carrito;
            ViewBag.CarritoTotal = carrito.Count();

            return View();
        }

        //
        // POST: /CarritoCompras/Compra
        [HttpPost]
        public ActionResult Compra(Compra compra)
        {
            TryUpdateModel(compra);
            var userid = User.Identity.GetUserId();
            RepoDapper EmpRepo = new RepoDapper();
            ViewBag.TarjetaId2 = new SelectList(EmpRepo.GetTarjetas(userid), "id", "Numero");
            if (compra.TarjetaId == 0)
            {
                return RedirectToAction("AddTarjeta", "Manage");
            }
            ViewBag.DireccionID = new SelectList(EmpRepo.GetDirecciones(userid), "id", "Direccion");
            ViewBag.PaqueteriaID = new SelectList(EmpRepo.GetEnvios(), "id", "Nombre", compra.PaqueteriaId);

            PaqueteriasContext paqueteriasDB = new PaqueteriasContext();
            int _PaqueteriasId = paqueteriasDB.Paquete.Where(x => x.Id == compra.PaqueteriaId).Select(x => x.PaqueteriasId).FirstOrDefault();
            int _precioEnvio = (int)paqueteriasDB.Paquete.Where(x => x.Id == compra.PaqueteriaId).Select(x => x.Precio).FirstOrDefault();
            
            compra.UserId = userid;
            compra.FechaCompra = DateTime.Now;
            compra.PaqueteriaId = _PaqueteriasId;

            var cart = CarritoCompras.GetCart(this.HttpContext);
            int _subtotal = (int)cart.GetTotal();
            int _total = _precioEnvio + _subtotal;
            compra.Total = _total;

            try
            {

                carroDB.Compras.Add(compra);
                carroDB.SaveChanges();
                cart.CreateOrder(compra, _precioEnvio);

                return RedirectToAction("Index", "Compras");
            }
            catch
            {
                return View(compra);
            }
            
        }
    }
}