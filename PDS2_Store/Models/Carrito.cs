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
        public int CartId { get; set; }

        //Este va ser el ID con el que se asocie a el usuario
        public string UserId { get; set; }

        [Display(Name = "Cantidad del producto")]
        public int Quantity { get; set; }

        public System.DateTime DateCreated { get; set; }

        public int ProductoId { get; set; }

        public virtual Producto Product { get; set; }
    }


    public partial class Compra
    {
        public int CompraId { get; set; }
        [StringLength(128)]
        [Display(Name = "#")]
        public string UserId { get; set; }
        [Display(Name = "Dirección")]
        public int DireccionId { get; set; }
        [Display(Name = "Tarjeta")]
        public int TarjetaId { get; set; }
        [Display(Name = "Paquetería")]
        public int PaqueteriaId { get; set; }
        [Display(Name = "Express?")]
        public bool Express { get; set; }
        public decimal Total { get; set; }
        [Display(Name = "Fecha de compra")]
        public System.DateTime FechaCompra { get; set; }
        public List<DetallesCompra> Detalles { get; set; }
    }

    public class DetallesCompra
    {
        public int DetallesCompraId { get; set; }
        [Display(Name = "#")]
        public int CompraId { get; set; }
        [Display(Name = "Producto")]
        public int ProductoId { get; set; }
        [Display(Name = "Cant.")]
        public int Quantity { get; set; }
        [Display(Name = "Precio")]
        public decimal UnitPrice { get; set; }
        public virtual Producto Producto { get; set; }
        public virtual Compra Compra { get; set; }
    }
}