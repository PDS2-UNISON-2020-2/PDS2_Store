using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PDS2_Store.Models
{
    public class CarritoCompras
    {
        ProductContext carroDB = new ProductContext();
        string CarritoId { get; set; }
        public const string CarritoSessionKey = "CartId";

        public static CarritoCompras GetCart(HttpContextBase context)
        {
            var cart = new CarritoCompras();
            cart.CarritoId = cart.GetCartId(context);
            return cart;
        }

        // Metodo que ayuda a simplificar el llamado de los carros
        public static CarritoCompras GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }

        public void AddToCart(Producto producto)
        {
            // Get the matching cart and product instances
            var cartItem = carroDB.Carts.SingleOrDefault(
                c => c.CartId == CarritoId
                && c.ProductoId == producto.ProductoID);

            if (cartItem == null)
            {
                // Crea un nuevo cart item si no existe uno
                cartItem = new Cart
                {
                    ProductoId = producto.ProductoID,
                    CartId = CarritoId,
                    Quantity = 1,
                    DateCreated = DateTime.Now
                };
                carroDB.Carts.Add(cartItem);
            }
            else
            {
                // Si el producto ya existe en el carro, 
                // entonces se le agrega uno a la cantidad
                cartItem.Quantity++;
            }
            // Save changes
            carroDB.SaveChanges();
        }

        public int RemoveFromCart(int id)
        {
            // Get the cart
            var cartItem = carroDB.Carts.Single(
                cart => cart.CartId == CarritoId
                && cart.ItemId == id);

            int itemCount = 0;

            if (cartItem != null)
            {
                if (cartItem.Quantity > 1)
                {
                    cartItem.Quantity--;
                    itemCount = cartItem.Quantity;
                }
                else
                {
                    carroDB.Carts.Remove(cartItem);
                }
                // Save changes
                carroDB.SaveChanges();
            }
            return itemCount;
        }

        public void EmptyCart()
        {
            var cartItems = carroDB.Carts.Where(
                cart => cart.CartId == CarritoId);

            foreach (var cartItem in cartItems)
            {
                carroDB.Carts.Remove(cartItem);
            }
            // Save changes
            carroDB.SaveChanges();
        }

        public List<Cart> GetCartItems()
        {
            return carroDB.Carts.Where(
                cart => cart.CartId == CarritoId).ToList();
        }

        public int GetCount()
        {
            // Regresa el numero de productos en el carrito
            int? count = (from cartItems in carroDB.Carts
                          where cartItems.CartId == CarritoId
                          select (int?)cartItems.Quantity).Sum();
            // Return 0 if all entries are null
            return count ?? 0;
        }

        public decimal GetTotal()
        {
            // Calcula el total del carrito multiplicando el precio
            // de cada producto por su cantidad y se suma todo para
            // obtener el total.
            decimal? total = (from cartItems in carroDB.Carts
                              where cartItems.CartId == CarritoId
                              select (int?)cartItems.Quantity *
                              cartItems.Product.UnitPrice).Sum();

            return total ?? decimal.Zero;
        }

        public int CreateOrder(Compra compra)
        {
            decimal orderTotal = 0;

            var cartItems = GetCartItems();
            // Iterate over the items in the cart, 
            // adding the order details for each
            foreach (var item in cartItems)
            {
                var orderDetail = new DetallesCompra
                {
                    ProductoId = item.ProductoId,
                    CompraId = compra.CompraId,
                    UnitPrice = item.Product.UnitPrice,
                    Quantity = item.Quantity
                };
                // Set the order total of the shopping cart
                orderTotal += (item.Quantity * item.Product.UnitPrice);

                carroDB.Detalles.Add(orderDetail);

            }
            // Set the order's total to the orderTotal count
            compra.Total = orderTotal;

            // Save the order
            carroDB.SaveChanges();
            // Empty the shopping cart
            EmptyCart();
            // Return the OrderId as the confirmation number
            return compra.CompraId;
        }

        // We're using HttpContextBase to allow access to cookies.
        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CarritoSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CarritoSessionKey] =
                        context.User.Identity.Name;
                }
                else
                {
                    // Generate a new random GUID using System.Guid class
                    Guid tempCartId = Guid.NewGuid();
                    // Send tempCartId back to client as a cookie
                    context.Session[CarritoSessionKey] = tempCartId.ToString();
                }
            }
            return context.Session[CarritoSessionKey].ToString();
        }

        // When a user has logged in, migrate their shopping cart to
        // be associated with their username
        public void MigrateCart(string userName)
        {
            var shoppingCart = carroDB.Carts.Where(
                c => c.CartId == CarritoId);

            foreach (Cart item in shoppingCart)
            {
                item.CartId = userName;
            }
            carroDB.SaveChanges();
        }
    }
}