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
        [Display(Name = "ID de la solicitud")]
        public int id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string correo { get; set; }
        public int celular { get; set; }
        public string RFC { get; set; }
        public string Direccion { get; set; }
        public int CodigoPostal { get; set; }
        public string Estado { get; set; }
        public string Ciudad { get; set; }
        [StringLength(128)]
        public string UserId { get; set; }
    }
}