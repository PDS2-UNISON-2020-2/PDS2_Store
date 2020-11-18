namespace PDS2_Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class compra2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Compras", "UserId", c => c.String(maxLength: 128));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Compras", "UserId", c => c.String());
        }
    }
}
