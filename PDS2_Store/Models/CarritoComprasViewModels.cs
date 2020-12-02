using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PDS2_Store.Models
{
    public class CarritoComprasViewModels
    {
        public List<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }

    public class CarritoComprasRemoveViewModel
    {
        public string Message { get; set; }
        public decimal CartTotal { get; set; }
        public int CartCount { get; set; }
        public int ItemCount { get; set; }
        public int DeleteId { get; set; }
    }


    public class MisPedidosViewModel
    {
        [Display(Name = "Compra ID")]
        public int CompraId { get; set; }
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }
        [Display(Name = "Tarjeta")]
        public long Numero { get; set; }
        [Display(Name = "Paqueteria")]
        public string Nombre { get; set; }
        [Display(Name = "Total de la compra")]
        public decimal Total { get; set; }
        [Display(Name = "Fecha de la compra")]
        public DateTime FechaCompra { get; set; }

    }

    public class MisPedidosDetallesViewModel
    {
        [Display(Name = "Compra ID")]
        public int CompraId { get; set; }
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }
        public int CodigoPostal { get; set; }
        public string Estado { get; set; }
        public string Ciudad { get; set; }
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
        [Display(Name = "Total de la compra")]
        public decimal Total { get; set; }
    }
}