namespace PDS2_Store.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;

    internal sealed class Configuration : DbMigrationsConfiguration<PDS2_Store.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PDS2_Store.Models.ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!roleManager.RoleExists("Comprador"))
                roleManager.Create(new IdentityRole("Comprador"));

            if (!roleManager.RoleExists("Vendedor"))
                roleManager.Create(new IdentityRole("Vendedor"));

        }
    }
}
