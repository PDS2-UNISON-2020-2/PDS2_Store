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
        public int StatusId { get; set; }
        public int RequestId { get; set; }
    }

    public class RequestViewModel
    {
        [Display(Name = "ID de la solicitud")]
        public int id { get; set; }
        public string PrimerNombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string RFC { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string Estado { get; set; }
        public string Ciudad { get; set; }
        [Display(Name = "Estado de la solicitud")]
        public string State { get; set; }
    }
}