namespace PDS2_Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class corregirllavesforaneas : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carts", "Product_ProductoID", "dbo.Productoes");
            DropForeignKey("dbo.Productoes", "Category_CategoriaID", "dbo.Categorias");
            DropForeignKey("dbo.Reviews", "Producto_ProductoID", "dbo.Productoes");
            DropIndex("dbo.Carts", new[] { "Product_ProductoID" });
            DropIndex("dbo.Productoes", new[] { "Category_CategoriaID" });
            DropIndex("dbo.Reviews", new[] { "Producto_ProductoID" });
            RenameColumn(table: "dbo.Carts", name: "Product_ProductoID", newName: "ProductoId");
            RenameColumn(table: "dbo.Productoes", name: "Category_CategoriaID", newName: "CategoriaID");
            RenameColumn(table: "dbo.Reviews", name: "Producto_ProductoID", newName: "ProductoID");
            AlterColumn("dbo.Carts", "ProductoId", c => c.Int(nullable: false));
            AlterColumn("dbo.Productoes", "CategoriaID", c => c.Int(nullable: false));
            AlterColumn("dbo.Reviews", "ProductoID", c => c.Int(nullable: false));
            CreateIndex("dbo.Carts", "ProductoId");
            CreateIndex("dbo.Productoes", "CategoriaID");
            CreateIndex("dbo.Reviews", "ProductoID");
            AddForeignKey("dbo.Carts", "ProductoId", "dbo.Productoes", "ProductoID", cascadeDelete: true);
            AddForeignKey("dbo.Productoes", "CategoriaID", "dbo.Categorias", "CategoriaID", cascadeDelete: true);
            AddForeignKey("dbo.Reviews", "ProductoID", "dbo.Productoes", "ProductoID", cascadeDelete: true);
            DropColumn("dbo.Carts", "ProductId");
            DropColumn("dbo.Productoes", "CategoryID");
            DropColumn("dbo.Reviews", "ProductID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reviews", "ProductID", c => c.Int(nullable: false));
            AddColumn("dbo.Productoes", "CategoryID", c => c.Int(nullable: false));
            AddColumn("dbo.Carts", "ProductId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Reviews", "ProductoID", "dbo.Productoes");
            DropForeignKey("dbo.Productoes", "CategoriaID", "dbo.Categorias");
            DropForeignKey("dbo.Carts", "ProductoId", "dbo.Productoes");
            DropIndex("dbo.Reviews", new[] { "ProductoID" });
            DropIndex("dbo.Productoes", new[] { "CategoriaID" });
            DropIndex("dbo.Carts", new[] { "ProductoId" });
            AlterColumn("dbo.Reviews", "ProductoID", c => c.Int());
            AlterColumn("dbo.Productoes", "CategoriaID", c => c.Int());
            AlterColumn("dbo.Carts", "ProductoId", c => c.Int());
            RenameColumn(table: "dbo.Reviews", name: "ProductoID", newName: "Producto_ProductoID");
            RenameColumn(table: "dbo.Productoes", name: "CategoriaID", newName: "Category_CategoriaID");
            RenameColumn(table: "dbo.Carts", name: "ProductoId", newName: "Product_ProductoID");
            CreateIndex("dbo.Reviews", "Producto_ProductoID");
            CreateIndex("dbo.Productoes", "Category_CategoriaID");
            CreateIndex("dbo.Carts", "Product_ProductoID");
            AddForeignKey("dbo.Reviews", "Producto_ProductoID", "dbo.Productoes", "ProductoID");
            AddForeignKey("dbo.Productoes", "Category_CategoriaID", "dbo.Categorias", "CategoriaID");
            AddForeignKey("dbo.Carts", "Product_ProductoID", "dbo.Productoes", "ProductoID");
        }
    }
}
