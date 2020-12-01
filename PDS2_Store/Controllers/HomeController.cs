using Dapper;
using PDS2_Store.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PDS2_Store.Controllers
{
    //[Authorize(Roles = "cliente")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (User.IsInRole("admin"))
            {
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return View();
            }
        }

        public ActionResult _MenuSideBar()
        {
            MenuModel ObjMenuModel = new MenuModel();
            ObjMenuModel.MainMenuModel = new List<MainMenu>();
            ObjMenuModel.MainMenuModel = GetMainMenu();
            ObjMenuModel.SubMenuModel = new List<SubMenu>();
            ObjMenuModel.SubMenuModel = GetSubMenu();

            return PartialView("_MenuSideBar", ObjMenuModel);
        }

        public List<MainMenu> GetMainMenu()
        {
            List<MainMenu> ObjMainMenu = new List<MainMenu>();
            MenuContext db = new MenuContext();
            var c1 = db.Categorias.ToList();
            foreach (var item in c1)
            {
                ObjMainMenu.Add(new MainMenu { ID = item.CategoriaID, MainMenuItem = item.CategoryName });
            }

            return ObjMainMenu;
        }

        public List<SubMenu> GetSubMenu()

        {
            List<SubMenu> ObjSubMenu = new List<SubMenu>();
            MenuContext db = new MenuContext();
            var c1 = db.SubCategorias.ToList();
            foreach (var item in c1)
            {
                ObjSubMenu.Add(new SubMenu { MainMenuID = item.CategoriaID, SubMenuItem = item.CatNombre, SubMenuURL = item.CatProductoId.ToString() });
            }

            return ObjSubMenu;
        }

        public ActionResult FAQ()
        {
            return View();
        }
    }
}