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
}