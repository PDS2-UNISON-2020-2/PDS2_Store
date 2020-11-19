using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PDS2_Store.Models
{
    public class MenuModel

    {
        public List<MainMenu> MainMenuModel { get; set; }
        public List<SubMenu> SubMenuModel { get; set; }
    }


    public class MainMenu

    {
        public int ID;
        public string MainMenuItem;
    }

    public class SubMenu

    {
        public int MainMenuID;
        public string SubMenuItem;
        public string SubMenuURL;
    }

    public class MenuContext : DbContext
    {
        public MenuContext()
            : base("DefaultConnection")
        {
        }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<CatProducto> SubCategorias { get; set; }

    }
}
