using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PDS2_Store.Models;

namespace PDS2_Store.Controllers
{
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


        // AJAX: /ShoppingCart/RemoveFromCart/5
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
        }

        // GET: /ShoppingCart/CartSummary
        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = CarritoCompras.GetCart(HttpContext);

            ViewData["CartCount"] = cart.GetCount();
            return PartialView("CartSummary");
        }

    }
}