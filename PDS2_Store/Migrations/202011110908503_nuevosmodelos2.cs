namespace PDS2_Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nuevosmodelos2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Productoes", "CategoriaID", "dbo.Categorias");
            DropIndex("dbo.Productoes", new[] { "CategoriaID" });
            CreateTable(
                "dbo.CatProducto",
                c => new
                    {
                        CatProductoId = c.Int(nullable: false, identity: true),
                        CatNombre = c.String(),
                        CategoriaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CatProductoId)
                .ForeignKey("dbo.Categorias", t => t.CategoriaID, cascadeDelete: true)
                .Index(t => t.CategoriaID);
            
            AddColumn("dbo.Productoes", "Imagen", c => c.Binary());
            AddColumn("dbo.Productoes", "CatProductoId", c => c.Int(nullable: false));
            AddColumn("dbo.Vendedors", "UserId", c => c.String(maxLength: 128));
            AddColumn("dbo.Compras", "UserId", c => c.String());
            AddColumn("dbo.Compras", "DireccionId", c => c.Int(nullable: false));
            AddColumn("dbo.Compras", "TarjetaId", c => c.Int(nullable: false));
            AddColumn("dbo.Reviews", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Reviews", "UserId");
            AddForeignKey("dbo.Reviews", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            CreateIndex("dbo.Productoes", "CatProductoId");
            AddForeignKey("dbo.Productoes", "CatProductoId", "dbo.CatProducto", "CatProductoId", cascadeDelete: true);
            DropColumn("dbo.Productoes", "ImagePath");
            DropColumn("dbo.Productoes", "CategoriaID");
            DropColumn("dbo.Vendedors", "nombre");
            DropColumn("dbo.Compras", "Apellido");
            DropColumn("dbo.Compras", "Direccion");
            DropColumn("dbo.Compras", "Ciudad");
            DropColumn("dbo.Compras", "Estado");
            DropColumn("dbo.Compras", "CodigoPostal");
            DropColumn("dbo.Compras", "Pais");
            DropColumn("dbo.Compras", "Telefono");
            DropColumn("dbo.Compras", "Email");
            DropColumn("dbo.Reviews", "Usuario");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reviews", "Usuario", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Compras", "Email", c => c.String());
            AddColumn("dbo.Compras", "Telefono", c => c.String());
            AddColumn("dbo.Compras", "Pais", c => c.String());
            AddColumn("dbo.Compras", "CodigoPostal", c => c.String());
            AddColumn("dbo.Compras", "Estado", c => c.String());
            AddColumn("dbo.Compras", "Ciudad", c => c.String());
            AddColumn("dbo.Compras", "Direccion", c => c.String());
            AddColumn("dbo.Compras", "Apellido", c => c.String());
            AddColumn("dbo.Vendedors", "nombre", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Productoes", "CategoriaID", c => c.Int(nullable: false));
            AddColumn("dbo.Productoes", "ImagePath", c => c.String());
            DropForeignKey("dbo.Productoes", "CatProductoId", "dbo.CatProducto");
            DropForeignKey("dbo.CatProducto", "CategoriaID", "dbo.Categorias");
            DropIndex("dbo.CatProducto", new[] { "CategoriaID" });
            DropIndex("dbo.Productoes", new[] { "CatProductoId" });
            DropForeignKey("dbo.Reviews", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Reviews", new[] { "UserId" });
            DropColumn("dbo.Reviews", "UserId");
            DropColumn("dbo.Compras", "TarjetaId");
            DropColumn("dbo.Compras", "DireccionId");
            DropColumn("dbo.Compras", "UserId");
            DropColumn("dbo.Vendedors", "UserId");
            DropColumn("dbo.Productoes", "CatProductoId");
            DropColumn("dbo.Productoes", "Imagen");
            DropTable("dbo.CatProducto");
            CreateIndex("dbo.Productoes", "CategoriaID");
            AddForeignKey("dbo.Productoes", "CategoriaID", "dbo.Categorias", "CategoriaID", cascadeDelete: true);
        }
    }
}
