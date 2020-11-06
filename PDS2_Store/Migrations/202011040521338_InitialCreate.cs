namespace PDS2_Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        CartId = c.String(),
                        Quantity = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Product_ProductoID = c.Int(),
                    })
                .PrimaryKey(t => t.ItemId)
                .ForeignKey("dbo.Productoes", t => t.Product_ProductoID)
                .Index(t => t.Product_ProductoID);
            
            CreateTable(
                "dbo.Productoes",
                c => new
                    {
                        ProductoID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false, maxLength: 100),
                        Description = c.String(),
                        ImagePath = c.String(),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CategoryID = c.Int(nullable: false),
                        VendedorID = c.Int(nullable: false),
                        Category_CategoriaID = c.Int(),
                    })
                .PrimaryKey(t => t.ProductoID)
                .ForeignKey("dbo.Categorias", t => t.Category_CategoriaID)
                .ForeignKey("dbo.Vendedors", t => t.VendedorID, cascadeDelete: true)
                .Index(t => t.VendedorID)
                .Index(t => t.Category_CategoriaID);
            
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        CategoriaID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.CategoriaID);
            
            CreateTable(
                "dbo.Vendedors",
                c => new
                    {
                        VendedorId = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.VendedorId);
            
            CreateTable(
                "dbo.Compras",
                c => new
                    {
                        CompraId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Direccion = c.String(),
                        Ciudad = c.String(),
                        Estado = c.String(),
                        CodigoPostal = c.String(),
                        Pais = c.String(),
                        Telefono = c.String(),
                        Email = c.String(),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FechaCompra = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CompraId);
            
            CreateTable(
                "dbo.DetallesCompras",
                c => new
                    {
                        DetallesCompraId = c.Int(nullable: false, identity: true),
                        CompraId = c.Int(nullable: false),
                        ProductoId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.DetallesCompraId)
                .ForeignKey("dbo.Compras", t => t.CompraId, cascadeDelete: true)
                .ForeignKey("dbo.Productoes", t => t.ProductoId, cascadeDelete: true)
                .Index(t => t.CompraId)
                .Index(t => t.ProductoId);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ReviewsId = c.Int(nullable: false, identity: true),
                        Review = c.String(),
                        ProductID = c.Int(nullable: false),
                        Usuario = c.String(),
                        Producto_ProductoID = c.Int(),
                    })
                .PrimaryKey(t => t.ReviewsId)
                .ForeignKey("dbo.Productoes", t => t.Producto_ProductoID)
                .Index(t => t.Producto_ProductoID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "Producto_ProductoID", "dbo.Productoes");
            DropForeignKey("dbo.DetallesCompras", "ProductoId", "dbo.Productoes");
            DropForeignKey("dbo.DetallesCompras", "CompraId", "dbo.Compras");
            DropForeignKey("dbo.Carts", "Product_ProductoID", "dbo.Productoes");
            DropForeignKey("dbo.Productoes", "VendedorID", "dbo.Vendedors");
            DropForeignKey("dbo.Productoes", "Category_CategoriaID", "dbo.Categorias");
            DropIndex("dbo.Reviews", new[] { "Producto_ProductoID" });
            DropIndex("dbo.DetallesCompras", new[] { "ProductoId" });
            DropIndex("dbo.DetallesCompras", new[] { "CompraId" });
            DropIndex("dbo.Productoes", new[] { "Category_CategoriaID" });
            DropIndex("dbo.Productoes", new[] { "VendedorID" });
            DropIndex("dbo.Carts", new[] { "Product_ProductoID" });
            DropTable("dbo.Reviews");
            DropTable("dbo.DetallesCompras");
            DropTable("dbo.Compras");
            DropTable("dbo.Vendedors");
            DropTable("dbo.Categorias");
            DropTable("dbo.Productoes");
            DropTable("dbo.Carts");
        }
    }
}
