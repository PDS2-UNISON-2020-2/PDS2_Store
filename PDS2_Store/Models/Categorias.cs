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

        [Required, StringLength(100), Display(Name = "Nombre de la categoria")]
        public string CategoryName { get; set; }
    }

    public class CatProducto
    {
        public int CatProductoId { get; set; }

        public string CatNombre { get; set; }

        public int CategoriaID { get; set; }

        public virtual Categoria Categoria { get; set; }

        public virtual List<Producto> Products { get; set; }
    }
}