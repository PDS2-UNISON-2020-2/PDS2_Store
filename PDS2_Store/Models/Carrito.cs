using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace PDS2_Store.Models
{
    public class Cart
    {
        [Key]
        public int ItemId { get; set; }

        //Este va ser el ID con el que se asocie a el usuario
        public string CartId { get; set; }

        [Display(Name = "Cantidad del producto")]
        public int Quantity { get; set; }

        public System.DateTime DateCreated { get; set; }

        public int ProductoId { get; set; }

        public virtual Producto Product { get; set; }
    }


    public partial class Compra
    {
        public int CompraId { get; set; }
        public string UserId { get; set; }
        public int DireccionId { get; set; }
        public int TarjetaId { get; set; }
        public decimal Total { get; set; }
        public System.DateTime FechaCompra { get; set; }
        public List<DetallesCompra> Detalles { get; set; }
    }

    public class DetallesCompra
    {
        public int DetallesCompraId { get; set; }
        public int CompraId { get; set; }
        public int ProductoId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public virtual Producto Producto { get; set; }
        public virtual Compra Compra { get; set; }
    }
}