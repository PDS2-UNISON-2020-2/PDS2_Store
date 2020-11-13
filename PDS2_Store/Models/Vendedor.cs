using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PDS2_Store.Models
{
    public class Vendedor
    {
        // modelo temporal mientras no tenemos lo de vendedores
        [ScaffoldColumn(false)]
        public int VendedorId { get; set; }

        [StringLength(128)]
        public string UserId { get; set; }

    }

    public class Request
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Email { get; set; }
        public int Telefono { get; set; }
        public string RFC { get; set; }
        public string Direccion { get; set; }
        public int Postal { get; set; }
        public string Estado { get; set; }
        public string Ciudad { get; set; }
        [StringLength(128)]
        public string UserId { get; set; }
    }
}