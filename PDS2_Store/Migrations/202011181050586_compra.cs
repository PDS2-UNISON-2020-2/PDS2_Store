namespace PDS2_Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class compra : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Compras", "PaqueteriaId", c => c.Int(nullable: false));
            AddColumn("dbo.Compras", "Express", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Compras", "Express");
            DropColumn("dbo.Compras", "PaqueteriaId");
        }
    }
}
