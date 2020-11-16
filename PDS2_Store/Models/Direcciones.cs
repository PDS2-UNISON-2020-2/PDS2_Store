using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PDS2_Store.Models
{
    public class Direccion
    {
        public int id { get; set; }
        public string direccion { get; set; }
        public int CodigoPostal { get; set; }
        public string Estado { get; set; }
        public string Ciudad { get; set; }
    }

    public class Direcciones
    {
        [StringLength(128)]
        public string UserId { get; set; }
        public int DireccionId { get; set; }
        public virtual Direccion Direccion { get; set; }
    }

    public class DireccionViewModel
    {
        public int id { get; set; }
        public string direccion { get; set; }
        public int CodigoPostal { get; set; }
        public string Estado { get; set; }
        public string Ciudad { get; set; }
        [StringLength(128)]
        public string UserId { get; set; }
    }
}