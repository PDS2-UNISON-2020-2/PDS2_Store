namespace PDS2_Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class actualizarProduct : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vendedors", "nombre", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Reviews", "Review", c => c.String(nullable: false));
            AlterColumn("dbo.Reviews", "Usuario", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reviews", "Usuario", c => c.String());
            AlterColumn("dbo.Reviews", "Review", c => c.String());
            AlterColumn("dbo.Vendedors", "nombre", c => c.String(nullable: false));
        }
    }
}
