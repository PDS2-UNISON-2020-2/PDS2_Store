using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PDS2_Store.Models
{
    public class ReporteEstadoViewModels
    {
        public string Ciudad { get; set; }
        [Display(Name = "Compra ID")]
        public int CompraId { get; set; }
        [Display(Name = "Fecha de la venta")]
        public DateTime FechaVenta { get; set; }
        [Display(Name = "Comprador")]
        public string UserName { get; set; }
        [Display(Name = "Total de la compra")]
        public decimal Total { get; set; }
    }

    public class ReporteCategoriaViewModel
    {
        [Display(Name = "Productos")]
        public string CatNombre { get; set; }
        [Display(Name = "Compra ID")]
        public int CompraId { get; set; }
        [Display(Name = "Fecha de la venta")]
        public DateTime FechaCompra { get; set; }
        [Display(Name = "Nombre del Producto")]
        public string ProductName { get; set; }
        [Display(Name = "Cantidad")]
        public int Quantity { get; set; }
        [Display(Name = "Precio")]
        public decimal UnitPrice { get; set; }
        [Display(Name = "Importe de productos")]
        public decimal ImporteProducto { get; set; }
    }

    public class ReporteProductoViewModel
    {
        [Display(Name = "Nombre del Producto")]
        public string ProductName { get; set; }
        [Display(Name = "Compra ID")]
        public int CompraId { get; set; }
        [Display(Name = "Fecha de la venta")]
        public DateTime FechaCompra { get; set; } 
        [Display(Name = "Cantidad")]
        public int Quantity { get; set; }
        [Display(Name = "Precio")]
        public decimal UnitPrice { get; set; }
        [Display(Name = "Importe de productos")]
        public decimal ImporteProducto { get; set; }
    }

    public class ReporteClienteViewModel
    {
        [Display(Name = "Compra ID")]
        public int CompraId { get; set; }
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }
        [Display(Name = "Titular de la tarjeta")]
        public string Titular { get; set; }
        [Display(Name = "Tarjeta")]
        public long Numero { get; set; }
        [Display(Name = "Fecha de Expiración")]
        public DateTime Fecha { get; set; }
        [Display(Name = "Paqueteria")]
        public string Nombre { get; set; }
        [Display(Name = "Fecha de la compra")]
        public DateTime FechaCompra { get; set; }
        [Display(Name = "Nombre del Producto")]
        public string ProductName { get; set; }
        [Display(Name = "Vendedor")]
        public string UserId { get; set; }
        [Display(Name = "Cantidad")]
        public int Quantity { get; set; }
        [Display(Name = "Importe de productos")]
        public decimal ImporteProducto { get; set; }
        [Display(Name = "Total de la compra")]
        public decimal Total { get; set; }
    }

    public class ReporteVendedorViewModel
    {
        [Display(Name = "Compra ID")]
        public int CompraId { get; set; }
        [Display(Name = "Nombre del Producto")]
        public string ProductName { get; set; }
        [Display(Name = "Cantidad")]
        public int Quantity { get; set; }
        [Display(Name = "Precio")]
        public decimal UnitPrice { get; set; }
        [Display(Name = "Importe de productos")]
        public decimal ImporteProducto { get; set; }
        [Display(Name = "Fecha de la venta")]
        public DateTime FechaCompra { get; set; }
        [Display(Name = "Comprador")]
        public string UserName { get; set; }

    }
}