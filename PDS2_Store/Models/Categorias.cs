using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PDS2_Store.Models
{
    public class Categoria
    {
        [ScaffoldColumn(false)]
        public int CategoriaID { get; set; }

        [Required, StringLength(100), Display(Name = "Nombre de la categoria"), DataType(DataType.Text)]
        public string CategoryName { get; set; }

        public virtual ICollection<Producto> Products { get; set; }
    }
}