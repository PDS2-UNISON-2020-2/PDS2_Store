using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PDS2_Store.Models
{
    public class Tarjeta
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public long Numero { get; set; }
        public DateTime Fecha { get; set; }
        public int Codigo { get; set; }
    }

    public class Tarjetas
    {
        [StringLength(128)]
        public string UserId { get; set; }
        public int TarjetaId { get; set; }
        public virtual Tarjeta Tarjeta { get; set; }
    }

    public class TarjetaViewModel
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public long Numero { get; set; }
        public DateTime Fecha { get; set; }
        public int Codigo { get; set; }
        [StringLength(128)]
        public string UserId { get; set; }
    }
}