using System;
using System.Collections.Generic;
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
}