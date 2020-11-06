using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel;

namespace PDS2_Store.Models
{
    public class Producto
    {
        [ScaffoldColumn(false)]
        public int ProductoID { get; set; }

        [Required(ErrorMessage = "Se requiere un titulo del producto")]
        [StringLength(100), Display(Name = "Nombre")]
        public string ProductName { get; set; }

        [StringLength(10000), Display(Name = "Descripcion del producto"), DataType(DataType.MultilineText)]
        [DefaultValue("El vendedor no agrego una descripcion.")]
        public string Description { get; set; }

        [DataType(DataType.ImageUrl), DefaultValue("~/Content/imagenes/Imagen_no_disponible.png")]
        public string ImagePath { get; set; }

        [Required, Display(Name = "Precio"), DataType(DataType.Currency)]
        public decimal UnitPrice { get; set; }

        [Required, Display(Name = "Cantidad disponible")]
        public uint Cantidad { get; set; }

        [Required]
        [Display(Name = "Categoria")]
        public int CategoryID { get; set; }

        [Required]
        [Display(Name = "Vendedor")]
        public int VendedorID { get; set; }

        public virtual Categoria Category { get; set; }

        public virtual Vendedor Vendedor { get; set; }
    }

    public class Reviews
    {
        public int ReviewsId { get; set; }

        [Required]
        [StringLength(50000), Display(Name = "Reseña del producto"), DataType(DataType.MultilineText)]
        public string Review { get; set; }

        [Required]
        public int ProductID { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Usuario { get; set; }

        public virtual Producto Producto { get; set; }
    }

    public class ProductContext : DbContext
    {
        public ProductContext()
            : base("DefaultConnection") 
        {
        } 
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<DetallesCompra> Detalles { get; set; }
    }
}