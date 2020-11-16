using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PDS2_Store.Models
{
    public class Admin : IdentityUser
    {
    }

    public class RequestStatus
    {
        public int RequestStatusId { get; set; }
        [Display(Name = "Estado de la solicitud")]
        public string Status { get; set; }
        public int RequestId { get; set; }
        public virtual Request Request { get; set; }
    }

    public class RequestViewModel
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
        [Display(Name = "Estado de la solicitud")]
        public string Esta { get; set; }
    }
}