using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System;
using PDS2_Store.Models;

[assembly: OwinStartupAttribute(typeof(PDS2_Store.Startup))]
namespace PDS2_Store
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }

        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            // In Startup I am creating first Admin Role and creating a default Admin User   
            if (!roleManager.RoleExists("admin"))
            {

                // first we create Admin role   
                var role = new IdentityRole();
                role.Name = "admin";
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website                 

                var user = new ApplicationUser();
                user.UserName = "admin@admin.com";
                user.Email = "admin@admin.com";
                DateTime oDate = Convert.ToDateTime("01 / 01 / 2020 12:00:00 AM");
                user.FechaNacimiento = oDate;
                user.PrimerNombre = "Admin";
                user.PhoneNumber = "123";


                string userPWD = "Admin123.";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin  
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "admin");

                }
            }

            // creating Creating Manager role   
            if (!roleManager.RoleExists("cliente"))
            {
                var role = new IdentityRole();
                role.Name = "cliente";
                roleManager.Create(role);

            }

            if (!roleManager.RoleExists("vendedor"))
            {
                var role = new IdentityRole();
                role.Name = "vendedor";
                roleManager.Create(role);

            }

            // creating Creating Employee role   
            if (!roleManager.RoleExists("empleado"))
            {
                var role = new IdentityRole();
                role.Name = "empleado";
                roleManager.Create(role);

            }
        }
    }
}
