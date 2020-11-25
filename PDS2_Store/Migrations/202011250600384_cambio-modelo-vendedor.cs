namespace PDS2_Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambiomodelovendedor : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vendedors", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vendedors", "UserId", c => c.String(maxLength: 128));
        }
    }
}
